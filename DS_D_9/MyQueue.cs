public class MyQueue
{
    readonly Stack<int> ints1 = new Stack<int>();
    readonly Stack<int> ints2 = new Stack<int>();

    public void Push(int x)
    {
        if (ints1.Any())
        {
            while (ints1.Any()) { ints2.Push(ints1.Pop()); }
            ints2.Push(x);
            while (ints2.Any()) { ints1.Push(ints2.Pop()); }
        }
        else
        {
            while (ints2.Any()) { ints1.Push(ints2.Pop()); }
            ints1.Push(x);
            while (ints1.Any()) { ints2.Push(ints1.Pop()); }
        }
    }

    public int Pop()
    {
        if (ints1.Any())
        {
            return ints1.Pop();
        }
        return ints2.Pop();
    }

    public int Peek()
    {
        if (ints1.Any())
        {
            return ints1.Peek();
        }
        return ints2.Peek();
    }

    public bool Empty()
    {
        return !ints1.Any() && !ints2.Any();
    }
}