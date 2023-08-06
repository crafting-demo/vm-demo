using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace Microsoft.eShopWeb.Infrastructure.Logging;

public class LoggerAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;
    private readonly IRemoteLogService _remoteLogService;

    public LoggerAdapter(ILoggerFactory loggerFactory, IRemoteLogService remoteLogService)
    {
        _logger = loggerFactory.CreateLogger<T>();
        _remoteLogService = remoteLogService;
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
        _remoteLogService.Warn(message);
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
        _remoteLogService.Info(message);
    }
}
