using System.Collections;
using System.Collections.Generic;

namespace OPLab5
{
    public class SearchLocation
    {
        private List<EarthPoint> pointInCircle = new List<EarthPoint>();
        public List<EarthPoint> Search(RTree tree, double center1, double center2, double radius, string type = "unknown")
        {
            Circle circle = new Circle(center1, center2, radius);
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
                            if (type == "unknown")
                            {
                                pointInCircle.Add(point);
                            }

                            if (point.type == type)
                            {
                                pointInCircle.Add(point);
                            }
                        }
                    }
                }
            }

            return pointInCircle;
        }
    }
}