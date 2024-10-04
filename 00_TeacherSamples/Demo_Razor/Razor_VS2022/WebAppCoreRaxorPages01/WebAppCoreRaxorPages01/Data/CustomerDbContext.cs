using Microsoft.EntityFrameworkCore;

namespace WebAppCoreRaxorPages01.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext>
        options) : base(options)
        { }

        public DbSet<WebAppCoreRaxorPages01.Models.Customer> Customer => Set<WebAppCoreRaxorPages01.Models.Customer>();
    }

}
