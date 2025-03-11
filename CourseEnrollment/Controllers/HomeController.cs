using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
