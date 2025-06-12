using Kursach_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kursach_MVC.Controllers
{
    public class MeasurementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Build(Measurements measure)
        {
            if(ModelState.IsValid)
            {
                //return Redirect("/pattern");
                return View("Pattern", measure);
            }

            return View("Index");
        }

    }
}
