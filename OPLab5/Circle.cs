using System;

namespace OPLab5
{
        public class Circle
        {
            public double latitude;
            public double longitude;
            public double radius;
            public ExtrPoints points;

            public Circle(double latitude, double longitude, double radius)
            {
                this.latitude = latitude;
                this.longitude = longitude;
                this.radius = radius;
                this.points = ExtrPointCircle();
            }

            public struct ExtrPoints
            {
                public (double latit, double longit) top;
                public (double latit, double longit) bottom;
                public (double latit, double longit) right;
                public (double latit, double longit) left;
            }
            private ExtrPoints ExtrPointCircle()
            {
                ExtrPoints points = new ExtrPoints();
                double a = Math.Sin(latitude * Math.PI / 180);
                double b = Math.Cos(latitude * Math.PI / 180);
                double c = -2 * Math.Pow(Math.Sin(radius / 12742), 2) + 1;
                points.top = (2 * Math.Atan((a + Math.Sqrt(a * a + b * b - c * c)) / (b + c)) * 180 / Math.PI,
                    longitude);
                points.bottom = (2 * Math.Atan((a - Math.Sqrt(a * a + b * b - c * c)) / (b + c)) * 180 / Math.PI,
                    longitude);
                points.right = (latitude, Math.Acos(-1 * (2 * Math.Pow(Math.Sin(radius / 12742), 2) - 1 +
                                                                       Math.Pow(Math.Sin(latitude * Math.PI / 180), 2)) /
                                                                 Math.Pow(Math.Cos(latitude * Math.PI / 180), 2)) * 180 /
                    Math.PI + longitude);
                points.left = (latitude, -1 * Math.Acos(-1 * (2 * Math.Pow(Math.Sin(radius / 12742), 2) - 1 +
                                                                            Math.Pow(Math.Sin(latitude * Math.PI / 180),
                                                                                2)) /
                                                                      Math.Pow(Math.Cos(latitude * Math.PI / 180), 2)) *
                    180 / Math.PI + longitude);
                return points;
            }
        }
        
}