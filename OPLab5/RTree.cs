using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{
    public class RTree
    {
        public RTreeNode root;

        public RTree()
        {
            // initialize root to an empty node
            root = new RTreeNode();
        }

        public void AddPoint(EarthPoint point)
        {
            RTreeNode nodeForAdding = SelectNodeForAdding(point);
            nodeForAdding.AddPoint(point);
            UpdateParent();
        }

        private void UpdateParent()
        {
            while (root.parent != null)
            {
                root = root.parent;
            }
        }

        private RTreeNode SelectNodeForAdding(EarthPoint point)
        {
            RTreeNode current = root;
            // go down until we reach a leaf
            while (!current.IsLeaf)
            {
                List<RTreeNode> subNodes = current.subNodes;
                // find subNode that will increase the least, if we add a point to it
                RTreeNode minIncreaseNode = subNodes[0];
                double minIncrease = minIncreaseNode.AreaIncreaseAfterAdding(new MBR(point));
                foreach (RTreeNode node in subNodes.GetRange(1, subNodes.Count - 1))
                {
                    double potentialMinIncrease = node.AreaIncreaseAfterAdding(new MBR(point));
                    if (potentialMinIncrease < minIncrease)
                    {
                        minIncrease = potentialMinIncrease;
                        minIncreaseNode = node;
                    }
                }
                current = minIncreaseNode;
            }
            return current;
        }

        public override string ToString()
        {
            string result = "";
            Stack<RTreeNode> nodes = new();
            nodes.Push(root);
            while (nodes.Count != 0)
            {
                RTreeNode current = nodes.Pop();
                result += current;
                if (current.IsLeaf)
                {
                    result += $"\nhas {current.points.Count} points:";
                    foreach (EarthPoint point in current.points)
                    {
                        result += $"\n{point}";
                    }
                } else
                {
                    result += $"\nhas {current.subNodes.Count} sub nodes:";
                    foreach (RTreeNode node in current.subNodes)
                    {
                        result += $"\n{node}";
                        nodes.Push(node);
                    }
                }
                result += "\n\n";
            }
            return result;
        }
    }
}
