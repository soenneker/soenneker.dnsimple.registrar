[![](https://img.shields.io/nuget/v/soenneker.dnsimple.registrar.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.registrar/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.registrar/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.registrar/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dnsimple.registrar.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.registrar/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.registrar/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.registrar/actions/workflows/codeql.yml)

# Soenneker.DNSimple.Registrar

Checks domain availability and prices, registers and renews domains, and manages DNSimple domain transfers.

## Installation

```bash
dotnet add package Soenneker.DNSimple.Registrar
```

## Configuration and registration

```json
{
  "DNSimple": {
    "AccountId": 12345,
    "Token": "your-api-token",
    "Test": true
  }
}
```

```csharp
using Soenneker.DNSimple.Registrar.Registrars;

services.AddDNSimpleRegistrarUtilAsScoped();
```

Use the DNSimple sandbox while testing registration, transfer, or renewal workflows.

## Check and register a domain

```csharp
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.DNSimple.Registrar.Abstract;

DomainCheckResult? availability =
    await registrar.CheckDomainAvailability("example.com", cancellationToken);

DomainPrices? prices =
    await registrar.GetDomainPrices("example.com", cancellationToken);

var request = new DomainRegisterRequest
{
    RegistrantId = contactId,
    AutoRenew = false,
    WhoisPrivacy = true
};

DomainRegistration? registration =
    await registrar.RegisterDomain("example.com", request, cancellationToken);
```

The `RegisterDomain(string, int, ...)` convenience overload automatically enables both auto-renewal and WHOIS privacy. Use the `DomainRegisterRequest` overload when those settings must be explicit.

Registration, transfer, renewal, and cancellation are billable or state-changing operations. Check availability and pricing first, use idempotency controls provided by your application where appropriate, and persist the returned registration or transfer IDs for later status calls.
