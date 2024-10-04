using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCoreRaxorPages01.Data;
using WebAppCoreRaxorPages01.Models;

namespace WebAppCoreRaxorPages01.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppCoreRaxorPages01.Data.CustomerDbContext _context;

        public DetailsModel(WebAppCoreRaxorPages01.Data.CustomerDbContext context)
        {
            _context = context;
        }

      public Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
