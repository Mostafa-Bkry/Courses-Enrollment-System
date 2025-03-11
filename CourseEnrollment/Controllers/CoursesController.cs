using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Controllers
{
    public class CoursesController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
