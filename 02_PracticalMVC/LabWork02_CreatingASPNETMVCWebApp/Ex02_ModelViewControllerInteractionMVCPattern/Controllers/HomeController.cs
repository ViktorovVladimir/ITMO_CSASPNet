using Ex02_ModelViewControllerInteractionMVCPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex02_ModelViewControllerInteractionMVCPattern.Controllers
{
    public class HomeController : Controller
    {

        //--.
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            ViewData["Mes"] = "Have a good time";

            return View();
        }


        [HttpGet]
        //--.
        public ViewResult InputData()
        {
            return View();
        }


        [HttpPost]
        //--.
        public ViewResult InputData(PersonClass p)
        {
            return View("Hello", p);
        }
    }
}
