using Microsoft.AspNetCore.Mvc;

namespace Kursach_MVC.Controllers
{
    public class InstructionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
