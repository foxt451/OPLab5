using System;

namespace OPLab5
{
    public class RecAndCircle
    {
        private const double EARTH_RADIUS = 6371;
        public static bool Intersection(Circle circle, MBR mbr)
        {
            EarthPoint circleCenter = new(circle.latitude, circle.longitude);

            EarthPoint lowerLeft = new(mbr.min.latitude, mbr.min.longitude);
            EarthPoint upperLeft = new(mbr.max.latitude, mbr.min.longitude);
            EarthPoint lowerRight = new(mbr.min.latitude, mbr.max.longitude);
            EarthPoint upperRight = new(mbr.max.latitude, mbr.max.longitude);
            // check for lines of latitude
            if ((DistanceTwoPoints(circle.latitude, lowerLeft.latitude, circle.longitude, circle.longitude) > circle.radius && circleCenter.latitude < lowerLeft.latitude) ||
                (DistanceTwoPoints(circle.latitude, upperLeft.latitude, circle.longitude, circle.longitude) > circle.radius && circleCenter.latitude > upperLeft.latitude))
            {
                return false;
            }

            // check for lines of longitude

            if ((DistanceTwoPoints(circle.latitude, circle.latitude, circle.longitude, lowerLeft.longitude) > circle.radius && circleCenter.longitude < lowerLeft.longitude) ||
                (DistanceTwoPoints(circle.latitude, circle.latitude, circle.longitude, lowerRight.longitude) > circle.radius && circleCenter.longitude > lowerRight.longitude))
            {
                return false;
            }
            return true;
        }

        //public static double Bearing(EarthPoint a, EarthPoint b)
        //{
        //    EarthPoint aRad = new(a.latitude * Math.PI / 180, a.longitude * Math.PI / 180);
        //    EarthPoint bRad = new(b.latitude * Math.PI / 180, b.longitude * Math.PI / 180);

        //    double dLon = bRad.longitude - aRad.longitude;
        //    double x = Math.Sin(dLon) * Math.Cos(bRad.latitude);
        //    double y = Math.Cos(aRad.latitude) * Math.Sin(bRad.latitude) - Math.Sin(aRad.latitude) * Math.Cos(bRad.latitude) *
        //        Math.Cos(dLon);
        //    double atan2 = Math.Atan2(x, y);
        //    return (atan2 / Math.PI * 180 + 360) % 360;
        //}

        //public static double DistanceFromPointToLine(EarthPoint point, EarthPoint lineStart, EarthPoint lineEnd)
        //{
        //    double toRads = Math.PI / 180;
        //    double bearing12 = Bearing(point, lineStart) * toRads;
        //    double bearing13 = Bearing(point, lineEnd) * toRads;

        //    double distance13 = DistanceTwoPoints(point.latitude, lineEnd.latitude, point.longitude,
        //        lineEnd.longitude) / EARTH_RADIUS;

        //    double distance = Math.Asin(Math.Sin(distance13) * Math.Sin(bearing12 - bearing13)) * EARTH_RADIUS;
        //    return distance;
        //}

        public static double DistanceTwoPoints(double lat1, double lat2,double long1,double long2)
        {
            double[] ToGradsPoint = new[] {lat1 * Math.PI / 180, lat2*Math.PI/180, long1*Math.PI/180, long2*Math.PI/180};
            //haversin
            double distance = EARTH_RADIUS * 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((ToGradsPoint[1] - ToGradsPoint[0])/2), 2) +
                                                          Math.Cos(ToGradsPoint[0]) * Math.Cos(ToGradsPoint[1]) *
                                                          Math.Pow(Math.Sin((ToGradsPoint[3] - ToGradsPoint[2])/2), 2)));
            return distance;
        }
    }
}