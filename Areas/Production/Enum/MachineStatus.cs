namespace ArERP.Areas.Production.Enum;

public enum MachineStatus
{
    Idle,            // 空闲（未使用）
    Running,         // 正在运行
    Maintenance,     // 保养中（计划内）
    Breakdown,       // 故障停机（计划外）
    Decommissioned   // 已停用、报废
}