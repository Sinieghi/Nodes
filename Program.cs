class Program
{

    static void Main(string[] args)
    {
        int[] A = [1, 2, 4, 5, 6, 33, 51, 99];
        int[] A2 = [17, 21, 22, 29, 31, 37, 79, 95];
        //migrate to new class
        LinkList node = new();
        LinkList node1 = new();
        node.Create(A, 8);
        node1.Create(A2, 8);
        // node.Display();
        // node.DisplayRecursively(node);
        System.Console.WriteLine("Sums of our list");
        System.Console.WriteLine(node.Add());
        // System.Console.WriteLine(node.AddRecursively(node));
        // System.Console.WriteLine("Min Max");
        // System.Console.WriteLine(node.MinMax(node));
        // System.Console.WriteLine(node.MinMaxRecursively(node));
        // System.Console.WriteLine("Search for given key");
        // Node parse = node.Search(node, 51);
        // Node parseR = node.SearchRecursively(node, 51);
        // if (parse != null) System.Console.WriteLine(parse.data);
        // if (parseR != null) System.Console.WriteLine(parseR.data);
        // System.Console.WriteLine("Search for given key and move to head");
        // System.Console.WriteLine(node.SearchMoveToHead(ref node, 51).data);
        // System.Console.WriteLine(node.SearchMoveToHead(ref node, 5).data);
        // node.Prepend(15);
        // node.Insert(node, 35, 9);
        // node.Insert(node, 35, 10);
        // node.Insert(node, 35, 11);
        // node.Insert(1000, 5);
        // node.Insert(1000, 6);
        // node.Insert(1000, 7);
        // System.Console.WriteLine(node.IsSorted(node));
        // node.InsertInSortedList(ref node, 500);
        // node.InsertInSortedList(ref node, 3);
        // System.Console.WriteLine(node.IsSorted(node));
        // node.Delete(1000);
        node.DeleteDuplicates();
        // node.ReverseValues(node);
        // node.Concat(node1.First);
        // node.ReverseAddress();
        node.Merge(node1.First);
        // node.ReverseAddressRecursively(null, node);

        node.Display();

        //danger one, don't uncomment with other iterated method this will cause infinity loop @@@@
        node.CreateLoop();
        System.Console.WriteLine(node.IsLoop());
        //@@@@@


        // System.Console.WriteLine("Rearranged nodes: ");
        // node.DisplayRecursively(node);
    }
}