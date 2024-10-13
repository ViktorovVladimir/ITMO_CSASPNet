using Ex01_ImplementingRepositoryModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex01_ImplementingRepositoryModel.Controllers
{
    public class HomeController : Controller
    {

        private static PersonRepositoryClass db = new PersonRepositoryClass();


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
            db.AddResponse(p);
            return View("Hello", p);
        }

        [HttpGet]
        //--.
        public ViewResult OutputData()
        {
            ViewBag.Pers = db.GetAllResponses;
            ViewBag.Count = db.NumberOfPerson;
            return View("ListPerson");
        }

    }
}
