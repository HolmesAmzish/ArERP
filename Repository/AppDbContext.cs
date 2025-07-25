using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.Inventory.Models;
using ArERP.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Repository;
/**
 * AppDbContext
 */
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // System
    public DbSet<User> Users { get; set; }
    
    // Human Resource
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeApplication> EmployeeApplications { get; set; }
    public DbSet<EmployeeSeparation> EmployeeSeparations { get; set; }
    public DbSet<EvaluationHeader> EvaluationHeader { get; set; }
    public DbSet<EvaluationDetail> EvaluationDetail { get; set; }
    
    // Inventory
    public DbSet<Item> Items { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<InventoryBalance> InventoryBalances { get; set; }
    public DbSet<Transaction> InventoryTransactions { get; set; }
    public DbSet<TransactionLine> TransactionLines { get; set; }
}

