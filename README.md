# Grid Data Structure in C#
A custom implementation of a 2D grid data structure using linked nodes. This project demonstrates fundamental data structure concepts through a 3×7 node grid where each node maintains references to its four neighbors (top, bottom, left, right).

## Project Overview
This project creates a bidirectional graph structure where 21 nodes are interconnected in a grid pattern. Each node knows its position (File, Rank) and maintains explicit links to adjacent nodes, similar to a doubly-linked list extended to two dimensions.

## Features
- **Node Class**: Core data structure with directional pointers
- **Grid Class**: Manager class for CRUD operations and node manipulation
- **Manual Graph Construction**: Build the grid step-by-step to understand node relationships
- **CRUD Operations**: 
  - **Create**: Insert nodes in any direction
  - **Read**: Select nodes by position
  - **Update**: Modify node properties
  - **Delete**: Remove nodes and their connections

## Grid Structure
```
Row C: C1 - C2 - C3 - C4 - C5 - C6 - C7
       |    |    |    |    |    |    |
Row B: B1 - B2 - B3 - B4 - B5 - B6 - B7
       |    |    |    |    |    |    |
Row A: A1 - A2 - A3 - A4 - A5 - A6 - A7
       ↑
   (Root Node: A1)
```

Each node has four directional pointers:
- **Top**: Points to the node above
- **Bottom**: Points to the node below
- **Right**: Points to the node to the right
- **Left**: Points to the node to the left

## Technologies Used
- **C# (.NET)**: Core programming language
- **Object-Oriented Programming**: Classes, properties, and methods
- **Data Structures**: Linked structures, dictionaries for node tracking

## Installation & Setup

### Prerequisites
- .NET SDK 10.0 or higher

### Steps
1. **Clone the repository**
```bash
git clone <repository-url>
cd data_structure
```

2. **Navigate to the project folder**
```bash
cd data_structure
```

3. **Run the project**
```bash
dotnet run
```

### Building the Project
```bash
dotnet build
```

## Code Structure

### Node Class
```csharp
public class Node
{
    public char File { get; set; }      // Column identifier (A-G)
    public int Rank { get; set; }       // Row identifier (1-7)
    public Node Top { get; set; }       // Link to top neighbor
    public Node Bottom { get; set; }    // Link to bottom neighbor
    public Node Left { get; set; }      // Link to left neighbor
    public Node Right { get; set; }     // Link to right neighbor
}
```

### Grid Class Operations

| Method | Description | Example |
|--------|-------------|---------|
| `InsertTop()` | Links a node above another | `grid.InsertTop(a1, b1)` |
| `InsertBottom()` | Links a node below another | `grid.InsertBottom(b1, a1)` |
| `InsertRight()` | Links a node to the right | `grid.InsertRight(a1, a2)` |
| `InsertLeft()` | Links a node to the left | `grid.InsertLeft(a2, a1)` |
| `Select()` | Retrieves a node by position | `grid.Select('A', 1)` |
| `Update()` | Modifies node properties | `grid.Update('A', 1, 'X', 9)` |
| `Delete()` | Removes a node and its links | `grid.Delete('B', 4)` |
| `DisplayConnections()` | Shows all node neighbors | `grid.DisplayConnections('A', 1)` |
| `DisplayAll()` | Lists all nodes in the grid | `grid.DisplayAll()` |

## Usage Example

```csharp
// Create root node
Node a1 = new Node('A', 1);
Grid grid = new Grid(a1);

// Create and link adjacent nodes
Node a2 = new Node('A', 2);
Node b1 = new Node('B', 1);

// Link horizontally (both directions)
grid.InsertRight(a1, a2);  // a1.Right = a2
grid.InsertLeft(a2, a1);   // a2.Left = a1

// Link vertically (both directions)
grid.InsertTop(a1, b1);    // a1.Top = b1
grid.InsertBottom(b1, a1); // b1.Bottom = a1

// Query the grid
Node node = grid.Select('A', 1);
grid.DisplayConnections('A', 1);
```

## Data Structure Concepts Demonstrated

### 1. Linked Data Structures
- Each node maintains explicit references to neighbors
- No array indexing - navigation through pointer following
- Dynamic structure that can be modified at runtime

### 2. Bidirectional Linking
- Each connection requires two links (e.g., A→B and B→A)
- Enables traversal in all four directions
- Demonstrates the importance of maintaining consistency in linked structures

### 3. Graph Theory
- Nodes represent vertices
- Directional links represent edges
- Grid forms a planar graph with predictable connectivity

### 4. CRUD Operations on Complex Structures
- **Create**: Building connections between nodes
- **Read**: Navigating through node references
- **Update**: Modifying node properties while maintaining structure
- **Delete**: Safely removing nodes and cleaning up references

### 5. Memory Management
- Dictionary for O(1) node lookup
- Manual reference management for node connections
- Understanding pointer/reference semantics

## Project Structure
```
data_structure/                 # Repository root
├── README.md                   # Project documentation
└── data_structure/             # .NET Console project
    ├── Program.cs              # Main code (Node + Grid classes)
    ├── data_structure.csproj   # Project configuration
    ├── bin/                    # Compiled binaries (auto-generated)
    └── obj/                    # Build files (auto-generated)
```

## Learning Outcomes
This project teaches:
- How to implement custom data structures from scratch
- The difference between array-based and pointer-based structures
- Managing complex object relationships
- The importance of careful link management in bidirectional structures
- CRUD operation implementation on non-linear data structures

## Key Design Decisions

### Why Four Separate Insert Functions?
Each insert function creates **only one directional link**, giving complete control over the graph structure. This design:
- Makes relationships explicit
- Prevents accidental bidirectional linking
- Teaches the importance of maintaining symmetry manually
- Mirrors low-level pointer manipulation

### Why Dictionary for Node Storage?
- Provides O(1) lookup by position
- Easier to track all nodes in the grid
- Simplifies Select, Update, and Delete operations
- Alternative to maintaining a 2D array of nodes

## Future Enhancements
- Path finding algorithms (BFS, DFS)
- Shortest path calculation between two nodes
- Visualization of the grid structure
- Support for irregular grid shapes
- Weight/cost properties on connections

## About
This project was created as part of the Tuwaiq Academy Software Development Bootcamp to demonstrate understanding of data structures, specifically linked structures and graph representations. 

The implementation showcases manual graph construction, bidirectional linking, and CRUD operations on a non-trivial data structure using object-oriented programming principles in C#.
