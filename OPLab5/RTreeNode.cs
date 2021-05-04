using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{
    class RTreeNode
    {
        // true if contains points themselves, not other RTreeNode's
        public bool IsLeaf { get; private set; } = true;
        public int maxChildren = 5;
        public int children = 0;
        // we need parent to propagate split and MBR resize
        public RTreeNode parent;
        private MBR mbr;

        public RTreeNode()
        {
            mbr = new MBR();
        }

        public RTreeNode(List<EarthPoint> points) : this()
        {
            IsLeaf = true;
            foreach(var point in points)
            {
                AddPoint(point);
            }
        }

        public RTreeNode(List<RTreeNode> subNodes) : this()
        {
            IsLeaf = false;
            foreach(var node in subNodes)
            {
                AddNode(node);
            }
        }

        public double AreaIncreaseAfterAdding(MBR newMbr)
        {
            return mbr.AreaIncreaseAfterAdjusting(newMbr);
        }

        public void AddPoint(EarthPoint point)
        {
            points.Add(point);
            children++;
            AdjustMBR(new MBR(point));
            if (children >= maxChildren)
            {
                Split();
            }
        }

        public void AddNode(RTreeNode node)
        {
            subNodes.Add(node);
            node.parent = this;
            children++;
            AdjustMBR(node.mbr);
            if (children >= maxChildren)
            {
                Split();
            }
        }

        private void AdjustMBR(MBR newMbr)
        {
            mbr.AdjustWithMBR(newMbr);
            if (parent != null)
            {
                parent.AdjustMBR(newMbr);
            }
        }

        public void Split()
        {
            List<MBR> mbrs = new();
            if (IsLeaf)
            {
                foreach (EarthPoint point in points)
                {
                    mbrs.Add(new MBR(point));
                }
            }
            else
            {
                foreach (RTreeNode node in subNodes)
                {
                    mbrs.Add(node.mbr);
                }
            }

            var (firstGroup, secondGroup) = MBRIntoGroups(mbrs);


            RTreeNode newNode;
            if (IsLeaf)
            {
                List<EarthPoint> points1 = new();
                foreach (int index in firstGroup)
                {
                    points1.Add(points[index]);
                }

                List<EarthPoint> points2 = new();
                foreach (int index in secondGroup)
                {
                    points2.Add(points[index]);
                }

                points = points1;
                newNode = new(points2);
            }
            else
            {
                List<RTreeNode> nodes1 = new();
                foreach (int index in firstGroup)
                {
                    nodes1.Add(subNodes[index]);
                }

                List<RTreeNode> nodes2 = new();
                foreach (int index in secondGroup)
                {
                    nodes2.Add(subNodes[index]);
                }

                subNodes = nodes1;
                newNode = new(nodes2);
            }

            if (parent == null)
            {
                parent = new RTreeNode(new List<RTreeNode>() { this, newNode });
            }
            else
            {
                parent.AddNode(newNode);
            }
        }

        private (List<int> firstGroup, List<int> secondGroup) MBRIntoGroups(List<MBR> mbrs)
        {
            List<int> firstGroup = new();
            List<int> secondGroup = new();

            List<int> indexesLeft = new(Enumerable.Range(0, mbrs.Count));


            MBR firstGroupMBR = new();
            MBR secondGroupMBR = new();
            while (indexesLeft.Count > 1)
            {
                var (index1, index2) = FindTwoMBRsWithTheBiggestMBRIncreaseWhenCombined(mbrs, indexesLeft);
                firstGroup.Add(index1);
                secondGroup.Add(index2);

                firstGroupMBR.AdjustWithMBR(mbrs[index1]);
                secondGroupMBR.AdjustWithMBR(mbrs[index2]);

                indexesLeft.Remove(index1);
                indexesLeft.Remove(index2);
            }

            double potentialAreaIncrease1 = firstGroupMBR.AreaIncreaseAfterAdjusting(mbrs[indexesLeft[0]]);
            double potentialAreaIncrease2 = firstGroupMBR.AreaIncreaseAfterAdjusting(mbrs[indexesLeft[0]]);
            if (potentialAreaIncrease1 <= potentialAreaIncrease2)
            {
                firstGroup.Add(indexesLeft[0]);
            }
            else
            {
                secondGroup.Add(indexesLeft[0]);
            }

            return (firstGroup, secondGroup);
        }

        private (int index1, int index2) FindTwoMBRsWithTheBiggestMBRIncreaseWhenCombined(List<MBR> mbrs, List<int> indexesLeft)
        {
            int index1 = 0;
            int index2 = 1;
            double biggestMBRIncrease = 0;

            for (int i = 0; i < mbrs.Count; i++)
            {
                if (!indexesLeft.Contains(i)) continue;
                for (int j = i + 1; j < mbrs.Count; j++)
                {
                    if (!indexesLeft.Contains(j)) continue;
                    double MBRIncrease = mbrs[i].AreaIncreaseAfterAdjusting(mbrs[j]);
                    if (MBRIncrease >= biggestMBRIncrease)
                    {
                        index1 = i;
                        index2 = j;
                        biggestMBRIncrease = MBRIncrease;
                    }
                }
            }
            return (index1, index2);
        }
        

        // if !IsLeaf, will contain other, deeper, nodes
        public List<RTreeNode> subNodes = new();
        // similarily, will contain points if IsLeaf
        public List<EarthPoint> points = new();
    }
}
