
class Node
{
    public int data { get; set; } = int.MinValue;
    public Node next;
    //O(n) @@@@@ Consider the fact that recursive is a new call in stack for every single
    //call, so tail recursive is not that useful, because is just waste of memory.
}

class NodeCircular<T>
{
    // public User data { get; set; }

    public required T data { get; set; }
    public NodeCircular<T> next;

    public static implicit operator NodeCircular<T>(NodeCircular<int> v)
    {
        throw new NotImplementedException();
    }
}

class NodeDoubleDirect
{
    // public User data { get; set; }

    public required int data { get; set; }
    public NodeDoubleDirect prev;
    public NodeDoubleDirect next;


}

class User
{
    public string Name { get; set; }
    public string Age { get; set; }
}