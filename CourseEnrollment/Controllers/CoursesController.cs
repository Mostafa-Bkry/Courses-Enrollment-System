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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest("Can't Add this course");

            bool done = _unitOfWork.Courses.Add(course);
            if(done)
                _unitOfWork.Complete();
            else
                return BadRequest("Can't Savechanges of adding this course to database");

            return View(nameof(Index), _unitOfWork.Courses.GetAll());
        }
    }
}
