using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ex01_CreatingAppWithDataStorageImpl.Data;
using Ex01_CreatingAppWithDataStorageImpl.Models;
using Microsoft.AspNetCore.OutputCaching;
using System.Runtime.CompilerServices;

namespace Ex03_ApplyingСaching.Controllers
{
    public class BidController : Controller
    {
        private readonly CreditContextClass _context;

        public BidController(CreditContextClass context)
        {
            _context = context;
        }



        // GET: Bid


         
        [OutputCache(Duration = 60)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bids.ToListAsync());
        }




        // GET: Bid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidClass = await _context.Bids
                .FirstOrDefaultAsync(m => m.BidClassId == id);
            if (bidClass == null)
            {
                return NotFound();
            }

            return View(bidClass);
        }

        // GET: Bid/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BidClassId,Name,CreditHead,bidDate")] BidClass bidClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bidClass);
        }

        // GET: Bid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidClass = await _context.Bids.FindAsync(id);
            if (bidClass == null)
            {
                return NotFound();
            }
            return View(bidClass);
        }

        // POST: Bid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BidClassId,Name,CreditHead,bidDate")] BidClass bidClass)
        {
            if (id != bidClass.BidClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidClassExists(bidClass.BidClassId))
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
            return View(bidClass);
        }

        // GET: Bid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidClass = await _context.Bids
                .FirstOrDefaultAsync(m => m.BidClassId == id);
            if (bidClass == null)
            {
                return NotFound();
            }

            return View(bidClass);
        }

        // POST: Bid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidClass = await _context.Bids.FindAsync(id);
            if (bidClass != null)
            {
                _context.Bids.Remove(bidClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidClassExists(int id)
        {
            return _context.Bids.Any(e => e.BidClassId == id);
        }
    }
}
