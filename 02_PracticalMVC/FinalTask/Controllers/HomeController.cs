using FinalTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FinalTask.Data;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Cryptography;
using System.Collections.Generic;


namespace FinalTask.Controllers
{   

    public class studentGrade
    {   
        public string Name { get; set; }
        public int TotalGrade { get; set; }
    }   


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        //--.
        private readonly ReportContext db;


        public HomeController(ILogger<HomeController> logger, ReportContext context, 
                                    IWebHostEnvironment env)
        {
            _logger = logger;
            db = context;
            _env = env;
        }

        //--.
        [HttpGet]
        public IActionResult Index()
        {
            //--.
            GiveStudents();

            //--.
            GiveDisciplines();

            //--. sort alphabetically with total points
            ViewBag.StudentSums = GetBaseSumStudents();

            //--. five best students
            ViewBag.TopStudent = GetTopStudents();

            //--. five worst students
            ViewBag.BottomStudent = GetDownStudents();
            
            //--.
            return View();
        }


        //--.
        private void GiveStudents()
        {
            //--.
            var allStudents = db.Students.ToList<Student>();
            //--.
            ViewBag.Students = allStudents;
        }


        //--.
        private void GiveDisciplines()
        {
            //--.
            var allDisciplines = db.Disciplines.ToList<Discipline>();
            //--.
            ViewBag.Disciplines = allDisciplines;
        }


        //--.
        private List<studentGrade> GetBaseSumStudents()
        {
            return
                db.ReportCards.GroupBy(s => s.Name)                             //
                .Select(g => new studentGrade
                {
                    Name = g.Key,
                    TotalGrade = g.Sum(s => s.grade)                             //

                }).ToList(); ;                                                  //
        }


        //--.
        private List<studentGrade> GetTopStudents()
        {  
            return
                db.ReportCards.GroupBy(s => s.Name)                             //
                .Select(g => new studentGrade
                {
                    Name = g.Key,
                    TotalGrade = g.Sum(s => s.grade)                            //

                }).OrderByDescending(s => s.TotalGrade)
                    .Take(5)                                                        //
                    .ToList();               //
        }


        //--.
        private List<studentGrade> GetDownStudents()
        {
            return db.ReportCards.GroupBy(s => s.Name)                          //
                .Select(g => new studentGrade 
                {
                    Name = g.Key,
                    TotalGrade = g.Sum(s => s.grade)                            //

                }).OrderBy(s => s.TotalGrade)
                .Take(5)                                                        //
                .ToList();
        }   



        //--.
        [HttpGet]
        public ActionResult CreateRepCard()
        {
            List<int>  AllGrades = [ 5, 4, 3, 2 ];

            //--.
            GiveStudents();
            //--.
            GiveDisciplines();
            //--.
            var allRCards = db.ReportCards.ToList<ReportCard>();

            //--.
            ViewBag.repCards = allRCards;
            //--.
            ViewBag.repGrades = AllGrades;
            //--.
            return View();
        }


        //--.
        [HttpPost]
        //public string CreateRepCard( ReportCard newReportCard ) 
        public ActionResult CreateRepCard( ReportCard newReportCard)
        {
            
            //--. need to check that the database already has a line with such a student and with the discipline
            var exist = db.ReportCards.FirstOrDefault(rc=>rc.Name== newReportCard.Name 
                                    && rc.DisciplineHead == newReportCard.DisciplineHead); 

            //--.
            if( exist != null )
            {
                TempData["ErrorMessage"] = "a record with this data already exists";
                return RedirectToAction("CreateRepCard");
                //return "a record with this data already exists";
            }

            
            //--.
            if( newReportCard.dueDate.GetHashCode() == 0 )
            {
                TempData["ErrorMessage"] = "the exam date has not been sets";
                return RedirectToAction("CreateRepCard");
            }
            


            //--. adding a new statement to the database
            db.ReportCards.Add( newReportCard );
            //--. we save all changes to the database
            db.SaveChanges();
            //--.
            TempData["SuccessMessage"] = "entry added successfully";
            return RedirectToAction("CreateRepCard");
        }



        //--.
        [HttpPost]
        public ActionResult SaveToFile(string type)
        {
            //--.
            List<studentGrade> students;

            //--.
            if( type == "basesum")
            {
                //--.
                students = GetTopStudents();
                SaveToFile(students, "BaseSumStudents.txt");
                TempData["SFSuccessMessage"] = "The data with the total points for all students was successfully saved to a file.";
            }
            //--.
            else if( type == "top" )
            {
                //--.
                students = GetTopStudents();
                SaveToFile( students, "FiveTopStudents.txt" );
                //ViewBag.Message = "Данные о пяти лучших студентах успешно сохранены в файл";
                TempData["SFSuccessMessage"] = "Data about the five top students was successfully saved to a file";
            }
            //--.
            else if ( type == "down" )
            {
                //--.
                students = GetDownStudents();
                SaveToFile(students, "FiveDownStudents.txt");
                //ViewBag.Message = "Данные о пяти худших студентах успешно сохранены в файл";
                TempData["SFSuccessMessage"] = "Data about the five worst students was successfully saved to a file";
            }
            else
            {
                TempData["SFErrorMessage"] = "error save data in file";
            }


            return RedirectToAction("Index");
        }


        //--.
        private void SaveToFile( List<studentGrade> students, string filename )
        {
            string filePath = Path.Combine(_env.ContentRootPath, "", filename) ; 
                
            //--.
            using( StreamWriter writer = new StreamWriter(filePath) )
            {
                writer.WriteLine($"Пять {(filename.Contains("Top") ? "лучших" : "худших")} студентов:\n");
                writer.WriteLine("Имя студента\t Сумма баллов");
                foreach(var item in students) 
                {
                    writer.WriteLine($"{item.Name}\t\t {item.TotalGrade}");
                }
            }
        }


        //--.
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
