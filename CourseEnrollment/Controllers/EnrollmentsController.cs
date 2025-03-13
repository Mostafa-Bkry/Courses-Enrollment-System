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

        [HttpGet]
        public IActionResult GetEnrolled(int crsId)
        {
            List<Student> students = _unitOfWork.Enrollments.GetStudentsPerCourse(crsId);
            List<Enrollment> enrollments = _unitOfWork.Enrollments.GetAll();
            StudentsPerSelectedCourseVM stdModel = new StudentsPerSelectedCourseVM()
            {
                CrsId = crsId,
                CrsStudents = students
            };

            return PartialView("_EnrolledStudentsPartialView", stdModel);
        }

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
