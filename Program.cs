class Program
{

    static void Main(string[] args)
    {
        int[] A = [1, 2, 4, 5, 6, 33, 51, 99];
        Node node = new();
        node.Create(A, 8);
        // node.Display(node);
        // node.DisplayRecursively(node);
        // System.Console.WriteLine("Sums of our list");
        // System.Console.WriteLine(node.Add(node));
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
        // node.Prepend(ref node, 15);
        // node.Insert(node, 1000, 11);
        node.InsertInSortedList(ref node, 500);
        node.InsertInSortedList(ref node, 3);
        node.Delete(ref node, 500);
        System.Console.WriteLine("Rearranged nodes: ");
        node.DisplayRecursively(node);
    }
}