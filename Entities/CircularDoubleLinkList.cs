
//So by what i'm seeing there is no reason to use other LinkList... This one is very complete and to be honesty more easy to manage i guess.
class CircularDoubleLinkList
{
    public NodeDoubleDirect? First;
    public CircularDoubleLinkList() { First = null; }

    public void Create(int[] A, int n)
    {
        int i;
        NodeDoubleDirect last, node = null;
        First = new() { data = A[0] };
        First.next = First;
        last = First;
        for (i = 1; i < n; i++)
        {
            node = new()
            {
                data = A[i],
                next = last.next,
                prev = node ?? First
            };
            last.next = node;
            last = node;
        }
        last.next = First;
        First.prev = last;
    }

    public void Display()
    {
        NodeDoubleDirect node = First;
        do
        {
            System.Console.WriteLine(node.data);
            node = node.next;
        } while (node != First);
    }

    public void Prepend(NodeDoubleDirect newNode)
    {
        NodeDoubleDirect node = First;
        newNode.next = node;
        newNode.prev = node.prev;
        node.prev.next = newNode;
        First = newNode;
    }

    public void Insert(int data, int pos)
    {
        NodeDoubleDirect t = new() { data = data };
        if (pos == 0) { Prepend(t); return; }
        NodeDoubleDirect node = First;
        for (int i = 0; i < pos - 1; i++)
        {
            node = node.next;
            if (node == First) break;
        }

        if (node == First)
        {
            t.next = node;
            t.prev = node.prev;
            node.prev.next = t;
            node.prev = t;
            return;
        };
        t.prev = node;
        t.next = node.next;
        node.next = t;
    }

    public void Delete(int key)
    {
        if (key == First.data)
        {
            First.prev = First.next;
            First.next.prev = First.prev;
            First = First.next;
            return;
        }
        NodeDoubleDirect node = First;
        do
        {
            if (node.data == key) break;
            node = node.next;
        } while (node != First);
        if (node == First && node.data != key) throw new Exception("Element not found");
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    public void Reverse()
    {
        NodeDoubleDirect node = First;
        NodeDoubleDirect temp;
        do
        {
            temp = node.next;
            node.next = node.prev;
            node.prev = temp;
            node = node.prev;
        } while (node != First);

        First = node.next;
    }

}