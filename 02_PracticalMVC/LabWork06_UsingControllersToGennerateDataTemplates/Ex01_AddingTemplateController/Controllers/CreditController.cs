using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ex01_CreatingAppWithDataStorageImpl.Data;
using Ex01_CreatingAppWithDataStorageImpl.Models;

namespace Ex01_AddingTemplateController.Controllers
{
    public class CreditController : Controller
    {
        private readonly CreditContextClass _context;

        public CreditController(CreditContextClass context)
        {
            _context = context;
        }

        // GET: Credit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Credits.ToListAsync());
        }

        // GET: Credit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditClass = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditClassId == id);
            if (creditClass == null)
            {
                return NotFound();
            }

            return View(creditClass);
        }

        // GET: Credit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Credit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditClassId,Head,Period,Sum,Procent")] CreditClass creditClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditClass);
        }

        // GET: Credit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditClass = await _context.Credits.FindAsync(id);
            if (creditClass == null)
            {
                return NotFound();
            }
            return View(creditClass);
        }

        // POST: Credit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditClassId,Head,Period,Sum,Procent")] CreditClass creditClass)
        {
            if (id != creditClass.CreditClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditClassExists(creditClass.CreditClassId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creditClass);
        }

        // GET: Credit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditClass = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditClassId == id);
            if (creditClass == null)
            {
                return NotFound();
            }

            return View(creditClass);
        }

        // POST: Credit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditClass = await _context.Credits.FindAsync(id);
            if (creditClass != null)
            {
                _context.Credits.Remove(creditClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditClassExists(int id)
        {
            return _context.Credits.Any(e => e.CreditClassId == id);
        }
    }
}
