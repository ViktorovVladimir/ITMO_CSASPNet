using Microsoft.EntityFrameworkCore;
using Ex01_UsingAJAXandPartialPages.Models;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Cryptography;

namespace Ex01_UsingAJAXandPartialPages.Data
{
        public class CreditContextClass : DbContext
        {
            public CreditContextClass(DbContextOptions<CreditContextClass> options)
            : base(options)
            { }
        public DbSet<CreditClass> Credits { get; set; }
        public DbSet<BidClass> Bids { get; set; }
    }
}
