using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;

public interface IRemoteLogService
{
    Task Info(string message);
    Task Warn(string message);
}
