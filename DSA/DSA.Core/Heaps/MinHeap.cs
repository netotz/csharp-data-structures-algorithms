using System.Numerics;

namespace DSA.Core.Heaps;

public class MinHeap<T> : Heap<T> where T : INumber<T>
{
    public MinHeap() : base() { }

    public MinHeap(ICollection<T> values) : base(values) { }

    protected override bool HasPriority(T value1, T value2)
    {
        return value1 <= value2;
    }
}