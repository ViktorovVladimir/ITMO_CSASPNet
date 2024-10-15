using Ex02_SettingUpWorkWithData.Data;
using Ex02_SettingUpWorkWithData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace Ex02_SettingUpWorkWithData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //--.
        private readonly CreditContextClass db;

        public HomeController(ILogger<HomeController> logger, CreditContextClass context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            //--.
            GiveCredits();
            //--.
            return View();
        }

        //--.
        private void GiveCredits()
        {
            var allCredits = db.Credits.ToList<CreditClass>();
            ViewBag.Credits = allCredits;
        }

        //--.
        [HttpGet]
        public ActionResult CreateBid()
        {
            GiveCredits();
            var allBids = db.Bids.ToList<BidClass>(); 
            ViewBag.Bids = allBids; 
            return View();
        }

        [HttpPost]
        public string CreateBid(BidClass newBid)
        {
            newBid.bidDate = DateTime.Now; 
            // ��������� ����� ������ � ��
            db.Bids.Add(newBid); 
            // ��������� � �� ��� ���������
            db.SaveChanges(); 
            return "�������, " + newBid.Name + ", �� ����� ������ �����. ���� ������ ����� ����������� � ������� 10 ����."; 
        }


        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
