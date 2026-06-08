using Microsoft.Extensions.Configuration;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Check;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Prices;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Registrations;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Registrations.Item;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Renewals;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Transfers;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Transfers.Item;
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.DNSimple.Registrar.Abstract;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.Registrar;

/// <inheritdoc cref="IDNSimpleRegistrarUtil"/>
/// <summary>
/// Implementation of the DNSimple registrar utility
/// </summary>
public sealed class DNSimpleRegistrarUtil : IDNSimpleRegistrarUtil
{
    private readonly IDNSimpleOpenApiClientUtil _clientUtil;
    private readonly int _accountId;

    public DNSimpleRegistrarUtil(IDNSimpleOpenApiClientUtil clientUtil, IConfiguration configuration)
    {
        _clientUtil = clientUtil;
        _accountId = configuration.GetValueStrict<int>("DNSimple:AccountId");
    }

    public async ValueTask<DomainCheckResult?> CheckDomainAvailability(string domain, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        CheckDomain200Response? response = await client[_accountId].Registrar.Domains[domain].Check.GetAsync(cancellationToken: cancellationToken).NoSync();
        return response?.Data;
    }

    public async ValueTask<DomainPrices?> GetDomainPrices(string domain, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        GetDomainPrices200Response? response = await client[_accountId].Registrar.Domains[domain].Prices.GetAsync(cancellationToken: cancellationToken).NoSync();

        return response?.Data;
    }

    public async ValueTask RegisterDomain(string domain, int registrantId, CancellationToken cancellationToken = default)
    {
        var request = new DomainRegisterRequest
        {
            RegistrantId = registrantId,
            AutoRenew = true,
            WhoisPrivacy = true
        };

        await RegisterDomain(domain, request, cancellationToken).NoSync();
    }

    public async ValueTask<DomainRegistration?> RegisterDomain(string domain, DomainRegisterRequest request,
        CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        RegisterDomain201Response? response = await client[_accountId]
                                                    .Registrar.Domains[domain]
                                                    .Registrations.PostAsync(request, cancellationToken: cancellationToken)
                                                    .NoSync();
        return response?.Data;
    }

    public async ValueTask<DomainRegistration?> GetDomainRegistration(string domain, int registrationId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        GetDomainRegistration200Response? response = await client[_accountId]
                                                            .Registrar.Domains[domain]
                                                            .Registrations[registrationId]
                                                            .GetAsync(cancellationToken: cancellationToken)
                                                            .NoSync();
        return response?.Data;
    }

    public async ValueTask<DomainTransfer?> TransferDomain(string domain, DomainTransferRequest request, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        TransferDomain201Response? response = await client[_accountId]
                                                .Registrar.Domains[domain]
                                                .Transfers.PostAsync(request, cancellationToken: cancellationToken)
                                                .NoSync();
        return response?.Data;
    }

    public async ValueTask<DomainTransfer?> GetDomainTransfer(string domain, int transferId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        GetDomainTransfer200Response? response = await client[_accountId]
                                                        .Registrar.Domains[domain]
                                                        .Transfers[transferId]
                                                        .GetAsync(cancellationToken: cancellationToken)
                                                        .NoSync();
        return response?.Data;
    }

    public async ValueTask<bool> CancelDomainTransfer(string domain, int transferId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        await client[_accountId].Registrar.Domains[domain].Transfers[transferId].DeleteAsync(cancellationToken: cancellationToken).NoSync();
        return true;
    }

    public async ValueTask<DomainRenewal?> RenewDomain(string domain, DomainRenewRequest request, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        DomainRenew201Response? response = await client[_accountId]
                                               .Registrar.Domains[domain]
                                               .Renewals.PostAsync(request, cancellationToken: cancellationToken)
                                               .NoSync();
        return response?.Data;
    }
}
