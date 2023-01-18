using System.Numerics;
using DSA.Core.ADT;

namespace DSA.Core.Heaps;

public abstract class Heap<T> : PriorityQueue<T> where T : INumber<T>
{
    private readonly IList<T> _values;

    public int Size => _values.Count;

    public override bool IsEmpty => Size == 0;

    public Heap()
    {
        _values = new List<T>();
    }

    public Heap(ICollection<T> values)
    {
        _values = values.ToList();
        Build();
    }

    private void Build()
    {
        for (var i = (Size / 2) - 1; i >= 0; i--)
        {
            // O(log n)
            HeapifyDown(i);
        }
    }

    private int GetParentIndex(int i)
    {
        return (i - 1) / 2;
    }

    private int GetLeftChildIndex(int i)
    {
        return (i * 2) + 1;
    }

    private int GetRightChildIndex(int i)
    {
        return (i * 2) + 2;
    }

    private T GetParent(int i)
    {
        return _values[GetParentIndex(i)];
    }

    private T GetLeftChild(int i)
    {
        return _values[GetLeftChildIndex(i)];
    }

    private T GetRightChild(int i)
    {
        return _values[GetRightChildIndex(i)];
    }

    private void Swap(int i, int j)
    {
        var temp = _values[i];
        _values[i] = _values[j];
        _values[j] = temp;
    }

    private void HeapifyDown(int start)
    {
        var i = start;
        while (i < Size / 2)
        {
            var l = GetLeftChildIndex(i);
            var leftChild = _values[l];

            var r = GetRightChildIndex(i);
            var hasRightChild = r < Size;

            var priorityChildIndex = hasRightChild && HasPriority(GetRightChild(i), leftChild) ? r : l;
            var priorityChild = _values[priorityChildIndex];

            var current = _values[i];
            if (HasPriority(current, priorityChild))
            {
                break;
            }

            Swap(i, priorityChildIndex);
            i = priorityChildIndex;
        }
    }

    private void HeapifyUp()
    {
        var i = Size - 1;
        while (i > 0 && !HasPriority(GetParent(i), _values[i]))
        {
            var p = GetParentIndex(i);
            Swap(i, p);
            i = p;
        }
    }

    protected abstract bool HasPriority(T value1, T value2);

    public override T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot peek an empty heap.");

        return _values[0];
    }

    public override T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot pop from an empty heap.");

        var root = Peek();

        // set last as root
        _values[0] = _values[Size - 1];
        _values.RemoveAt(Size - 1);

        HeapifyDown(0);

        return root;
    }

    public override void Push(T value)
    {
        _values.Add(value);
        HeapifyUp();
    }
}
