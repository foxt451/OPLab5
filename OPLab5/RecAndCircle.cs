using System;

namespace OPLab5
{
    public class RecAndCircle
    {
        public static bool Intersection(Circle circle, MBR mbr)
        {
            (double latTop, double longTop) = mbr.max;
            (double latBot, double longBot) = mbr.min;
            double XNearest = Math.Max(latBot, Math.Min(circle.latitude, latTop));
            double YNearest = Math.Max(longBot, Math.Min(circle.longitude, longTop));
            if (DistanceTwoPoints(XNearest, circle.latitude, YNearest, circle.longitude) <= circle.radius)
            {
                return true;
            }
            else return false;
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