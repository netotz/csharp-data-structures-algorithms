
using DSA.Core;

public class HeapTests
{
    [Theory]
    [InlineData(new[] { 0 }, 0)]
    [InlineData(new[] { 0, 1 }, 1)]
    [InlineData(new[] { 0, 1, 2 }, 2)]
    [InlineData(new[] { 0, 3, 1, 2 }, 3)]
    public void Peak_ReturnsHighestPriority(int[] values, int root)
    {
        var maxHeap = new MaxHeap<int>(values);

        var actual = maxHeap.Peak();

        Assert.Equal(root, actual);
    }
}
