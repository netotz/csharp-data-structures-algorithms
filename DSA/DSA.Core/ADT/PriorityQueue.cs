namespace DSA.Core.ADT;

public abstract class PriorityQueue<T>
{
    public abstract bool IsEmpty { get; }

    public abstract T Peek();
    public abstract T Pop();
    public abstract void Push(T value);
}
