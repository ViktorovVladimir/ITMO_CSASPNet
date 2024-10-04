using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppCoreRaxorPages01.Data;
using WebAppCoreRaxorPages01.Models;

namespace WebAppCoreRaxorPages01.Pages.Customers2
{
    public class ListModel : PageModel
    {
        private readonly WebAppCoreRaxorPages01.Data.CustomerDbContext _context;

        public ListModel(WebAppCoreRaxorPages01.Data.CustomerDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }
        }
    }
}
