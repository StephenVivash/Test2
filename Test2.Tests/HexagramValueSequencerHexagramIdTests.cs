using ValueSequencer;
using Xunit;

namespace Test2.Tests;

public class HexagramValueSequencerHexagramIdTests
{
    [Fact]
    public void HexagramId_ReflectsSequence()
    {
        Sequences.Initialise();
        var first = new CHexagramValueSequencer(0);
        var second = new CHexagramValueSequencer(1);

        Assert.NotEqual(first.HexagramId(), second.HexagramId());
    }

    [Fact]
    public void HexagramId_AddsMovingLineSuffixWhenLinesMove()
    {
        Sequences.Initialise();
        var hvs = new CHexagramValueSequencer(0);

        var baseId = hvs.HexagramId();
        hvs.Trigram(0).Line(0).Next(true);
        var movingId = hvs.HexagramId();

        Assert.DoesNotContain('.', baseId);
        Assert.Contains('.', movingId);
    }
}
