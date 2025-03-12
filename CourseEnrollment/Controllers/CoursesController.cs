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
            return View(coursesModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Course crsModel = _unitOfWork.Courses.GetById(id);
            return PartialView("_CourseDetailsPartialView", crsModel);
            //return View(crsModel);
        }
    }
}
