using System;
using ValueSequencer;
using Xunit;

namespace Test2.Tests;

public class HexagramTests
{
    [Fact]
    public void Add_IncrementsCount()
    {
        Sequences.Initialise();
        var hvs = new CHexagramValueSequencer(0);
        var hex = new CHexagram(ref hvs);

        Assert.Equal(0, hex.Count);
        hex.Add();
        hex.Add();
        Assert.Equal(2, hex.Count);
    }

    [Fact]
    public void CompareTo_UsesHexagramId()
    {
        Sequences.Initialise();
        var hvs1 = new CHexagramValueSequencer(0);
        var hvs2 = new CHexagramValueSequencer(1);

        var hex1 = new CHexagram(ref hvs1);
        var hex2 = new CHexagram(ref hvs2);

        var expected = string.Compare(hvs1.HexagramId(), hvs2.HexagramId(), StringComparison.Ordinal);
        var actual = hex1.CompareTo(hex2);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DescribeCast_RemainsStableAfterOriginalChanges()
    {
        Sequences.Initialise();
        var hvs = new CHexagramValueSequencer(10);
        var expected = hvs.DescribeCast();
        var hex = new CHexagram(ref hvs);

        hvs.Next();

        Assert.Equal(expected, hex.DescribeCast);
    }
}
