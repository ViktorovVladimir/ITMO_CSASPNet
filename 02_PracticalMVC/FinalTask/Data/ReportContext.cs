using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using FinalTask.Models;


namespace FinalTask.Data
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
           : base(options)
            { }
            public DbSet<Student> Students { get; set; }
            public DbSet<Discipline> Disciplines { get; set; }
            public DbSet<ReportCard> ReportCards { get; set; }
    }
}
