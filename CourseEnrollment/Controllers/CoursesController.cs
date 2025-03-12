using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public CoursesController(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> coursesModel = _unitOfWork.Courses.GetAll();
            Course c = _unitOfWork.Courses.GetById(1);
            return View(coursesModel);
        }
    }
}
