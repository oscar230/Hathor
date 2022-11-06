namespace Hathor.Web.Models.Abstracts.NNode
{
    public abstract class NNode : INNode
    {
        private readonly NNode? _parent;
        private readonly List<NNode> _children;

        public NNode(NNode? parent, List<NNode>? children)
        {
            _children = new List<NNode>();
            if (parent is not null)
            {
                _parent = parent;
            }
            if (children is not null)
            {
                _children = children;
            }
            else
            {
                _children = new List<NNode>();
            }
        }

        public void AddChild(NNode node) => _children.Add(node);

        public IEnumerable<INNode> Links
        {
            get
            {
                List<INNode> list = new();
                if (_parent is not null)
                {
                    list.Add(_parent);
                }
                if (_children is not null)
                {
                    list.AddRange(_children);
                }
                return list;
            }
        }

        public INNode? Parent => _parent;

        public IEnumerable<INNode> Children => _children ?? Enumerable.Empty<INNode>();

        public IEnumerable<INNode> Ancestors
        {
            get
            {
                if (!IsRoot && _parent is not null)
                {
                    List<INNode> ancestors = new();
                    ancestors.Add(_parent);
                    ancestors.AddRange(_parent.Ancestors);
                    return ancestors.AsEnumerable();
                }
                else
                {
                    return Enumerable.Empty<INNode>();
                }
            }
        }

        public IEnumerable<INNode> Descendants
        {
            get
            {
                List<INNode> descendants = new();
                if (_children is not null && _children.Any())
                {
                    foreach (INNode child in _children)
                    {
                        descendants.AddRange(child.Descendants);
                    }
                    descendants.AddRange(_children);
                }
                return descendants.AsEnumerable();
            }
        }

        public INNode Root => throw new NotImplementedException();

        public bool IsParent => throw new NotImplementedException();

        public bool IsRoot => throw new NotImplementedException();

        public bool IsBranchNode => throw new NotImplementedException();

        public bool IsTerminalNode => throw new NotImplementedException();

        public ulong Height => throw new NotImplementedException();

        public ulong Depth => throw new NotImplementedException();

        public ulong Degree => throw new NotImplementedException();

        public ulong DegreeOfTree => throw new NotImplementedException();

        public ulong Distance => throw new NotImplementedException();

        public ulong Level => throw new NotImplementedException();

        public ulong Width => throw new NotImplementedException();

        public ulong Breadth => throw new NotImplementedException();

        public ulong Size => throw new NotImplementedException();

        public bool UsingZeroBasedCounting => throw new NotImplementedException();

        /// <summary>
        /// Child nodes with the same parent are sibling nodes.
        /// </summary>
        /// <param name="nodeA"></param>
        /// <param name="nodeB"></param>
        /// <returns></returns>
        public static bool AreSiblings(INNode nodeA, INNode nodeB)
        {
            return !nodeA.IsRoot && !nodeB.IsRoot && nodeA.Parent is not null && nodeA.Parent.Equals(nodeB.Parent);
        }


        /// <summary>
        /// Are nodeB a parent or a child to nodeA.
        /// </summary>
        /// <param name="nodeA"></param>
        /// <param name="nodeB"></param>
        /// <returns></returns>
        public static bool AreNeighbors(INNode nodeA, INNode nodeB)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// A forest is a set of one or more disjoint trees.
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool IsForest(IEnumerable<INNode> nodes)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<INNode> RootNodesInForest(IEnumerable<INNode> nodes)
        {
            if (IsForest(nodes))
            {
                return nodes.Select(n => n.Root).Distinct();
            }
            else
            {
                return new List<INNode>()
                {
                    nodes.First().Root
                };
            }
        }

        public static bool IsBinaryTree(INNode rootNode)
        {
            // Has no children, is binary.
            if (rootNode.IsTerminalNode)
            {
                return true;
            }
            // Have 2 or 1 nodes, will treverse theese and keep looking.
            else if (rootNode.Children.Count() <= 2)
            {
                return rootNode.Children.Count().Equals(2) ?
                    
                        IsBinaryTree(rootNode.Children.ElementAt(0)) && IsBinaryTree(rootNode.Children.ElementAt(1))
                     :
                    IsBinaryTree(rootNode.Children.First());
            }
            // Have more than 2 nodes, it's not a binary tree
            else if (rootNode.Children.Count() > 2)
            {
                return false;
            }
            // Has.. less than zero? wut?
            throw new ArgumentOutOfRangeException(nameof(rootNode.Children));
        }
    }
}
