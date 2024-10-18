using Ex01_UsingIndividualUserAccounts.Data;
using Ex01_UsingIndividualUserAccounts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace Ex01_UsingIndividualUserAccounts.Controllers
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


        [Authorize]
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

        //--.
        public ActionResult BidSearch(string name) 
        {
            //--.
            var allBids = db.Bids.Where(a => a.CreditHead.Contains(name)).ToList();

            //--.
            if(allBids.Count == 0)
            {
                return Content("��������� ������ " + name + " �� ������");
            }
            
            //--.
            return PartialView(allBids);
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
