using ArERP.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeApplication> EmployeeApplications { get; set; }
        public DbSet<EmployeeSeparation> EmployeeSeparations { get; set; }
    }
}
