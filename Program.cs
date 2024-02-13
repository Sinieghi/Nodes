class Program
{

    static void Main(string[] args)
    {
        int[] A = [1, 2, 3, 4, 5, 33, 51, 99];
        Node node = new();
        node.Create(A, 8);
        node.Display(node);
        node.DisplayRecursively(node);
        System.Console.WriteLine("Sums of our list");
        System.Console.WriteLine(node.Add(node));
        System.Console.WriteLine(node.AddRecursively(node));
        System.Console.WriteLine("Min Max");
        System.Console.WriteLine(node.MinMax(node));
        System.Console.WriteLine(node.MinMaxRecursively(node));
        System.Console.WriteLine("Search for given key");
        System.Console.WriteLine(node.Search(node, 51).data);
        System.Console.WriteLine(node.SearchRecursively(node, 51).data);
        System.Console.WriteLine("Search for given key and move to head");
        System.Console.WriteLine(node.SearchMoveToHead(ref node, 51).data);
        System.Console.WriteLine(node.SearchMoveToHead(ref node, 5).data);
        node.Prepend(ref node, 15);
        node.Insert(node, 1000, 11);
        System.Console.WriteLine("Rearranged nodes: ");
        node.DisplayRecursively(node);
    }
}