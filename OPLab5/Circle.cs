namespace OPLab5
{
        struct Circle
        {
            public readonly double latitude;
            public readonly double longitude;
            public readonly double radius;

            public Circle(double latitude, double longitude, double radius)
            {
                this.latitude = latitude;
                this.longitude = longitude;
                this.radius = radius;
            }
        }
}