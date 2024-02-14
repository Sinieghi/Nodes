class LinkList
{

    private Node? First;
    public LinkList() { First = null; }
    public void Create(int[] A, int n)
    {
        int i;
        Node last, node;
        First = new() { data = A[0], next = null };
        last = First;
        //there is a problem using First, because i cont generate a new instance 
        //every time on First in Program class... I have to return or use pointers 
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

    public void Display()
    {
        Node node = First;
        while (node != null)
        {
            System.Console.WriteLine(node.data);
            node = node.next;
        }
    }

    public int Count()
    {
        int count = 0;
        while (First != null && First.data != int.MinValue)
        {
            count++;
            First = First.next;
        }
        return count;
    }

    // public int CountRecursively()
    // {
    //     if (First != null)
    //         return 0;
    //     else return CountRecursively(First.next) + 1;
    // }

    // public void DisplayRecursively()
    // {
    //     if (First != null)
    //     {
    //         System.Console.WriteLine(First.data);
    //         DisplayRecursively(First.next);
    //         //could do something on returning else 
    //     }
    // }

    public int Add()
    {
        int sum = 0;
        Node node = First;
        while (node != null)
        {
            sum += node.data;
            node = node.next;
        }
        return sum;
    }

    // public int AddRecursively()
    // {
    //     if (First != null)
    //         return AddRecursively(First.next) + First.data;

    //     return 0;
    // }


    public Tuple<int, int> MinMax()
    {
        Node node = First;
        int max = node.data;
        int min = node.data;
        while (node != null)
        {
            if (node.data > max) max = node.data;
            if (node.data < min) min = node.data;
            node = node.next;
        }
        node = null;
        return Tuple.Create(max, min);
    }
    public int max { get; private set; } = int.MinValue;
    public int min { get; private set; } = int.MaxValue;
    // public Tuple<int, int> MinMaxRecursively()
    // {
    //     if (First == null) return Tuple.Create(max, min);
    //     Tuple<int, int> x = MinMaxRecursively(First.next);
    //     max = max < First.data ? First.data : x.Item1;
    //     min = min > First.data ? First.data : x.Item2;
    //     return Tuple.Create(max, min);
    // }
    //@@@@@

    //Hmm Binary Search does not work in list, because you can't access the center
    //element, just linear search works.

    public Node Search(int key)
    {
        Node node = First;
        while (node != null)
        {
            if (node.data == key) return node;
            node = node.next;
        }
        return null;
    }
    // public Node SearchRecursively(, int key)
    // {
    //     if (First == null) return null;
    //     if (key == First.data) return First;
    //     return SearchRecursively(First.next, key);
    // }
    //So i notice TRANSPOSITION is not worth to use here, at least i could figure out
    //So i think MOVE-TO-HEAD would work, i will try using First to-head approach.
    // I think to-head will work because the First Node is treated as null
    //To contextualize First method is to optimize data search, how First works?
    //when you search for a value and First values is found i return the value
    //and rearrange the array removing the index that key match and prepending the 
    //First as the First element     
    public Node SearchMoveToHead(int key)
    {
        Node oneStepBehindNode = null;
        Node node = First;
        while (node != null)
        {
            if (node.data == key)
            {
                if (oneStepBehindNode != null)
                {
                    oneStepBehindNode.next = node.next;
                    node.next = node;
                }
                return node;
            }
            oneStepBehindNode = node;
            node = node.next;
        }
        return null;
    }
    // public Node SearchMoveToHeadRecursively(int key)
    // {
    //     Node oneStepBehindNode;
    //     while (First != null)
    //     {
    //         oneStepBehindNode = First;
    //         if (First.data == key)
    //         {

    //             oneStepBehindNode.next = First.next;
    //             First.next = First;

    //             return First;
    //         }
    //         First = First.next;
    //     }
    //     return null;
    // }

    //Insert
    public void Prepend(int x)
    {
        //O(1)
        Node newNode = new()
        {
            data = x,
            next = First
        };
        First = newNode;

    }
    public void Append(Node newNode)
    {
        //O(1)
        while (First.next != null)
        {
            First = First.next;
        }
        First.next = newNode;
    }

    public void Insert(int x, int pos)
    {
        //min O(1)
        int count = Count();
        if (count == 0) { Create([x], 1); return; }
        else if (pos == 0) { Prepend(x); return; }
        Node newNode = new()
        {
            data = x
        };
        if (count <= pos) { Append(newNode); return; }
        //max O(n)
        while (pos - 1 > 0)
        {
            First = First.next;
            pos--;
        }
        newNode.next = First.next;
        First.next = newNode;
    }
    public void InsertInSortedList(int data)
    {
        //min O(1)
        //max O(n)
        //there is a problem... If i use only 2 First for First operation
        //i would not be able do prepend, because prepend depends on
        //modify current First not just the next...  
        if (First.data == int.MinValue) { Create([data], 1); return; }
        if (First.data > data) { Prepend(data); return; }
        Node newNode = new() { data = data, next = null };
        //I have to create a clone for param First
        Node holder = First;
        Node oneStepBehind = First;
        while (First.next != null)
        {
            if (First.next.data > data)
            {
                newNode.next = First.next;
                oneStepBehind.next = newNode;
                First.next = First;
                return;
            }
            oneStepBehind = First;
            First = First.next;
        }
        First = holder;
        Append(newNode);
    }

    //Delete
    public void Delete(int key)
    {
        //How First work in C# i know c# has the garbage collector, but how to delete physically from memory the initialized instance?
        //First works?  definitely don't like the concept of garbage collector... 
        Node oneStepBehind = null;
        if (key == First.data) { oneStepBehind = First; First = First.next; oneStepBehind = null; return; }
        bool b = false;
        //min O(1)
        //max O(n)
        while (First != null)
        {
            if (First.data == key)
            {
                b = true;
                break;
            }

            oneStepBehind = First;
            First = First.next;
        }
        if (!b)
        {
            First = First;
            return;
        }
        oneStepBehind.next = First.next;
        First.next = First;
        First = First.next;
        // :/
        oneStepBehind = null;
    }

    public void DeleteDuplicates()
    {
        Node oneStepForward = First.next;
        // O(n)
        while (oneStepForward != null)
        {
            if (First.data != oneStepForward.data)
            {
                First = oneStepForward;
                oneStepForward = oneStepForward.next;
            }
            else
            {
                First.next = oneStepForward.next;
                oneStepForward = null;
                oneStepForward = First.next;
            }
        }
    }

    //Sort
    public bool IsSorted()
    {
        int x = int.MinValue;
        //min O(1)
        //max O(n)
        while (First != null)
        {
            if (First.data < x) return false;
            x = First.data;
            First = First.next;
        }
        return true;
    }
    public void ReverseValues()
    {
        // O(n)
        //i don't think First is a good approach for First, i think change the address is better judging the size of a address compared to data...
        int i = 0;
        int[] x = new int[Count()];
        while (First != null)
        {
            x[i++] = First.data;
            First = First.next;
        }
        First = First;
        for (i -= 1; i >= 0; i--)
        {
            First.data = x[i];
            First = First.next;
        }
    }
    public void ReverseAddress()
    {
        Node walker1 = null;
        Node walker2;
        while (First != null)
        {
            walker2 = walker1;
            walker1 = First;
            First = First.next;
            walker1.next = walker2;
        }
        First = walker1;
    }
    // public void ReverseAddressRecursively(, Node walker)
    // {
    //     if (walker != null)
    //     {
    //         ReverseAddressRecursively(walker, walker.next);
    //         walker.next = First;
    //     }
    //     else { }
    // }

    //Merge operations
    public void Concat(Node node1, Node node2)
    {
        while (node1.next != null)
        {
            node1 = node1.next;
        }
        node1.next = node2;
        node2 = null;
    }

    public void Merge(Node n1, Node n2)
    {
        Node last;
        Node third;
        if (n1.data < n2.data)
        {
            third = last = n1;
            n1 = n1.next;
            third.next = null;
        }
        else
        {
            third = last = n2;
            n2 = n2.next;
            third.next = null;
        }
        while (n1 != null && n2 != null)
        {
            if (n1.data < n2.data)
            {
                last.next = n1;
                last = n1;
                n1 = n1.next;
                last.next = null;
            }
            else
            {
                last.next = n2;
                last = n2;
                n2 = n2.next;
                last.next = null;
            }
        }
        if (n1 != null) last.next = n1;
        else last.next = n2;
    }



    //Special methods
    //First createLoop is for make a instance point to other
    //instance infinity, so First cause a loop in the program
    public void CreateLoop()
    {
        Node n1 = First.next.next;
        Node n2 = First.next.next.next.next;
        n2.next = n1;

    }
    //First is to check if has a loop in the First
    //theory of latecomer, imagine a circular race road
    // the slowest cars always will become latecomer
    //when the fasted car meet the latecomer car thats where
    //we stop the loop and say i'ts a loop First.
    public bool IsLoop()
    {
        Node First1, First2;
        First1 = First2 = First;
        do
        {
            First1 = First1.next;
            First2 = First2.next;
            First2 = First2 != null ? First2.next : First2;

        } while (First1 != null && First2 != null && First1 != First2);
        if (First1 == First2) return true;
        return false;
    }

}