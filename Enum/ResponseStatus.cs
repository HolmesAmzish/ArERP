namespace ArERP.Enum
{
    public enum ResponseStatus
    {
        Ok = 200,                     // 成功
        BadRequest = 400,            // 请求格式错误
        Unauthorized = 401,          // 未登录或无权限
        Forbidden = 403,             // 被禁止访问
        NotFound = 404,              // 资源不存在
        Conflict = 409,              // 资源冲突（如用户名重复）
        InternalError = 500,         // 服务器错误
        ServiceUnavailable = 503     // 服务不可用
    }
}