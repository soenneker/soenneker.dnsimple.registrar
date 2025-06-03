using System.Threading;
using System.Threading.Tasks;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Registrations;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Renewals;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Transfers;
using Soenneker.DNSimple.OpenApiClient.Models;

namespace Soenneker.DNSimple.Registrar.Abstract;

/// <summary>
/// Utility class for managing DNSimple registrar operations
/// </summary>
public interface IDNSimpleRegistrarUtil
{
    /// <summary>
    /// Checks domain availability
    /// </summary>
    ValueTask<DomainCheckResult?> CheckDomainAvailability(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets domain premium price
    /// </summary>
    ValueTask<DomainPremiumPrice?> GetDomainPremiumPrice(string domain, string action = "registration", CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets domain prices
    /// </summary>
    ValueTask<DomainPrices?> GetDomainPrices(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Registers a domain
    /// </summary>
    ValueTask RegisterDomain(string domain, int registrantId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Registers a domain
    /// </summary>
    ValueTask<DomainRegistration?> RegisterDomain(string domain, RegistrationsPostRequestBody request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets domain registration details
    /// </summary>
    ValueTask<DomainRegistration?> GetDomainRegistration(string domain, int registrationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Transfers a domain
    /// </summary>
    ValueTask<DomainTransfer?> TransferDomain(string domain, TransfersPostRequestBody request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets domain transfer details
    /// </summary>
    ValueTask<DomainTransfer?> GetDomainTransfer(string domain, int transferId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a domain transfer
    /// </summary>
    ValueTask<bool> CancelDomainTransfer(string domain, int transferId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Renews a domain
    /// </summary>
    ValueTask<DomainRenewal?> RenewDomain(string domain, RenewalsPostRequestBody request, CancellationToken cancellationToken = default);
}