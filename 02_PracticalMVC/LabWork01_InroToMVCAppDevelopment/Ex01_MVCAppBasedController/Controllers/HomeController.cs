using Microsoft.AspNetCore.Mvc;

namespace Ex01_MVCAppBasedController.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            int hour = DateTime.Now.Hour;
            string sGreeting = hour < 12 ? "Good morning" : "Good afternoon";
            
            return sGreeting;
        }
    }
}
