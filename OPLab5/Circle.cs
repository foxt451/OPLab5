using System;

namespace OPLab5
{
        public struct Circle
        {
            public double latitude;
            public double longitude;
            public double radius;
            public (double, double)[] extrPoint;

            public Circle(double latitude, double longitude, double radius)
            {
                this.latitude = latitude;
                this.longitude = longitude;
                this.radius = radius;
                this.extrPoint = ExtrPointCircle(latitude, longitude, radius);

            }
            
            private static (double,double)[] ExtrPointCircle(double latitude, double longitude, double radius)
            {
                (double,double)[] ExtrPointCircle = new (double,double)[4];
                double a = Math.Sin(latitude * 3.1415925 / 180);
                double b = Math.Cos(latitude * 3.1415925 / 180);
                double c = -2 * Math.Pow(Math.Sin(radius / 12742), 2) + 1;
                ExtrPointCircle[0] = (2 * Math.Atan((a + Math.Sqrt(a * a + b * b - c * c)) / (b + c)) * 180 / 3.1415925,
                    longitude);
                ExtrPointCircle[1] = (2 * Math.Atan((a - Math.Sqrt(a * a + b * b - c * c)) / (b + c)) * 180 / 3.1415925,
                    longitude);
                ExtrPointCircle[2] = (latitude, Math.Acos(-1 * (2 * Math.Pow(Math.Sin(radius / 12742), 2) - 1 +
                                                                       Math.Pow(Math.Sin(latitude * 3.1415925 / 180), 2)) /
                                                                 Math.Pow(Math.Cos(latitude * 3.1415925 / 180), 2)) * 180 /
                    3.1415925 + longitude);
                ExtrPointCircle[3] = (latitude, -1 * Math.Acos(-1 * (2 * Math.Pow(Math.Sin(radius / 12742), 2) - 1 +
                                                                            Math.Pow(Math.Sin(latitude * 3.1415925 / 180),
                                                                                2)) /
                                                                      Math.Pow(Math.Cos(latitude * 3.1415925 / 180), 2)) *
                    180 / 3.1415925 + longitude);
                return ExtrPointCircle;
            }
        }
        
}