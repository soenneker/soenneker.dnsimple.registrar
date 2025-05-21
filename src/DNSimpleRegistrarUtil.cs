using Microsoft.Extensions.Configuration;
using Soenneker.DNSimple.Registrar.Abstract;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Check;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Premium_price;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Prices;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Registrations;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Registrations.Item;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Renewals;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Transfers;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Transfers.Item;
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.Configuration;

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
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        CheckGetResponse? response = await client[_accountId].Registrar.Domains[domain].Check.GetAsCheckGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<DomainPremiumPrice?> GetDomainPremiumPrice(string domain, string action = "registration",
        CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        Premium_priceGetResponse? response = await client[_accountId]
                                                   .Registrar.Domains[domain]
                                                   .Premium_price.GetAsPremium_priceGetResponseAsync(
                                                       config => config.QueryParameters =
                                                           new Premium_priceRequestBuilder.Premium_priceRequestBuilderGetQueryParameters {Action = action},
                                                       cancellationToken);
        return response?.Data;
    }

    public async ValueTask<DomainPrices?> GetDomainPrices(string domain, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        PricesGetResponse? response =
            await client[_accountId].Registrar.Domains[domain].Prices.GetAsPricesGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<DomainRegistration?> RegisterDomain(string domain, RegistrationsPostRequestBody request,
        CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        RegistrationsPostResponse? response = await client[_accountId]
                                                    .Registrar.Domains[domain]
                                                    .Registrations.PostAsRegistrationsPostResponseAsync(request, cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<DomainRegistration?> GetDomainRegistration(string domain, int registrationId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        WithDomainregistrationGetResponse? response = await client[_accountId]
                                                            .Registrar.Domains[domain]
                                                            .Registrations[registrationId]
                                                            .GetAsWithDomainregistrationGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<DomainTransfer?> TransferDomain(string domain, TransfersPostRequestBody request, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        TransfersPostResponse? response = await client[_accountId]
                                                .Registrar.Domains[domain]
                                                .Transfers.PostAsTransfersPostResponseAsync(request, cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<DomainTransfer?> GetDomainTransfer(string domain, int transferId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        WithDomaintransferGetResponse? response = await client[_accountId]
                                                        .Registrar.Domains[domain]
                                                        .Transfers[transferId]
                                                        .GetAsWithDomaintransferGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<bool> CancelDomainTransfer(string domain, int transferId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        await client[_accountId]
              .Registrar.Domains[domain]
              .Transfers[transferId]
              .DeleteAsWithDomaintransferDeleteResponseAsync(cancellationToken: cancellationToken);
        return true;
    }

    public async ValueTask<DomainRenewal?> RenewDomain(string domain, RenewalsPostRequestBody request, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        RenewalsPostResponse? response = await client[_accountId]
                                               .Registrar.Domains[domain]
                                               .Renewals.PostAsRenewalsPostResponseAsync(request, cancellationToken: cancellationToken);
        return response?.Data;
    }
}