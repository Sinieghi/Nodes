class CircularLinkList
{
    public Node? First { get; private set; }
    public CircularLinkList() { First = null; }
    public void CreateCircularList(int[] A, int n)
    {
        int i;
        Node last, node;
        First = new() { data = A[0] };
        First.next = First;
        last = First;
        for (i = 1; i < n; i++)
        {
            node = new()
            {
                data = A[i],
                next = last.next
            };
            last.next = node;
            last = node;
        }
    }
    public void DisplayCircularList()
    {
        if (First == null) throw new Exception("At least 1 element");
        Node node = First;
        do
        {
            System.Console.WriteLine(node.data);
            node = node.next;
        } while (node != First);
    }
    public int Length()
    {
        Node node = First;
        int count = 0;
        do
        {
            count++;
            node = node.next;
        } while (node != First);
        return count;
    }
    // private int flag = 0;
    // public void DisplayCircularListRecursively(Node node)
    // {

    //     if (First == null) throw new Exception("Has to be more at least 1 element");
    //     if (node != First || flag == 0)
    //     {
    //         flag = 1;
    //         DisplayCircularListRecursively(node);
    //     }
    //     flag = 0;
    // }

    //Inset
    public void Prepend(Node newNode)
    {
        Node node = First;

        while (node.next != First) node = node.next;
        node.next = newNode;
        newNode.next = First;
        First = newNode;
    }
    public void Insert(int data, int pos)
    {
        Node t, node;
        if (pos == 0 || First == null)
        {
            t = new() { data = data };
            if (First == null) CreateCircularList([data], 1);
            else Prepend(t);
        }
        else
        {
            node = First;
            for (int i = 0; i < pos - 1; i++)
            {
                if (node.next == First) break;
                node = node.next;
            }
            t = new() { data = data, next = node.next };
            node.next = t;
        }
    }

    //Delete
    public void Delete(int key)
    {
        Node node, t;
        if (key == First.data)
        {
            node = First;
            while (node.next != First) node = node.next;
            if (node == First) First = null;
            else
            {
                node.next = First.next;
                First = null;
                First = node.next;
            }
        }
        else
        {
            node = First;
            t = node;
            while (node.next != First && node.next.data != key) { node = node.next; }

            if (node.next == First && node.data != key) throw new Exception("Element not found");
            t = node.next;
            node.next = t.next;
        }
    }
}