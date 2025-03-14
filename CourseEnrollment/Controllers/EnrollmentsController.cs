using CourseEnrollment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public EnrollmentsController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> crsModel = _unitOfWork.Courses.GetAll();

            return View(crsModel);
        }

        #region Getting the enrolled students against selected course
        [HttpGet]
        public IActionResult GetEnrolled(int crsId)
        {
            List<Student> students = _unitOfWork.Enrollments.GetStudentsPerCourse(crsId);
            StudentsPerSelectedCourseVM stdModel = new StudentsPerSelectedCourseVM()
            {
                CrsId = crsId,
                CrsStudents = students
            };

            return PartialView("_EnrolledStudentsPartialView", stdModel);
        } 
        #endregion

        #region Checking if the student is already enrolled
        [HttpGet]
        public IActionResult CheckIfEnrolled(int crsId, List<int> selectedStudents)
        {
            List<Student> alreadyEnrolled = new List<Student>();
            int status = 0;

            foreach (int stId in selectedStudents)
            {
                Enrollment en = _unitOfWork.Enrollments.GetById(crsId, stId);
                if (en.CourseId > 0 && en.StudentId > 0)
                {
                    status = -1;
                    alreadyEnrolled.Add(_unitOfWork.Students.GetById(stId));
                }
            }

            if (status == -1 && alreadyEnrolled.Count > 0)
            {
                return Json(new { status = -1, stds = alreadyEnrolled.Select(s => new { s.Id, s.FullName, s.Email }) });
            }

            return Json("safe");
        }
        #endregion

        #region Getting course slots
        [HttpGet]
        public IActionResult GetSlots(int crsId)
        {
            int maxSlots = _unitOfWork.Courses.GetById(crsId).MaxCapacity;
            int availableSlots = maxSlots - _unitOfWork.Enrollments.GetStudentsPerCourse(crsId).Count;

            return Json(new { maxSlots, availableSlots });
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            List<Course> courses = _unitOfWork.Courses.GetAll();
            List<Student> students = _unitOfWork.Students.GetAll();

            EnrollmentFormVM enrollmentModel = new EnrollmentFormVM()
            {
                Courses = courses,
                Students = students.Select(s => new EnrollFormSelectStudentDataVM()
                {
                    Id = s.Id,
                    ShowedData = string.Concat(s.FullName, " - ", s.Email),
                }).ToList(),
            };

            return View(enrollmentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EnrollmentFormVM enrollModel)
        {
            if (!ModelState.IsValid)
                return View(enrollModel);

            int maxSlots = _unitOfWork.Courses.GetById(enrollModel.selectedCrsId).MaxCapacity;
            int availableSlots = maxSlots - _unitOfWork.Enrollments.GetStudentsPerCourse(enrollModel.selectedCrsId).Count;
            int willBeEnrolled = enrollModel.SelectedStudentsIds.Count;

            if(willBeEnrolled > availableSlots)
            {
                ModelState.AddModelError("selectedCrsId", 
                    $"There are no available slots yet! at {_unitOfWork.Courses.GetById(enrollModel.selectedCrsId).Title}");
                return RedirectToAction(nameof(Add));
            }

            List<Enrollment> enrollments = new List<Enrollment>();
            foreach (int sId in enrollModel.SelectedStudentsIds)
                enrollments.Add(new Enrollment()
                {
                    CourseId = enrollModel.selectedCrsId,
                    StudentId = sId
                });

            bool done = _unitOfWork.Enrollments.Add(enrollments);
            if (done)
                _unitOfWork.Complete();
            else
                return BadRequest("Can't Savechanges of adding this course to database");

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int crsId, int stdId)
        {
            bool done = _unitOfWork.Enrollments.Delete(crsId, stdId);
            if (done)
                _unitOfWork.Complete();
            else
                return BadRequest("Faild to Delete this Enrollment");

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
