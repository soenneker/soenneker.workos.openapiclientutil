using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.WorkOs.HttpClients.Abstract;
using Soenneker.WorkOs.OpenApiClientUtil.Abstract;
using Soenneker.WorkOs.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.WorkOs.OpenApiClientUtil;

///<inheritdoc cref="IWorkOsOpenApiClientUtil"/>
public sealed class WorkOsOpenApiClientUtil : IWorkOsOpenApiClientUtil
{
    private readonly AsyncSingleton<WorkOsOpenApiClient> _client;

    public WorkOsOpenApiClientUtil(IWorkOsOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<WorkOsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("WorkOs:ApiKey");
            string authHeaderValueTemplate = configuration["WorkOs:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
