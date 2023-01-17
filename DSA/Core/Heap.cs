using System.Numerics;

namespace DSA.Core;

public abstract class Heap<T> where T : INumber<T>
{
    private readonly List<T> _list;

    public int Size => _list.Count;

    public Heap(List<T> values)
    {
        _list = values;
        Build();
    }

    protected abstract bool HasPriority(T value1, T value2);

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
            var current = _list[i];

            var l = GetLeftChildIndex(i);
            var leftChild = _list[l];

            var r = GetRightChildIndex(i);
            var rightChild = _list[r];

            if (HasPriority(current, leftChild) && HasPriority(current, rightChild))
            {
                break;
            }

            if (HasPriority(leftChild, rightChild))
            {
                Swap(i, l);
                i = l;
            }
            else
            {
                Swap(i, r);
                i = r;
            }
        }
    }

    private void HeapifyUp(int start)
    {
        var i = start;
        while (i > 0)
        {
            var current = _list[i];

            var p = GetParentIndex(i);
            var parent = _list[p];

            if (HasPriority(parent, current))
            {
                break;
            }

            Swap(i, p);
            i = p;
        }
    }

    public T Peak()
    {
        return _list[0];
    }

    public T Pop()
    {
        var root = _list[0];

        // swap with last
        Swap(0, Size - 1);
        _list.RemoveAt(Size - 1);

        HeapifyDown(0);

        return root;
    }

    public void Push(T value)
    {
        _list.Add(value);
        HeapifyUp(Size - 1);
    }
}
