using System;
using System.Collections.Generic;

public class Node
{
    public char File { get; set; }
    public int Rank { get; set; }
    public Node Top { get; set; }
    public Node Bottom { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(char file, int rank)
    {
        File = file;
        Rank = rank;
    }

    public string GetPosition()
    {
        return $"{File}{Rank}";
    }

    public override string ToString()
    {
        return $"Node {GetPosition()}";
    }
}

public class Grid
{
    private Dictionary<string, Node> nodes;
    public Node Root { get; set; }

    public Grid(Node root)
    {
        nodes = new Dictionary<string, Node>();
        Root = root;
        nodes[root.GetPosition()] = root;
    }

    // Insert functions - each only creates ONE link
    public void InsertTop(Node node, Node newNode)
    {
        if (node == null || newNode == null) return;
        node.Top = newNode;
        nodes[newNode.GetPosition()] = newNode;
    }

    public void InsertBottom(Node node, Node newNode)
    {
        if (node == null || newNode == null) return;
        node.Bottom = newNode;
        nodes[newNode.GetPosition()] = newNode;
    }

    public void InsertLeft(Node node, Node newNode)
    {
        if (node == null || newNode == null) return;
        node.Left = newNode;
        nodes[newNode.GetPosition()] = newNode;
    }

    public void InsertRight(Node node, Node newNode)
    {
        if (node == null || newNode == null) return;
        node.Right = newNode;
        nodes[newNode.GetPosition()] = newNode;
    }

    // CRUD - Select (Read)
    public Node Select(char file, int rank)
    {
        string key = $"{file}{rank}";
        return nodes.ContainsKey(key) ? nodes[key] : null;
    }

    // CRUD - Update
    public bool Update(char file, int rank, char newFile, int newRank)
    {
        Node node = Select(file, rank);
        if (node == null) return false;

        // Remove old key
        nodes.Remove(node.GetPosition());

        // Update node
        node.File = newFile;
        node.Rank = newRank;

        // Add with new key
        nodes[node.GetPosition()] = node;
        return true;
    }

    // CRUD - Delete
    public bool Delete(char file, int rank)
    {
        Node node = Select(file, rank);
        if (node == null) return false;

        // Remove connections
        if (node.Top != null) node.Top.Bottom = null;
        if (node.Bottom != null) node.Bottom.Top = null;
        if (node.Left != null) node.Left.Right = null;
        if (node.Right != null) node.Right.Left = null;

        // Remove from dictionary
        nodes.Remove(node.GetPosition());
        return true;
    }

    // Display node connections
    public void DisplayConnections(char file, int rank)
    {
        Node node = Select(file, rank);
        if (node == null)
        {
            Console.WriteLine($"Node {file}{rank} not found.");
            return;
        }

        Console.WriteLine($"Connections for {node.GetPosition()}:");
        Console.WriteLine($"  Top:    {(node.Top != null ? node.Top.GetPosition() : "None")}");
        Console.WriteLine($"  Bottom: {(node.Bottom != null ? node.Bottom.GetPosition() : "None")}");
        Console.WriteLine($"  Left:   {(node.Left != null ? node.Left.GetPosition() : "None")}");
        Console.WriteLine($"  Right:  {(node.Right != null ? node.Right.GetPosition() : "None")}");
        Console.WriteLine();
    }

