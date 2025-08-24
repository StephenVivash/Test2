using ValueSequencer;
using Xunit;

namespace Test2.Tests;

public class HexagramCopyConstructorTests
{
    [Fact]
    public void CopyConstructor_CreatesIndependentCopy()
    {
        var original = new CHexagramValueSequencer(42);

        var originalValues = new int[2, 3];
        for (int t = 0; t < 2; t++)
        {
            for (int l = 0; l < 3; l++)
            {
                originalValues[t, l] = original.Trigram(t).Line(l).Value;
            }
        }

        var copy = new CHexagramValueSequencer(ref original);

        for (int t = 0; t < 2; t++)
        {
            for (int l = 0; l < 3; l++)
            {
                Assert.Equal(originalValues[t, l], copy.Trigram(t).Line(l).Value);
            }
        }

        var line = original.Trigram(0).Line(0);
        line.Value = line.Value == 1 ? 2 : 1;
        line.UpdateInnerValues();
        line.UpdateOuterValues();

        Assert.NotEqual(originalValues[0, 0], original.Trigram(0).Line(0).Value);
        for (int t = 0; t < 2; t++)
        {
            for (int l = 0; l < 3; l++)
            {
                Assert.Equal(originalValues[t, l], copy.Trigram(t).Line(l).Value);
            }
        }
    }
}
