using ArERP.Areas.Production.Enum;
using ArERP.Areas.Production.Models;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Data;

public class ProductionSeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        // Seed WorkOrders
        if (!context.WorkOrders.Any())
        {
            context.WorkOrders.AddRange(
                new WorkOrder
                {
                    OrderNumber = "WO-0001",
                    ProductItemId = context.Items.Single(i => i.Code == "SEM-001").Id,
                    Quantity = 50m,
                    ScheduledDate = DateTime.Now.AddDays(5),
                    Status = OrderStatus.Planned
                },
                new WorkOrder
                {
                    OrderNumber = "WO-0002",
                    ProductItemId = context.Items.Single(i => i.Code == "FIN-001").Id,
                    Quantity = 20m,
                    ScheduledDate = DateTime.Now.AddDays(7),
                    Status = OrderStatus.InProgress
                },
                new WorkOrder
                {
                    OrderNumber = "WO-0003",
                    ProductItemId = context.Items.Single(i => i.Code == "SEM-002").Id,
                    Quantity = 75m,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    Status = OrderStatus.Completed
                },
                new WorkOrder
                {
                    OrderNumber = "WO-0004",
                    ProductItemId = context.Items.Single(i => i.Code == "FIN-002").Id,
                    Quantity = 10m,
                    ScheduledDate = DateTime.Now.AddDays(10),
                    Status = OrderStatus.Planned
                },
                new WorkOrder
                {
                    OrderNumber = "WO-0005",
                    ProductItemId = context.Items.Single(i => i.Code == "SEM-003").Id,
                    Quantity = 30m,
                    ScheduledDate = DateTime.Now.AddDays(8),
                    Status = OrderStatus.InProgress
                },
                new WorkOrder
                {
                    OrderNumber = "WO-0006",
                    ProductItemId = context.Items.Single(i => i.Code == "FIN-003").Id,
                    Quantity = 40m,
                    ScheduledDate = DateTime.Now.AddDays(12),
                    Status = OrderStatus.Planned
                },
                new WorkOrder
                {
                    OrderNumber = "WO-0007",
                    ProductItemId = context.Items.Single(i => i.Code == "SEM-002").Id,
                    Quantity = 60m,
                    ScheduledDate = DateTime.Now.AddDays(6),
                    Status = OrderStatus.Completed
                }
            );
            context.SaveChanges();
        }

        // Seed Shifts
        if (!context.Shifts.Any())
        {
            context.Shifts.AddRange(
                new Shift
                {
                    Name = "早班",
                    Code = "SHIFT-A",
                    StartTime = new TimeSpan(6, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    IsNightShift = false,
                    WorkingHours = 8,
                    Description = "早上六点到下午两点"
                },
                new Shift
                {
                    Name = "中班",
                    Code = "SHIFT-B",
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(22, 0, 0),
                    IsNightShift = false,
                    WorkingHours = 8,
                    Description = "下午两点到晚上十点"
                },
                new Shift
                {
                    Name = "晚班",
                    Code = "SHIFT-C",
                    StartTime = new TimeSpan(22, 0, 0),
                    EndTime = new TimeSpan(6, 0, 0),
                    IsNightShift = true,
                    WorkingHours = 8,
                    Description = "晚上十点到早上六点"
                }
            );
            context.SaveChanges();
        }

        // Seed Workshops
        if (!context.Workshops.Any())
        {
            context.Workshops.AddRange(
                new Workshop { Name = "冲压车间", Code = "WS001", Oee = 85.3m, Workload = 75.6m },
                new Workshop { Name = "焊接车间", Code = "WS002", Oee = 80.7m, Workload = 68.4m },
                new Workshop { Name = "总装车间", Code = "WS003", Oee = 78.2m, Workload = 82.1m },
                new Workshop { Name = "喷涂车间", Code = "WS004", Oee = 90.1m, Workload = 60.5m },
                new Workshop { Name = "机加车间", Code = "WS005", Oee = 83.0m, Workload = 72.3m },
                new Workshop { Name = "测试车间", Code = "WS006", Oee = 88.6m, Workload = 55.0m },
                new Workshop { Name = "包装车间", Code = "WS007", Oee = 75.4m, Workload = 63.2m },
                new Workshop { Name = "电装车间", Code = "WS008", Oee = 86.5m, Workload = 79.8m },
                new Workshop { Name = "模具车间", Code = "WS009", Oee = 82.9m, Workload = 70.4m },
                new Workshop { Name = "仓储车间", Code = "WS010", Oee = 77.5m, Workload = 50.0m }
            );
            context.SaveChanges();
        }

        // Seed Machines
        if (!context.Machines.Any())
        {
            context.Machines.AddRange(
                new Machine { Code = "MCH-001", Name = "CNC加工中心", Status = MachineStatus.Running, WorkshopId = 1 },
                new Machine { Code = "MCH-002", Name = "激光切割机", Status = MachineStatus.Idle, WorkshopId = 1 },
                new Machine { Code = "MCH-003", Name = "注塑机", Status = MachineStatus.Maintenance, WorkshopId = 2 },
                new Machine { Code = "MCH-004", Name = "冲床", Status = MachineStatus.Running, WorkshopId = 2 },
                new Machine { Code = "MCH-005", Name = "自动包装机", Status = MachineStatus.Running, WorkshopId = 3 },
                new Machine { Code = "MCH-006", Name = "焊接机器人", Status = MachineStatus.Running, WorkshopId = 1 },
                new Machine { Code = "MCH-007", Name = "涂装流水线", Status = MachineStatus.Idle, WorkshopId = 3 },
                new Machine { Code = "MCH-008", Name = "电机测试台", Status = MachineStatus.Maintenance, WorkshopId = 2 },
                new Machine { Code = "MCH-009", Name = "数控铣床", Status = MachineStatus.Running, WorkshopId = 1 },
                new Machine { Code = "MCH-010", Name = "自动分拣系统", Status = MachineStatus.Idle, WorkshopId = 3 }
            );
            context.SaveChanges();
        }
    }
}
