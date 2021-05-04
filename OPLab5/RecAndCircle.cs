using System;

namespace OPLab5
{
    public class RecAndCircle
    {
        public static bool Intersection(Circle circle)
        {
            //проверяем, лежит ли центр внутри прямоугольника
            if (circle.latitude <  && circle.longitude <)
            {
                return true;
            }
            // крайние точка круга в прямоугольнике
            for (int i = 0; i < circle.extrPoint.Length; i++)
            {
                if (circle.extrPoint[i].Item1 <  && circle.extrPoint[i].Item2 <)
                {
                    return true;
                }
            }
            // расстояние от центра до вершини меньше, чем радиус
            if (DistanceTwoPoints(botCorner.Item1, botCorner.Item2, circle.latitude, circle.longitude) <= circle.radius)
                return true;
            if (DistanceTwoPoints(topCorner.Item1, botCorner.Item2, circle.latitude, circle.longitude) <= circle.radius)
                return true;
            if (DistanceTwoPoints(botCorner.Item1, topCorner.Item2, circle.latitude, circle.longitude) <= circle.radius)
                return true;
            if (DistanceTwoPoints(topCorner.Item1, topCorner.Item2, circle.latitude, circle.longitude) <= circle.radius)
                return true;
            return true;
        }

        private double DistanceTwoPoints(double lat1, double lat2,double long1,double long2)
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