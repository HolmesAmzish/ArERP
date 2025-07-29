using ArERP.Areas.Inventory.Enum;
using ArERP.Areas.Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Data;

public class InventorySeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            #region Warehouse seed data

            if (!context.Warehouses.Any())
            {
                context.Warehouses.AddRange(
                    new Warehouse { Name = "主仓库", Location = "上海", CreationDate = DateTime.Now.AddDays(-30) },
                    new Warehouse { Name = "南区仓库", Location = "广州", CreationDate = DateTime.Now.AddDays(-20) },
                    new Warehouse { Name = "北区仓库", Location = "北京", CreationDate = DateTime.Now.AddDays(-10) },
                    new Warehouse { Name = "海外仓库", Location = "香港", CreationDate = DateTime.Now.AddDays(-5) },
                    new Warehouse { Name = "备件仓库", Location = "成都", CreationDate = DateTime.Now }
                );
                context.SaveChanges();
            }

            #endregion

            #region Item seed data

            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    new Item
                    {
                        Code = "MAT-001",
                        Name = "钢材",
                        Type = ItemType.Material,
                        Unit = "吨",
                        CreateDate = DateTime.Now.AddDays(-20)
                    },
                    new Item
                    {
                        Code = "SEM-001",
                        Name = "电机壳体",
                        Type = ItemType.SemiProduct,
                        Unit = "个",
                        CreateDate = DateTime.Now.AddDays(-15)
                    },
                    new Item
                    {
                        Code = "FIN-001",
                        Name = "组装电机",
                        Type = ItemType.FinishedProduct,
                        Unit = "台",
                        CreateDate = DateTime.Now.AddDays(-10)
                    },
                    new Item
                    {
                        Code = "CON-001",
                        Name = "焊锡丝",
                        Type = ItemType.Consumable,
                        Unit = "卷",
                        CreateDate = DateTime.Now.AddDays(-5)
                    },
                    new Item
                    {
                        Code = "MAT-002",
                        Name = "塑料粒子",
                        Type = ItemType.Material,
                        Unit = "千克",
                        CreateDate = DateTime.Now
                    },
                    new Item
                    {
                        Code = "MAT-003",
                        Name = "铜线",
                        Type = ItemType.Material,
                        Unit = "米",
                        CreateDate = DateTime.Now.AddDays(-18)
                    },
                    new Item
                    {
                        Code = "SEM-002",
                        Name = "电机轴",
                        Type = ItemType.SemiProduct,
                        Unit = "个",
                        CreateDate = DateTime.Now.AddDays(-12)
                    },
                    new Item
                    {
                        Code = "FIN-002",
                        Name = "控制面板",
                        Type = ItemType.FinishedProduct,
                        Unit = "台",
                        CreateDate = DateTime.Now.AddDays(-7)
                    },
                    new Item
                    {
                        Code = "CON-002",
                        Name = "润滑油",
                        Type = ItemType.Consumable,
                        Unit = "升",
                        CreateDate = DateTime.Now.AddDays(-3)
                    },
                    new Item
                    {
                        Code = "MAT-004",
                        Name = "铝材",
                        Type = ItemType.Material,
                        Unit = "吨",
                        CreateDate = DateTime.Now.AddDays(-2)
                    },
                    new Item
                    {
                        Code = "SEM-003",
                        Name = "塑料外壳",
                        Type = ItemType.SemiProduct,
                        Unit = "个",
                        CreateDate = DateTime.Now.AddDays(-9)
                    },
                    new Item
                    {
                        Code = "FIN-003",
                        Name = "电动工具",
                        Type = ItemType.FinishedProduct,
                        Unit = "台",
                        CreateDate = DateTime.Now.AddDays(-1)
                    },
                    new Item
                    {
                        Code = "CON-003",
                        Name = "胶带",
                        Type = ItemType.Consumable,
                        Unit = "卷",
                        CreateDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }

            #endregion

            #region Inventory Balance seed data

            if (!context.InventoryBalances.Any())
            {
                context.AddRange(
                    new InventoryBalance
                    {
                        ItemId = 1, // 钢材
                        WarehouseId = 1, // 主仓库
                        Quantity = 12.5m
                    },
                    new InventoryBalance
                    {
                        ItemId = 2, // 电机壳体
                        WarehouseId = 1, // 主仓库
                        Quantity = 400m
                    },
                    new InventoryBalance
                    {
                        ItemId = 3, // 组装电机
                        WarehouseId = 1, // 主仓库
                        Quantity = 85m
                    },
                    new InventoryBalance
                    {
                        ItemId = 4, // 焊锡丝
                        WarehouseId = 1, // 主仓库
                        Quantity = 32m
                    },
                    new InventoryBalance
                    {
                        ItemId = 1, // 钢材
                        WarehouseId = 2, // 南区仓库
                        Quantity = 8.2m
                    },
                    new InventoryBalance
                    {
                        ItemId = 3, // 组装电机
                        WarehouseId = 2, // 南区仓库
                        Quantity = 120m
                    },
                    new InventoryBalance
                    {
                        ItemId = 5, // 塑料粒子
                        WarehouseId = 2, // 南区仓库
                        Quantity = 560m
                    },
                    new InventoryBalance
                    {
                        ItemId = 2, // 电机壳体
                        WarehouseId = 3, // 北区仓库
                        Quantity = 250m
                    },
                    new InventoryBalance
                    {
                        ItemId = 4, // 焊锡丝
                        WarehouseId = 3, // 北区仓库
                        Quantity = 45m
                    },
                    new InventoryBalance
                    {
                        ItemId = 5, // 塑料粒子
                        WarehouseId = 3, // 北区仓库
                        Quantity = 320m
                    },
                    new InventoryBalance
                    {
                        ItemId = 3, // 组装电机
                        WarehouseId = 4, // 海外仓库
                        Quantity = 200m
                    },
                    new InventoryBalance
                    {
                        ItemId = 4, // 焊锡丝
                        WarehouseId = 5, // 备件仓库
                        Quantity = 18m
                    },
                    new InventoryBalance
                    {
                        ItemId = 5, // 塑料粒子
                        WarehouseId = 5, // 备件仓库
                        Quantity = 150m
                    }
                );

                context.SaveChanges();
            }

            #endregion

            if (!context.Transactions.Any())
            {
                // 先查找几个工单用作关联
                var workOrder1 = context.WorkOrders.FirstOrDefault(wo => wo.OrderNumber == "WO-0001");
                var workOrder2 = context.WorkOrders.FirstOrDefault(wo => wo.OrderNumber == "WO-0002");

                var someWarehouse = context.Warehouses.FirstOrDefault();

                if (workOrder1 != null)
                {
                    var transaction1 = new Transaction
                    {
                        Date = DateTime.UtcNow,
                        Type = TransactionType.ProductionOutputInbound, // 你的枚举，按需求填写
                        SourceId = workOrder1.Id,
                        Lines = new List<TransactionLine>
                        {
                            new TransactionLine
                            {
                                ItemId = workOrder1.ProductItemId,
                                Quantity = 10m,
                                WarehouseId = someWarehouse?.Id
                            }
                        }
                    };
                    context.Transactions.Add(transaction1);
                }

                if (workOrder2 != null)
                {
                    var transaction2 = new Transaction
                    {
                        Date = DateTime.UtcNow,
                        Type = TransactionType.ProductionOutputInbound,
                        SourceId = workOrder2.Id,
                        Lines = new List<TransactionLine>
                        {
                            new TransactionLine
                            {
                                ItemId = workOrder2.ProductItemId,
                                Quantity = 5m,
                                WarehouseId = someWarehouse?.Id
                            }
                        }
                    };
                    context.Transactions.Add(transaction2);
                }

                int controlPanelId = context.Items
                    .Where(i => i.Code == "FIN-002")
                    .Select(i => i.Id)
                    .FirstOrDefault();

                var recentTransactions = new List<Transaction>();

                for (int i = 0; i < 7; i++)
                {
                    recentTransactions.Add(new Transaction
                    {
                        Date = DateTime.UtcNow.Date.AddDays(-i),
                        Type = TransactionType.ProductionOutputInbound,
                        SourceId = null,
                        Lines = new List<TransactionLine>
                        {
                            new TransactionLine
                            {
                                ItemId = controlPanelId,
                                Quantity = 2 + i,
                                WarehouseId = context.Warehouses
                                    .Where(w => w.Name == "主仓库")
                                    .Select(w => w.Id).FirstOrDefault()
                            }
                        }
                    });
                }

                context.Transactions.AddRange(recentTransactions);

                context.SaveChanges();
            }
        }
    }
}