using Microsoft.EntityFrameworkCore;
using Ex01_CreatingAppWithDataStorageImpl.Models;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Cryptography;

namespace Ex01_CreatingAppWithDataStorageImpl.Data
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
