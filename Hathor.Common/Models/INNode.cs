namespace Hathor.Common.Models
{
    public interface INNode
    {
        /// <summary>
        /// A node is a structure which may contain connections to other nodes called links.
        /// Also called edges.
        /// </summary>
        IEnumerable<INNode> Links { get; }

        /// <summary>
        /// All nodes have exactly one parent, except the topmost root node, which has none.
        /// A node that has a child is called the child's parent node.
        /// Parent is also called superior.
        /// </summary>
        INNode? Parent { get; }

        /// <summary>
        /// Each node in a tree has zero or more child nodes.
        /// </summary>
        IEnumerable<INNode> Children { get; }

        /// <summary>
        /// Ancestor, a node reachable by repeated proceeding from child to parent.
        /// </summary>
        IEnumerable<INNode> Ancestors { get; }

        /// <summary>
        /// Descendant, a node reachable by repeated proceeding from parent to child. Also known as subchild.
        /// </summary>
        IEnumerable<INNode> Descendants { get; }

        /// <summary>
        /// The topmost node is the root node.
        /// This node has no parents.
        /// </summary>
        INNode Root { get; }

        /// <summary>
        /// A parent node has one or more children.
        /// A parent node is not a terminal node.
        /// </summary>
        bool IsParent { get; }

        /// <summary>
        /// A root node is the topmost node.
        /// A root node has no parents.
        /// </summary>
        bool IsRoot { get; }

        /// <summary>
        /// A branch node is any node of a tree that has child nodes.
        /// Also known as an inner node, inode for short, or internal node.
        /// </summary>
        bool IsBranchNode { get; }

        /// <summary>
        /// A terminal node is any node that does not have child nodes.
        /// Also known as an outer node, leaf node, or external node.
        /// </summary>
        bool IsTerminalNode { get; }

        /// <summary>
        /// The height of a node is the length of the longest downward path to a leaf from that node.
        /// The height of the root is the height of the tree.
        /// </summary>
        ulong Height { get; }

        /// <summary>
        /// The depth of a node is the length of the path to its root (i.e., its root path).
        /// </summary>
        ulong Depth { get; }

        /// <summary>
        /// For a given node, its number of children. A leaf has necessarily degree zero.
        /// </summary>
        ulong Degree { get; }

        /// <summary>
        /// The degree of a tree is the maximum degree of a node in the tree.
        /// </summary>
        ulong DegreeOfTree { get; }

        /// <summary>
        /// The number of edges along the shortest path between two nodes.
        /// </summary>
        ulong Distance { get; }

        /// <summary>
        /// The level of a node is the number of edges along the unique path between it and the root node.
        /// This is the same as depth when using zero-based counting.
        /// </summary>
        ulong Level { get; }

        /// <summary>
        /// The number of nodes in a level.
        /// </summary>
        ulong Width { get; }

        /// <summary>
        /// The number of leaves.
        /// </summary>
        ulong Breadth { get; }

        /// <summary>
        /// Number of nodes in the tree.
        /// </summary>
        ulong Size { get; }

        /// <summary>
        /// When using zero-based counting, the root node has depth zero, leaf nodes have height zero,
        /// and a tree with only a single node (hence both a root and leaf) has depth and height zero.
        /// Conventionally, an empty tree (tree with no nodes, if such are allowed) has height −1.
        /// </summary>
        bool UsingZeroBasedCounting { get; }
    }
}