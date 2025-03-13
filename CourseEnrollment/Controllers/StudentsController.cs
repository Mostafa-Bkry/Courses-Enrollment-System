using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public StudentsController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> studentsModel = _unitOfWork.Students.GetAll();
            return View(studentsModel);
        }

        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            Student stdModel = _unitOfWork.Students.GetById(id);
            return View(stdModel);
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            bool uniqueEmail;

            bool done = _unitOfWork.Students.Add(student, out uniqueEmail);
            if (done)
            {
                _unitOfWork.Complete();
            }
            else
            {
                // check if the problem reason is email uniqueness or not
                if (uniqueEmail)
                {
                    return BadRequest("Can't Savechanges of adding this student to database");
                }
                else
                {
                    ModelState.AddModelError("Email", "This E-mail already exists");
                    return View(student);
                }
            }
                     

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student stdModel = _unitOfWork.Students.GetById(id);
            return View(stdModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            bool uniqueEmail;

            bool done = _unitOfWork.Students.Edit(student, out uniqueEmail);
            if (done)
            {
                _unitOfWork.Complete();
            }
            else
            {
                // check if the problem reason is email uniqueness or not
                if (uniqueEmail)
                {
                    return BadRequest("Can't Savechanges of editing this student to database");
                }
                else
                {
                    ModelState.AddModelError("Email", "Can't use this E-mail because it's already exists");
                    return View(student);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool done = _unitOfWork.Students.Delete(id);
            if (done)
                _unitOfWork.Complete();
            else
                return BadRequest("Faild to Delete this course");

            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}
