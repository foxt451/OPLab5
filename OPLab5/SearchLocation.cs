using System;
using System.Collections;
using System.Collections.Generic;

namespace OPLab5
{
    public class SearchLocation
    { public List<EarthPoint> Search(RTree tree, double center1, double center2, double radius, string type = "unknown")
        {
            List<EarthPoint> pointInCircle = new List<EarthPoint>();
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

        public List<EarthPoint> SearchNearest(RTree tree, double center1, double center2,int n, string type = "unknown")
        {
            double i = 0.1;
            while (Search(tree, center1, center2, i, type).Count<n)
            {
                i += 0.1;
            }

            List<EarthPoint> nearestPoints = Search(tree, center1, center2, i, type);
            nearestPoints.Sort((EarthPoint p1, EarthPoint p2) => Compare(center1, center2, p1, p2));
            List<EarthPoint> result = new List<EarthPoint>();
            for (int j = 0; j < n; j++)
            {
                result.Add(nearestPoints[j]);
            }

            return result;
        }

        private int Compare(double lat1, double long1, EarthPoint point1, EarthPoint point2)
        {
            double a = Math.Round(RecAndCircle.DistanceTwoPoints(lat1, point1.latitude, long1, point1.longitude),5);
            double b = Math.Round(RecAndCircle.DistanceTwoPoints(lat1, point2.latitude, long1, point2.longitude), 5);
            return a > b ? 1 : a==b?0:-1;
        }
        
    }
}