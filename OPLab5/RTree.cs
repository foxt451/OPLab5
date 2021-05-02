using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{
    class RTree
    {
        private RTreeNode root;

        public RTree()
        {
            // initialize root to an empty node
            root = new RTreeNode();
        }

        public void AddPoint(EarthPoint point)
        {
            RTreeNode nodeForAdding = SelectNodeForAdding(point);
            nodeForAdding.AddPoint(point);
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
    }
}
