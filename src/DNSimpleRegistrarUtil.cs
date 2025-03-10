using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.DNSimple.Client.Abstract;
using Soenneker.DNSimple.Registrar.Abstract;
using Soenneker.DNSimple.Registrar.Requests;
using Soenneker.DNSimple.Registrar.Responses;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.DNSimple.Registrar;

/// <inheritdoc cref="IDNSimpleRegistrarUtil"/>
public class DNSimpleRegistrarUtil : IDNSimpleRegistrarUtil
{
    private readonly IDNSimpleClientUtil _clientUtil;
    private readonly ILogger<DNSimpleRegistrarUtil> _logger;

    private readonly string _accountId;

    public DNSimpleRegistrarUtil(IDNSimpleClientUtil clientUtil, IConfiguration configuration, ILogger<DNSimpleRegistrarUtil> logger)
    {
        _clientUtil = clientUtil;
        _logger = logger;
        _accountId = configuration.GetValueStrict<string>("DNSimple:AccountId");
    }

    public async ValueTask<DomainCheckResponse?> CheckDomainAvailability(string domain, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/check";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainCheckResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    public async ValueTask<DomainPremiumPriceResponse?> GetDomainPremiumPrice(string domain, string action = "registration", bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/premium_price?action={action}";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainPremiumPriceResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    public async ValueTask<DomainPricesResponse?> GetDomainPrices(string domain, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/prices";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainPricesResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    public async ValueTask<DomainRegistrationResponse?> RegisterDomain(string domain, DomainRegistrationRequest request, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/registrations";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainRegistrationResponse>(HttpMethod.Post, endpoint, request, _logger, cancellationToken);
    }

    public async ValueTask<DomainRegistrationResponse?> GetDomainRegistration(string domain, int registrationId, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/registrations/{registrationId}";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainRegistrationResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    public async ValueTask<DomainTransferResponse?> TransferDomain(string domain, DomainTransferRequest request, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/transfers";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainTransferResponse>(HttpMethod.Post, endpoint, request, _logger, cancellationToken);
    }

    public async ValueTask<DomainTransferResponse?> GetDomainTransfer(string domain, int transferId, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/transfers/{transferId}";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainTransferResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    public async ValueTask<bool> CancelDomainTransfer(string domain, int transferId, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/transfers/{transferId}";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return (await client.SendToType<DomainTransferResponse>(HttpMethod.Delete, endpoint, null, _logger, cancellationToken)) != null;
    }

    public async ValueTask<DomainRenewalResponse?> RenewDomain(string domain, DomainRenewalRequest request, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/renewals";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainRenewalResponse>(HttpMethod.Post, endpoint, request, _logger, cancellationToken);
    }
}
