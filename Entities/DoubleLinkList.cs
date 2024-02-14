class DoubleLinkList
{
    public NodeDoubleDirect? First { get; private set; }
    public DoubleLinkList() { First = null; }

    public void CreateDList(int[] A, int n)
    {
        NodeDoubleDirect node, last;
        int i;
        First = new() { data = A[0], next = null };
        last = First;
        for (i = 1; i < n; i++)
        {
            node = new()
            {
                data = A[i],
                next = last.next,
                prev = last
            };
            last.next = node;
            last = node;

        }
    }

    public void Display()
    {
        NodeDoubleDirect node = First;
        while (node != null)
        {
            System.Console.WriteLine(node.data);
            node = node.next;
        }
    }

    public int Length()
    {
        NodeDoubleDirect node = First;
        int count = 0;

        while (node != null)
        {
            count++;
            node = node.next;

        }
        return count;
    }

    //Insert
    public void Prepend(int data)
    {
        NodeDoubleDirect node = new()
        {
            data = data,
            prev = null,
            next = First,
        };
        First.prev = node;
        First = node;
    }
    public void Insert(int data, int pos)
    {
        NodeDoubleDirect node = First, t = new() { data = data };
        if (pos == 0) { Prepend(data); return; }
        for (int i = 0; i < pos - 1 && node.next != null; i++)
            node = node.next;
        if (node.next == null) { t.prev = node; node.next = t; return; };
        t.next = node.next;
        t.prev = node;
        if (node.next != null) node.next.prev = t;
        node.next = t;
    }
    //Delete
    public void Delete(int key)
    {
        if (key == First.data)
        {
            NodeDoubleDirect t = First;
            First = First.next;
            First.prev = null;
            t = null;
        }
        else
        {
            NodeDoubleDirect node = First, q;
            while (node != null)
            {
                if (node.data == key)
                    break;
                node = node.next;
            }
            if (node != null)
            {
                q = node;
                if (node.next != null)
                {
                    node.next.prev = node.prev;
                    node.prev.next = node.next;
                }
                else
                {
                    node = node.prev;
                    node.next = null;
                }
                q = null;
            }
            else throw new Exception("Element not found");
        }
    }

    public void Reverse()
    {
        NodeDoubleDirect node = First;
        NodeDoubleDirect temp;
        while (node != null)
        {
            temp = node.next;
            node.next = node.prev;
            node.prev = temp;
            node = node.prev;
            if (node != null && node.next == null) First = node;
        }
    }

    public NodeDoubleDirect MiddleNode()
    {
        NodeDoubleDirect node = First;
        NodeDoubleDirect follower = First;
        while (node != null)
        {
            node = node.next.next;
            follower = follower.next;
        }
        return follower;
    }
}