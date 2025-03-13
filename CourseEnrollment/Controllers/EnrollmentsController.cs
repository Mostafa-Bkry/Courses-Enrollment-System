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
            List<Student> stdModel = _unitOfWork.Enrollments.GetStudentsPerCourse(crsId);
            return PartialView("_EnrolledStudentsPartialView", stdModel);
        }


    }
}
