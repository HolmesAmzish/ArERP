namespace ArERP.Areas.Inventory.Models;

public enum TransactionType
{
    PurchaseInbound,       // 采购入库
    PurchaseReturnOutbound, // 采购退货出库

    SalesOutbound,         // 销售发货出库
    SalesReturnInbound,    // 销售退货入库

    ProductionMaterialIssue, // 生产领料出库
    ProductionOutputInbound, // 生产完工入库

    TransferOutbound,      // 仓库调出
    TransferInbound,       // 仓库调入

    InventoryIncreaseAdjustment, // 盘盈
    InventoryDecreaseAdjustment, // 盘亏

    ScrapOutbound,         // 报废出库

    ManualInbound,         // 手工入库
    ManualOutbound         // 手工出库
}