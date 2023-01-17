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

        var actual = maxHeap.Peek();

        Assert.Equal(root, actual);
    }

    [Fact]
    public void Peak_EmptyHeap_ThrowsException()
    {
        var maxHeap = new MaxHeap<int>();

        Assert.Throws<InvalidOperationException>(() => maxHeap.Peek());
    }

    [Theory]
    [InlineData(new[] { 0, 1 }, 1, 0, 1)]
    [InlineData(new[] { 0, 1, 2 }, 2, 1, 2)]
    [InlineData(new[] { 0, 3, 1, 2 }, 3, 2, 3)]
    [InlineData(new[] { 0, 3, 1, 2, 4 }, 4, 3, 4)]
    public void Pop_ReturnsRootAndHeapifies(int[] values, int popped, int newRoot, int newSize)
    {
        var maxHeap = new MaxHeap<int>(values);

        var actualPopped = maxHeap.Pop();
        var actualPeaked = maxHeap.Peek();
        var actualSize = maxHeap.Size;

        Assert.Equal(popped, actualPopped);
        Assert.Equal(newRoot, actualPeaked);
        Assert.Equal(newSize, actualSize);
    }

    [Fact]
    public void Pop_EmptyHeap_ThrowsException()
    {
        var maxHeap = new MaxHeap<int>();

        Assert.Throws<InvalidOperationException>(() => maxHeap.Pop());
    }

    [Theory]
    [InlineData(new[] { 0 }, -1, 0, 2)]
    [InlineData(new[] { 0 }, 1, 1, 2)]
    [InlineData(new[] { 0, 1 }, 2, 2, 3)]
    [InlineData(new[] { 0, 1 }, 1, 1, 3)]
    [InlineData(new[] { 0, 1, 2 }, 1, 2, 4)]
    public void Push_UpdatesRoot(int[] values, int newValue, int newRoot, int newSize)
    {
        var maxHeap = new MaxHeap<int>(values);

        maxHeap.Push(newValue);

        var actualRoot = maxHeap.Peek();
        var actualSize = maxHeap.Size;

        Assert.Equal(newRoot, actualRoot);
        Assert.Equal(newSize, actualSize);
    }
}
