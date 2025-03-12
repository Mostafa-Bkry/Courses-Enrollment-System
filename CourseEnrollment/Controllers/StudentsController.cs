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
    }
}
