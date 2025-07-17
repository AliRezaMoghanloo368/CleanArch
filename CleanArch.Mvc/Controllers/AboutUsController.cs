using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
