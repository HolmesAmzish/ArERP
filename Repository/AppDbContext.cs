using ArERP.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeEntity> Employees { get; set; }

    }
}
