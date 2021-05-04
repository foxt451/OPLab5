using System;

namespace OPLab5
{
    public class RecAndCircle
    {
        public static bool Intersection(Circle circle, MBR mbr)
        {
            (double latTop, double longTop) = mbr.max;
            (double latBot, double longBot) = mbr.min;
            (double lat3, double long3) = (latTop, longBot);
            (double lat4, double long4) = (latBot, longTop);
            // крайние точка круга в прямоугольнике
            if (DistanceTwoPoints(circle.latitude, latTop, circle.longitude, longTop)<=circle.radius)
            {
                return true;
            }
            if (DistanceTwoPoints(circle.latitude, latBot, circle.longitude, longBot)<=circle.radius)
            {
                return true;
            }
            if (DistanceTwoPoints(circle.latitude, lat3, circle.longitude, long3)<=circle.radius)
            {
                return true;
            }
            if (DistanceTwoPoints(circle.latitude, lat4, circle.longitude, long4)<=circle.radius)
            {
                return true;
            }
            if (circle.points.top.latit >= latBot && circle.points.bottom.latit <= latTop && circle.points.left.longit <= longTop && circle.points.right.longit >= longBot)
                {
                    return true;
                }
            // расстояние от центра до вершини меньше, чем радиус
            return false;
        }

        public static double DistanceTwoPoints(double lat1, double lat2,double long1,double long2)
        {
            double[] ToGradsPoint = new[] {lat1 * Math.PI / 180, lat2*Math.PI/180, long1*Math.PI/180, long2*Math.PI/180};
            //haversin
            double distance = 12742 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(ToGradsPoint[1] - ToGradsPoint[0]), 2) +
                                                          Math.Cos(ToGradsPoint[0]) * Math.Cos(ToGradsPoint[1]) *
                                                          Math.Pow(Math.Sin(ToGradsPoint[3] - ToGradsPoint[2]), 2)));
            return distance;
        }
    }
}