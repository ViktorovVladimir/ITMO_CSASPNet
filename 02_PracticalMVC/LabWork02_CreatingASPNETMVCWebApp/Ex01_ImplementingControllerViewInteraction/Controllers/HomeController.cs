using Ex01_ImplementingControllerViewInteraction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex01_ImplementingControllerViewInteraction.Controllers
{
    public class HomeController : Controller
    {   
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            ViewData["Mes"] = "Have a good time";

            return View();
        }
    }
}
