[![](https://img.shields.io/nuget/v/soenneker.workos.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.workos.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.workos.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.workos.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.workos.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.workos.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.workos.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.workos.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.WorkOs.OpenApiClientUtil

Provides a cached `WorkOsOpenApiClient` using the configured WorkOS API base address and secret API key.

## Installation

```bash
dotnet add package Soenneker.WorkOs.OpenApiClientUtil
```

## Configuration

```json
{
  "WorkOs": {
    "ApiKey": "sk_example_123456789"
  }
}
```

`WorkOs:ClientBaseUrl` can override the default `https://api.workos.com/` endpoint.

## Registration and usage

```csharp
using Soenneker.WorkOs.OpenApiClient.Models;
using Soenneker.WorkOs.OpenApiClientUtil.Abstract;
using Soenneker.WorkOs.OpenApiClientUtil.Registrars;

services.AddWorkOsOpenApiClientUtilAsSingleton();

public sealed class OrganizationService
{
    private readonly IWorkOsOpenApiClientUtil _clientProvider;

    public OrganizationService(IWorkOsOpenApiClientUtil clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<IReadOnlyList<Organization>> List(
        CancellationToken cancellationToken)
    {
        var client = await _clientProvider.Get(cancellationToken);
        OrganizationList? result = await client.Organizations.GetAsync(
            request => request.QueryParameters.Limit = 10,
            cancellationToken);

        return result?.Data ?? [];
    }
}
```

`AddWorkOsOpenApiClientUtilAsScoped()` creates one generated client per scope while continuing to use the singleton HTTP transport. Disposing the scoped provider does not remove that shared transport.
