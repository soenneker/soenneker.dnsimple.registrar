using System.Threading;
using System.Threading.Tasks;
using Soenneker.DNSimple.Registrar.Requests;
using Soenneker.DNSimple.Registrar.Responses;

namespace Soenneker.DNSimple.Registrar.Abstract;

/// <summary>
/// A .NET typesafe implementation of DNSimple's Registrar API
/// </summary>
public interface IDNSimpleRegistrarUtil
{
    /// <summary>
    /// Checks if a domain is available for registration.
    /// </summary>
    /// <param name="domain">The domain name to check.</param>
    /// <param name="test">Indicates whether to use a test environment.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The domain availability information.</returns>
    ValueTask<DomainCheckResponse?> CheckDomainAvailability(string domain, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the premium price for a domain.
    /// </summary>
    ValueTask<DomainPremiumPriceResponse?> GetDomainPremiumPrice(string domain, string action = "registration", bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves domain prices.
    /// </summary>
    ValueTask<DomainPricesResponse?> GetDomainPrices(string domain, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Registers a domain.
    /// </summary>
    ValueTask<DomainRegistrationResponse?> RegisterDomain(string domain, DomainRegistrationRequest request, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details of a domain registration.
    /// </summary>
    ValueTask<DomainRegistrationResponse?> GetDomainRegistration(string domain, int registrationId, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Transfers a domain.
    /// </summary>
    ValueTask<DomainTransferResponse?> TransferDomain(string domain, DomainTransferRequest request, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details of a domain transfer.
    /// </summary>
    ValueTask<DomainTransferResponse?> GetDomainTransfer(string domain, int transferId, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a domain transfer.
    /// </summary>
    ValueTask<bool> CancelDomainTransfer(string domain, int transferId, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Renews a domain.
    /// </summary>
    ValueTask<DomainRenewalResponse?> RenewDomain(string domain, DomainRenewalRequest request, bool test = false, CancellationToken cancellationToken = default);
}
