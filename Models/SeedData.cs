using ArERP.Models.Entity;
using ArERP.Repository;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context == null || context.Employees == null)
            {
                throw new ArgumentNullException("Null AppDbContext");
            }

            if (context.Employees.Any())
            {
                return;
            }
            
            context.Employees.AddRange(
                new Employee
                {
                    EmployeeName = "王丽",
                    Gender = "F",
                    BirthDate = DateTime.Parse("1992-11-01"),
                    Email = "wangli@example.com",
                    Phone = "13700001111",
                    HireDate = DateTime.Parse("2022-03-20"),
                    Department = "行政部",
                    Position = "行政助理",
                    Salary = 5000.00m, // 'm' for decimal literal
                    IsActive = true
                },
                new Employee
                {
                    EmployeeName = "赵刚",
                    Gender = "M",
                    BirthDate = DateTime.Parse("1988-05-25"),
                    Email = "zhaogang@example.com",
                    Phone = "13622223333",
                    HireDate = DateTime.Parse("2019-09-05"),
                    Department = "研发部",
                    Position = "高级工程师",
                    Salary = 12000.00m,
                    IsActive = true
                },
                new Employee
                {
                    EmployeeName = "刘燕",
                    Gender = "F",
                    BirthDate = DateTime.Parse("1995-02-18"),
                    Email = "liuyan@example.com",
                    Phone = "13544445555",
                    HireDate = DateTime.Parse("2023-01-15"),
                    Department = "财务部",
                    Position = "会计",
                    Salary = 7500.00m,
                    IsActive = false
                }
            );
            context.SaveChanges();
        }
    }
}