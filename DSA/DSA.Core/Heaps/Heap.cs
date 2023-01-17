using System.Numerics;

namespace DSA.Core.Heaps;

public abstract class Heap<T> where T : INumber<T>
{
    private readonly List<T> _list;

    public int Size => _list.Count;

    public bool IsEmpty => Size == 0;

    public Heap()
    {
        _list = new List<T>();
    }

    public Heap(ICollection<T> values)
    {
        _list = values.ToList();
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
        return _list[GetParentIndex(i)];
    }

    private T GetLeftChild(int i)
    {
        return _list[GetLeftChildIndex(i)];
    }

    private T GetRightChild(int i)
    {
        return _list[GetRightChildIndex(i)];
    }

    private void Swap(int i, int j)
    {
        var temp = _list[i];
        _list[i] = _list[j];
        _list[j] = temp;
    }

    private void HeapifyDown(int start)
    {
        var i = start;
        while (i < Size / 2)
        {
            var l = GetLeftChildIndex(i);
            var leftChild = _list[l];

            var r = GetRightChildIndex(i);
            var hasRightChild = r < Size;

            var priorityChildIndex = hasRightChild && HasPriority(GetRightChild(i), leftChild) ? r : l;
            var priorityChild = _list[priorityChildIndex];

            var current = _list[i];
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
        while (i > 0 && !HasPriority(GetParent(i), _list[i]))
        {
            var p = GetParentIndex(i);
            Swap(i, p);
            i = p;
        }
    }

    protected abstract bool HasPriority(T value1, T value2);

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot peek an empty heap.");

        return _list[0];
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Cannot pop from an empty heap.");

        var root = Peek();

        // set last as root
        _list[0] = _list[Size - 1];
        _list.RemoveAt(Size - 1);

        HeapifyDown(0);

        return root;
    }

    public void Push(T value)
    {
        _list.Add(value);
        HeapifyUp();
    }
}
