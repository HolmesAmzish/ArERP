using ArERP.Service;

namespace ArERP.Extensions;

public class SystemLogExtensions : ILogger
{
    private readonly string _categoryName;
    private readonly IServiceProvider _serviceProvider;

    public SystemLogExtensions(string categoryName, IServiceProvider serviceProvider)
    {
        _categoryName = categoryName;
        _serviceProvider = serviceProvider;
    }

    public IDisposable BeginScope<TState>(TState state) => null!;
    
    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception exception,
        Func<TState, Exception?, string> formatter)
    {
        using var scope = _serviceProvider.CreateScope();
        var logService = scope.ServiceProvider.GetRequiredService<ISystemLogService>();
        var message = formatter(state, exception);

        switch (logLevel)
        {
            case LogLevel.Information:
                logService.Info(message);
                break;
        }
    }
}