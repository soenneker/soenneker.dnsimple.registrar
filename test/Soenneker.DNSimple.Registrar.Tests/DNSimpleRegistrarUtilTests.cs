using Soenneker.DNSimple.Registrar.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.DNSimple.Registrar.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class DNSimpleRegistrarUtilTests : HostedUnitTest
{
    private readonly IDNSimpleRegistrarUtil _util;

    public DNSimpleRegistrarUtilTests(Host host) : base(host)
    {
        _util = Resolve<IDNSimpleRegistrarUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
