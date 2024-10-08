using Ex03_ControllerWithModelApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex03_ControllerWithModelApp.Controllers
{
    public class HomeController : Controller
    {   
        //--. call string:
        //      https://localhost:7132/Home/Index?hel=Ivan
        public string Index(string hel)
        {
            int hour = DateTime.Now.Hour;
            string sGreeting = ModelClass.ModelHello() + ", "+ hel;
            
            return sGreeting;
        }
    }
}
