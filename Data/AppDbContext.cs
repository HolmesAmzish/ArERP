using ArERP.Areas.Finance.Models;
using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Procurement.Models;
using ArERP.Areas.Production.Models;
using ArERP.Models;
using ArERP.Models.Entity;
using ArERP.Models.Entity.Sales;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Data;

/**
 * AppDbContext
 */
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // System
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Permission> Permissions { get; set; }

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
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionLine> TransactionLines { get; set; }
    
    // Production
    public DbSet<ProcessOperation> ProcessOperations { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Bom> Bom { get; set; }
    public DbSet<BomLines> BomLines { get; set; }
    public DbSet<ProcessRoute> ProcessRoutes { get; set; }
    public DbSet<ProcessRouteLines> ProcessRouteLines { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    
    // Finance
    public DbSet<CostCenter> CostCenters { get; set; }
    public DbSet<JournalEntry> JournalEntries { get; set; }
    public DbSet<JournalEntryLine> JournalEntryLines { get; set; }
    
    // Procurement
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderLine> PurchaseOrdersLines { get; set; }
    
    // Sales
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
}