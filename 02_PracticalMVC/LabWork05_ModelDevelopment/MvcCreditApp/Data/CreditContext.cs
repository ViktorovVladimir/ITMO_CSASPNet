using Microsoft.EntityFrameworkCore;
using MvcCreditApp.Models;

namespace MvcCreditApp.Data
{   
    public class CreditContext : DbContext
    {
        public CreditContext(DbContextOptions<CreditContext> options)
        : base(options)
        { }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
