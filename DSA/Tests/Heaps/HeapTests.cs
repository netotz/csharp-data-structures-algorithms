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
    [InlineData(new[] { 0, 1 }, 1, 0)]
    [InlineData(new[] { 0, 1, 2 }, 2, 1)]
    [InlineData(new[] { 0, 3, 1, 2 }, 3, 2)]
    [InlineData(new[] { 0, 3, 1, 2, 4 }, 4, 3)]
    public void Pop_ReturnsRootAndHeapifies(int[] values, int popped, int newRoot)
    {
        var maxHeap = new MaxHeap<int>(values);

        var actualPopped = maxHeap.Pop();
        var actualPeaked = maxHeap.Peek();

        Assert.Equal(popped, actualPopped);
        Assert.Equal(newRoot, actualPeaked);
    }

    [Fact]
    public void Pop_EmptyHeap_ThrowsException()
    {
        var maxHeap = new MaxHeap<int>();

        Assert.Throws<InvalidOperationException>(() => maxHeap.Pop());
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

        var actual = maxHeap.Peek();

        Assert.Equal(newRoot, actual);
    }
}
