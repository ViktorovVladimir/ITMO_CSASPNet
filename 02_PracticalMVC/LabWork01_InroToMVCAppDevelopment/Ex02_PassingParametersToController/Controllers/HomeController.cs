using Microsoft.AspNetCore.Mvc;

namespace Ex02_PassingParametersToController.Controllers
{
    public class HomeController : Controller
    {   
        //--. call string:
        //      https://localhost:7132/Home/Index?hel=Ivan
        public string Index(string hel)
        {
            int hour = DateTime.Now.Hour;
            string sGreeting = hour < 12 ? "Good morning" : "Good afternoon" + ", "+ hel;
            
            return sGreeting;
        }
    }
}
