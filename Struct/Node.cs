class Node
{
    public int data { get; set; } = int.MinValue;
    public Node next;
    //O(n) @@@@@ Consider the fact that recursive is a new call in stack for every single
    //call, so tail recursive is not that useful, because is just waste of memory.
}