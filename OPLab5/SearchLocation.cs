using System.Collections;
using System.Collections.Generic;

namespace OPLab5
{
    public class SearchLocation
    {
        Circle circle = new Circle(1, 2, 3);
        private List<EarthPoint> pointInCircle = new List<EarthPoint>();
        public void SearchInRadius(RTree tree)
        {
            Stack<RTreeNode> nodes = new Stack<RTreeNode>(); 
            nodes.Push(tree.root);
            while (nodes.Count != 0)
            {
                RTreeNode current = nodes.Pop();
                if (!current.IsLeaf)
                {
                    foreach (RTreeNode node in current.subNodes)
                    {
                        if (RecAndCircle.Intersection(circle, node.mbr))
                        {
                            nodes.Push(node);
                        }
                    }
                }
                else
                {
                    foreach (EarthPoint point in current.points)
                    {
                        if (RecAndCircle.DistanceTwoPoints(point.latitude, circle.latitude, point.longitude, circle.longitude)<=circle.radius)
                        {
                            pointInCircle.Add(point);
                        }
                    }
                }
            }
        }
    }
}