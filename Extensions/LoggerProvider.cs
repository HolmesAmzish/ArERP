namespace ArERP.Extensions;

public class SystemLogLoggerProvider : ILoggerProvider
{
    private readonly IServiceProvider _serviceProvider;

    public SystemLogLoggerProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new SystemLogExtensions(categoryName, _serviceProvider);
    }

    public void Dispose() { }
}
