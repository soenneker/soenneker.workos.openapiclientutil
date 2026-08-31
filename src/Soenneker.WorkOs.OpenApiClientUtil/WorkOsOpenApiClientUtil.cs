using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.WorkOs.HttpClients.Abstract;
using Soenneker.WorkOs.OpenApiClientUtil.Abstract;
using Soenneker.WorkOs.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.WorkOs.OpenApiClientUtil;

public sealed class WorkOsOpenApiClientUtil : IWorkOsOpenApiClientUtil
{
    private readonly AsyncSingleton<WorkOsOpenApiClient> _client;

    public WorkOsOpenApiClientUtil(IWorkOsOpenApiHttpClient httpClientProvider)
    {
        _client = new AsyncSingleton<WorkOsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientProvider.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new WorkOsOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<WorkOsOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
