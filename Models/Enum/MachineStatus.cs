namespace ArERP.Models.Enum;

public enum MachineStatus
{
    Idle,            // 空闲（未使用）
    Running,         // 正在运行
    Starting,        // 正在启动
    Stopping,        // 正在停止
    Maintenance,     // 保养中（计划内）
    Breakdown,       // 故障停机（计划外）
    Standby,         // 等待物料/人员等
    Offline,         // 下线、未联网
    Decommissioned   // 已停用、报废
}