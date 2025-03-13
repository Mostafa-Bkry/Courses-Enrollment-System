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

        #region Details with Partial View
        [HttpGet]
        public IActionResult Details(int id)
        {
            Course crsModel = _unitOfWork.Courses.GetById(id);
            return PartialView("_CourseDetailsPartialView", crsModel);
            //return View(crsModel);
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
        public IActionResult Add(Course course)
        {
            if (!ModelState.IsValid)
                return View(course);

            bool done = _unitOfWork.Courses.Add(course);
            if (done)
                _unitOfWork.Complete();
            else
                return BadRequest("Can't Savechanges of adding this course to database");

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course crsModel = _unitOfWork.Courses.GetById(id);
            return View(crsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
                return View(course);

            bool done = _unitOfWork.Courses.Edit(course);
            if (done)
                _unitOfWork.Complete();
            else
                return BadRequest("Faild to Edit this course");

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool done = _unitOfWork.Courses.Delete(id);
            if (done)
                _unitOfWork.Complete();
            else
                return BadRequest("Faild to Delete this course");

            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}
