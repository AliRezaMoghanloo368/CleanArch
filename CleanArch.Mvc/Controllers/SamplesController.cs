using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class SamplesController : Controller
    {
        public IActionResult ProgramSamples()
        {
            return View();
        }
    }
}
