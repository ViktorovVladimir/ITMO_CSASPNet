using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalTask.Data;
using FinalTask.Models;

namespace FinalTask.Controllers
{
    public class ReportCardsController : Controller
    {
        private readonly ReportContext _context;

        public ReportCardsController(ReportContext context)
        {
            _context = context;
        }

        // GET: ReportCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportCards.ToListAsync());
        }

        // GET: ReportCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCard = await _context.ReportCards
                .FirstOrDefaultAsync(m => m.ReportCardId == id);
            if (reportCard == null)
            {
                return NotFound();
            }

            return View(reportCard);
        }

        // GET: ReportCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportCardId,Name,DisciplineHead,grade,dueDate")] ReportCard reportCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportCard);
        }

        // GET: ReportCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCard = await _context.ReportCards.FindAsync(id);
            if (reportCard == null)
            {
                return NotFound();
            }
            return View(reportCard);
        }

        // POST: ReportCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportCardId,Name,DisciplineHead,grade,dueDate")] ReportCard reportCard)
        {
            if (id != reportCard.ReportCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportCardExists(reportCard.ReportCardId))
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
            return View(reportCard);
        }

        // GET: ReportCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCard = await _context.ReportCards
                .FirstOrDefaultAsync(m => m.ReportCardId == id);
            if (reportCard == null)
            {
                return NotFound();
            }

            return View(reportCard);
        }

        // POST: ReportCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportCard = await _context.ReportCards.FindAsync(id);
            if (reportCard != null)
            {
                _context.ReportCards.Remove(reportCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportCardExists(int id)
        {
            return _context.ReportCards.Any(e => e.ReportCardId == id);
        }
    }
}
