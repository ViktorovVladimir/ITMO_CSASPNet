using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ex03_UsingMVCViewTemplatesWithDataTemplates.Models;

namespace Ex03_UsingMVCViewTemplatesWithDataTemplates.Controllers
{
    public class PersonController : Controller
    {
        static List<PersonClass> people = new List<PersonClass>(); 
        
        // GET: PersonController
        public ActionResult Index()
        {
            return View(people);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(PersonClass p)
        {
            return View(p);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonClass p)
        {   
            try
            {
                //--.
                if( !ModelState.IsValid )
                {
                    return View("Create", p);
                }

                //--.
                people.Add(p);

                //--.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {   
            PersonClass p = new PersonClass();

            //--.
            foreach( PersonClass pn in people )
            {
                //--.
                if( pn.Id == id )
                {   
                    p.Name = pn.Name;
                    p.Age = pn.Age;
                    p.Id = pn.Id;
                    p.Phone = pn.Phone;
                    p.Email = pn.Email;
                }   
            }
            
            return View(p);
        }   
        
        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonClass p)
        {
            try
            {   
                //--.
                if( !ModelState.IsValid )
                {
                    return View("Edit", p);
                }
                
                //--.
                foreach( PersonClass pn in people )
                {
                    if( pn.Id == p.Id ) 
                    { 
                        pn.Name = p.Name;
                        pn.Age = p.Age;
                        pn.Id = p.Id;
                        pn.Phone = p.Phone;
                        pn.Email = p.Email;
                    }
                }
                //--.                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Edit", p);
            }
        }

        //--.
        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            PersonClass p = new PersonClass();

            //--.
            foreach( PersonClass pn in people ) 
            { 
                //--.
                if( pn.Id == id )
                {   
                    p.Name = pn.Name;
                    p.Age = pn.Age;
                    p.Id = pn.Id;
                    p.Phone = pn.Phone;
                    p.Email = pn.Email;

                    //--.
                    return View(p);
                }   
            }

            return RedirectToAction(nameof(Index));
        }


        //--.
        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {   
                //--.
                foreach( PersonClass pn in people )
                {   
                    if( pn.Id == pn.Id )
                    {
                        people.Remove(pn);
                    }
                }
                //--.
                return RedirectToAction(nameof(Index));
            }   
            catch
            {
                return View();
            }
        }


    }
}
