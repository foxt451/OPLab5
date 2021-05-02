using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{

    // instead of a simple point set by longitude and latitude
    // it's sometimes more convenient to imagine the Earth as a sphere in 3D space, with its center at (0; 0; 0)
    // and radius 1
    // (the equator is in xOz, the Prime meridian in xOy)
    // then, if we have a point on the sphere, we obtain its x coordinate by projecting the point onto Ox axis
    // we can get y in the similar way
    // with these two values, two points on the globe can be identified, on different halves of the sphere
    // so we also need another parameter telling in which part the point lies
    // it will be z: >= 0 for the Eastern hemisphere (or the Prime meridian), < 0 for the Western (directly
    // translated from the longitude)
    struct EarthXYZPoint
    {
        public double x;
        public double y;
        public double z;

        // positive longitude denotes the Eastern hemisphere
        public EarthXYZPoint(double latitude, double longitude)
        {
            // transform degrees into radians
            y = Math.Sin(latitude / 180 * Math.PI);
            x = Math.Cos(longitude / 180 * Math.PI);
            z = Math.Sin(longitude / 180 * Math.PI);
        }
    }
}
