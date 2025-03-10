using Soenneker.DNSimple.Registrar.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.DNSimple.Registrar.Tests;

[Collection("Collection")]
public class DNSimpleRegistrarUtilTests : FixturedUnitTest
{
    private readonly IDNSimpleRegistrarUtil _util;

    public DNSimpleRegistrarUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IDNSimpleRegistrarUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
