using Microsoft.EntityFrameworkCore;
using Ex02_SettingUpWorkWithData.Models;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Cryptography;

namespace Ex02_SettingUpWorkWithData.Data
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
