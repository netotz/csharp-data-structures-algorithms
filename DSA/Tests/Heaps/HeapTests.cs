using DSA.Core.Heaps;

namespace DSA.Tests.Heaps;

public class HeapTests
{
    [Theory]
    [InlineData(new[] { 0 }, 0)]
    [InlineData(new[] { 0, 1 }, 1)]
    [InlineData(new[] { 0, 1, 2 }, 2)]
    [InlineData(new[] { 0, 3, 1, 2 }, 3)]
    public void Peak_ReturnsRoot(int[] values, int root)
    {
        var maxHeap = new MaxHeap<int>(values);

        var actual = maxHeap.Peak();

        Assert.Equal(root, actual);
    }

    [Theory]
    [InlineData(new[] { 0, 1 }, 1, 0)]
    [InlineData(new[] { 0, 1, 2 }, 2, 1)]
    [InlineData(new[] { 0, 3, 1, 2 }, 3, 2)]
    [InlineData(new[] { 0, 3, 1, 2, 4 }, 4, 3)]
    public void Pop_ReturnsRootAndHeapifies(int[] values, int popped, int newRoot)
    {
        var maxHeap = new MaxHeap<int>(values);

        var actualPopped = maxHeap.Pop();
        var actualPeaked = maxHeap.Peak();

        Assert.Equal(popped, actualPopped);
        Assert.Equal(newRoot, actualPeaked);
    }

    [Theory]
    [InlineData(new[] { 0 }, -1, 0)]
    [InlineData(new[] { 0 }, 1, 1)]
    [InlineData(new[] { 0, 1 }, 2, 2)]
    [InlineData(new[] { 0, 1 }, 1, 1)]
    [InlineData(new[] { 0, 1, 2 }, 1, 2)]
    public void Push_UpdatesRoot(int[] values, int newValue, int newRoot)
    {
        var maxHeap = new MaxHeap<int>(values);

        maxHeap.Push(newValue);

        var actual = maxHeap.Peak();

        Assert.Equal(newRoot, actual);
    }
}
