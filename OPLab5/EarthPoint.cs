using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{
    struct EarthPoint
    {
        public readonly double latitude;
        public readonly double longitude;
        public readonly string type;
        public readonly string subtype;
        public readonly string name;
        public readonly string address;

        public EarthPoint(double latitude, double longitude, string type, string subtype, string name, string address)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.type = type;
            this.subtype = subtype;
            this.name = name;
            this.address = address;
        }
    }
}