    // Display all nodes
    public void DisplayAll()
    {
        Console.WriteLine($"Total nodes in grid: {nodes.Count}");
        foreach (var node in nodes.Values)
        {
            Console.WriteLine($"  {node.GetPosition()}");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        // Create all nodes
        Node a1 = new Node('A', 1);
        Node a2 = new Node('A', 2);
        Node a3 = new Node('A', 3);
        Node a4 = new Node('A', 4);
        Node a5 = new Node('A', 5);
        Node a6 = new Node('A', 6);
        Node a7 = new Node('A', 7);

        Node b1 = new Node('B', 1);
        Node b2 = new Node('B', 2);
        Node b3 = new Node('B', 3);
        Node b4 = new Node('B', 4);
        Node b5 = new Node('B', 5);
        Node b6 = new Node('B', 6);
        Node b7 = new Node('B', 7);

        Node c1 = new Node('C', 1);
        Node c2 = new Node('C', 2);
        Node c3 = new Node('C', 3);
        Node c4 = new Node('C', 4);
        Node c5 = new Node('C', 5);
        Node c6 = new Node('C', 6);
        Node c7 = new Node('C', 7);

        // Create grid with root node a1
        Grid grid = new Grid(a1);

        // Link row A horizontally
        grid.InsertRight(a1, a2);
        grid.InsertRight(a2, a3);
        grid.InsertRight(a3, a4);
        grid.InsertRight(a4, a5);
        grid.InsertRight(a5, a6);
        grid.InsertRight(a6, a7);

        grid.InsertLeft(a7, a6);
        grid.InsertLeft(a6, a5);
        grid.InsertLeft(a5, a4);
        grid.InsertLeft(a4, a3);
        grid.InsertLeft(a3, a2);
        grid.InsertLeft(a2, a1);

        // Link row B horizontally
        grid.InsertRight(b1, b2);
        grid.InsertRight(b2, b3);
        grid.InsertRight(b3, b4);
        grid.InsertRight(b4, b5);
        grid.InsertRight(b5, b6);
        grid.InsertRight(b6, b7);

        grid.InsertLeft(b7, b6);
        grid.InsertLeft(b6, b5);
        grid.InsertLeft(b5, b4);
        grid.InsertLeft(b4, b3);
        grid.InsertLeft(b3, b2);
        grid.InsertLeft(b2, b1);

        // Link row C horizontally
        grid.InsertRight(c1, c2);
        grid.InsertRight(c2, c3);
        grid.InsertRight(c3, c4);
        grid.InsertRight(c4, c5);
        grid.InsertRight(c5, c6);
        grid.InsertRight(c6, c7);

        grid.InsertLeft(c7, c6);
        grid.InsertLeft(c6, c5);
        grid.InsertLeft(c5, c4);
        grid.InsertLeft(c4, c3);
        grid.InsertLeft(c3, c2);
        grid.InsertLeft(c2, c1);

        // Link vertically: A to B to C
        grid.InsertTop(a1, b1);
        grid.InsertTop(b1, c1);
        grid.InsertTop(a2, b2);
        grid.InsertTop(b2, c2);
        grid.InsertTop(a3, b3);
        grid.InsertTop(b3, c3);
        grid.InsertTop(a4, b4);
        grid.InsertTop(b4, c4);
        grid.InsertTop(a5, b5);
        grid.InsertTop(b5, c5);
        grid.InsertTop(a6, b6);
        grid.InsertTop(b6, c6);
        grid.InsertTop(a7, b7);
        grid.InsertTop(b7, c7);

        grid.InsertBottom(c1, b1);
        grid.InsertBottom(b1, a1);
        grid.InsertBottom(c2, b2);
        grid.InsertBottom(b2, a2);
        grid.InsertBottom(c3, b3);
        grid.InsertBottom(b3, a3);
        grid.InsertBottom(c4, b4);
        grid.InsertBottom(b4, a4);
        grid.InsertBottom(c5, b5);
        grid.InsertBottom(b5, a5);
        grid.InsertBottom(c6, b6);
        grid.InsertBottom(b6, a6);
        grid.InsertBottom(c7, b7);
        grid.InsertBottom(b7, a7);

        // Display the grid
        Console.WriteLine("Full 3x7 Grid created!");
        grid.DisplayAll();

        // Test connections - verify bidirectional links
        Console.WriteLine("Root node (A1) connections:");
        grid.DisplayConnections('A', 1);

        Console.WriteLine("A2 connections:");
        grid.DisplayConnections('A', 2);

        Console.WriteLine("Middle node (B4):");
        grid.DisplayConnections('B', 4);

        Console.WriteLine("C1 connections:");
        grid.DisplayConnections('C', 1);

        Console.WriteLine("Top right corner (C7):");
        grid.DisplayConnections('C', 7);
    }
}
