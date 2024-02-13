class Node
{
    public int data { get; set; } = int.MinValue;
    public Node next;

    //O(n) @@@@@ Consider the fact that recursive is a new call in stack for every single
    //call, so tail recursive is not that useful, because is just waste of memory.
    public void Create(int[] A, int n)
    {
        int i;
        Node last, node;
        last = this;
        //there is a problem using this, because i cont generate a new instance 
        //every time on node in Program class... I have to return or use pointers 
        data = A[0];
        for (i = 1; i < n; i++)
        {
            node = new()
            {
                data = A[i],
                next = null
            };
            last.next = node;
            last = node;
        }
    }

    public void Display(Node node)
    {
        while (node != null)
        {
            System.Console.WriteLine(node.data);
            node = node.next;
        }
    }

    public int Count(Node node)
    {
        int count = 0;
        while (node != null && node.data != int.MinValue)
        {
            count++;
            node = node.next;
        }
        return count;
    }

    public int CountRecursively(Node node)
    {
        if (node != null)
            return 0;
        else return CountRecursively(node.next) + 1;


    }

    public void DisplayRecursively(Node node)
    {

        if (node != null)
        {
            System.Console.WriteLine(node.data);
            DisplayRecursively(node.next);
            //could do something on returning else 
        }
    }

    public int Add(Node node)
    {
        int sum = 0;
        while (node != null)
        {
            sum += node.data;
            node = node.next;
        }
        return sum;
    }

    public int AddRecursively(Node node)
    {
        if (node != null)
            return AddRecursively(node.next) + node.data;

        return 0;
    }


    public Tuple<int, int> MinMax(Node node)
    {
        int max = node.data;
        int min = node.data;
        while (node != null)
        {
            if (node.data > max) max = node.data;
            if (node.data < min) min = node.data;
            node = node.next;
        }
        return Tuple.Create(max, min);
    }
    public int max { get; private set; } = int.MinValue;
    public int min { get; private set; } = int.MaxValue;
    public Tuple<int, int> MinMaxRecursively(Node node)
    {
        if (node == null) return Tuple.Create(max, min);
        Tuple<int, int> x = MinMaxRecursively(node.next);
        max = max < node.data ? node.data : x.Item1;
        min = min > node.data ? node.data : x.Item2;
        return Tuple.Create(max, min);
    }
    //@@@@@

    //Hmm Binary Search does not work in list, because you can't access the center
    //element, just linear search works.

    public Node Search(Node node, int key)
    {
        while (node != null)
        {
            if (node.data == key) return node;
            node = node.next;
        }
        return null;
    }
    public Node SearchRecursively(Node node, int key)
    {
        if (node == null) return null;
        if (key == node.data) return node;
        return SearchRecursively(node.next, key);
    }
    //So i notice TRANSPOSITION is not worth to use here, at least i could figure out
    //So i think MOVE-TO-HEAD would work, i will try using this to-head approach.
    // I think to-head will work because the first Node is treated as null
    //To contextualize this method is to optimize data search, how this works?
    //when you search for a value and this values is found i return the value
    //and rearrange the array removing the index that key match and prepending the 
    //node as the first element     
    public Node SearchMoveToHead(ref Node node, int key)
    {
        Node oneStepBehindNode = null;
        while (node != null)
        {
            if (node.data == key)
            {
                if (oneStepBehindNode != null)
                {
                    oneStepBehindNode.next = node.next;
                    node.next = this;
                }
                return node;
            }
            oneStepBehindNode = node;
            node = node.next;
        }
        return null;
    }
    public Node SearchMoveToHeadRecursively(ref Node node, int key)
    {
        Node oneStepBehindNode;
        while (node != null)
        {
            oneStepBehindNode = node;
            if (node.data == key)
            {

                oneStepBehindNode.next = node.next;
                node.next = this;

                return node;
            }
            node = node.next;
        }
        return null;
    }


    //Insert
    public void Prepend(ref Node node, int x)
    {
        //O(1)
        Node newNode = new()
        {
            data = x,
            next = node
        };
        node = newNode;

    }
    public void Append(Node node, Node newNode)
    {
        //O(1)
        while (node.next != null)
        {
            node = node.next;
        }
        node.next = newNode;
    }

    public void Insert(Node node, int x, int pos)
    {
        //min O(1)
        int count = Count(node);
        if (count == 0) { Create([x], 1); return; }
        else if (pos == 0) { Prepend(ref node, x); return; }
        Node newNode = new()
        {
            data = x
        };
        if (count <= pos) { Append(node, newNode); return; }
        //max O(n)
        while (pos - 1 > 0)
        {
            node = node.next;
            pos--;
        }
        newNode.next = node.next;
        node.next = newNode;
    }
    public void InsertInSortedList(ref Node node, int data)
    {
        //min O(1)
        //max O(n)
        //there is a problem... If i use only 2 node for this operation
        //i would not be able do prepend, because prepend depends on
        //modify current node not just the next...  
        if (node.data == int.MinValue) { Create([data], 1); return; }
        if (node.data > data) { Prepend(ref node, data); return; }
        Node newNode = new() { data = data, next = null };
        //I have to create a clone for param node
        Node holder = node;
        Node oneStepBehind = node;
        while (node.next != null)
        {
            if (node.next.data > data)
            {
                newNode.next = node.next;
                oneStepBehind.next = newNode;
                node.next = this;
                return;
            }
            oneStepBehind = node;
            node = node.next;
        }
        node = holder;
        Append(node, newNode);
    }

    //Delete
    public void Delete(ref Node node, int key)
    {
        //How this work in C# i know c# has the garbage collector, but how to delete physically from memory the initialized instance?
        //this works?  definitely don't like the concept of garbage collector... 
        Node oneStepBehind = null;
        if (key == node.data) { oneStepBehind = node; node = node.next; oneStepBehind = null; return; }
        bool b = false;
        while (node != null)
        {
            if (node.data == key)
            {
                b = true;
                break;
            }

            oneStepBehind = node;
            node = node.next;
        }
        if (!b)
        {
            node = this;
            return;
        }
        oneStepBehind.next = node.next;
        node.next = this;
        node = node.next;
        // :/
        oneStepBehind = null;
    }
}