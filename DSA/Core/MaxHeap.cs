using System.Numerics;

namespace DSA.Core;

public class MaxHeap<T> : Heap<T> where T : INumber<T>
{
    public MaxHeap(List<T> values) : base(values) { }

    protected override bool HasPriority(T value1, T value2)
    {
        return value1 >= value2;
    }
}