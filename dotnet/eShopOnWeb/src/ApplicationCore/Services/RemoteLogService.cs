using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Services;

public class RemoteLogService : IRemoteLogService
{
    static readonly HttpClient client = new();

    public async Task Info(string message)
    {
        await client.GetAsync($"http://localhost:3000/log?log=${message}");
    }

    public async Task Warn(string message)
    {
        await client.GetAsync($"http://localhost:3000/log?log=${message}");
    }
}

