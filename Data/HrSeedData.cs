using ArERP.Areas.HumanResource.Models;
using ArERP.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Data;

public class HrSeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Look for any departments.
            if (context.Departments.Any())
            {
                return;
            }

            context.Departments.AddRange(
                new Department
                {
                    DepartmentName = "人力资源部",
                    CreationDate = DateTime.Parse("2021-01-01"),
                    Deleted = false
                },
                new Department
                {
                    DepartmentName = "研发部",
                    CreationDate = DateTime.Parse("2020-03-15"),
                    Deleted = false
                },
                new Department
                {
                    DepartmentName = "财务部",
                    CreationDate = DateTime.Parse("2022-06-01"),
                    Deleted = false
                },
                new Department
                {
                    DepartmentName = "市场部",
                    CreationDate = DateTime.Parse("2021-11-20"),
                    Deleted = false
                }
            );
            context.SaveChanges();


            // // Get department IDs after saving departments
            // var hrDepartment = context.Departments.Single(d => d.DepartmentName == "人力资源部");
            // var devDepartment = context.Departments.Single(d => d.DepartmentName == "研发部");
            // var financeDepartment = context.Departments.Single(d => d.DepartmentName == "财务部");

            // Look for any employees.
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
                    DepartmentId = 1, // Assign to HR Department
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
                    DepartmentId = 2, // Assign to Dev Department
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
                    DepartmentId = 3, // Assign to Finance Department
                    Position = "会计",
                    Salary = 7500.00m,
                    IsActive = false
                }
            );
            context.SaveChanges();

            // Look for any employee applications
            if (context.EmployeeApplications.Any())
            {
                return;
            }

            context.EmployeeApplications.AddRange(
                new EmployeeApplication
                {
                    Name = "李明",
                    Gender = "M",
                    DateOfBirth = DateTime.Parse("1990-04-12"),
                    Address = "北京市朝阳区",
                    NationalId = "110101199004123456",
                    Phone = "13900001111",
                    Email = "liming@example.com",
                    DepartmentId = 1,
                    ApplicationDate = DateTime.UtcNow
                },
                new EmployeeApplication
                {
                    Name = "张洁",
                    Gender = "F",
                    DateOfBirth = DateTime.Parse("1993-08-20"),
                    Address = "上海市浦东新区",
                    NationalId = "310101199308203333",
                    Phone = "13800002222",
                    Email = "zhangjie@example.com",
                    DepartmentId = 2,
                    ApplicationDate = DateTime.UtcNow
                },
                new EmployeeApplication
                {
                    Name = "陈强",
                    Gender = "M",
                    DateOfBirth = DateTime.Parse("1985-12-05"),
                    Address = "广州市天河区",
                    NationalId = "440101198512052222",
                    Phone = "13700003333",
                    Email = "chenqiang@example.com",
                    DepartmentId = 3,
                    ApplicationDate = DateTime.UtcNow
                }
            );
            context.SaveChanges();


            if (context.EmployeeSeparations.Any())
            {
                return;
            }

            context.EmployeeSeparations.AddRange(
                new EmployeeSeparation
                {
                    EmployeeId = 5,
                    Status = ProcessStatus.Pending,
                }
            );
            context.SaveChanges();
        }
    }
}