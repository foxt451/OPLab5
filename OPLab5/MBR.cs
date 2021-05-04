using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{
    // minimum bounding rectangle denotes the minimum space (rectangle) we require
    // to include all our points/objects
    class MBR
    {
        public (double latitude, double longitude) min;
        public (double latitude, double longitude) max;

        public MBR(EarthPoint[] points)
        {
            min = (points[0].latitude, points[0].longitude);
            max = min;
            foreach (EarthPoint point in points[1..^0])
            {
                AdjustWithMBR(new MBR(point));
            }
        }

        //public MBR(MBR[] mbrs)
        //{
        //    min = mbrs[0].min;
        //    max = min;
        //    foreach (MBR mbr in mbrs[1..^0])
        //    {
        //        AdjustWithMBR(mbr);
        //    }
        //}

        public MBR(EarthPoint point)
        {
            max = (point.latitude, point.longitude);
            min = max;
        }

        public MBR()
        {
            min = (double.PositiveInfinity, double.PositiveInfinity);
            max = (double.NegativeInfinity, double.NegativeInfinity);
        }

        // adds the point to MBR and adjusts its sizes to accomodate the point
        public void AdjustWithMBR(MBR newMbr)
        {
            // latitude
            if (newMbr.max.latitude > max.latitude)
            {
                max.latitude = newMbr.max.latitude;
            }
            if (newMbr.min.latitude < min.latitude)
            {
                min.latitude = newMbr.min.latitude;
            }

            // longitude
            if (newMbr.max.longitude > max.longitude)
            {
                max.longitude = newMbr.max.longitude;
            }
            if (newMbr.min.longitude < min.longitude)
            {
                min.longitude = newMbr.min.longitude;
            }
        }

        // tells by how much the area of the MBR will increase after adding the point 
        public double AreaIncreaseAfterAdjusting(MBR newMBR)
        {
            // this time we don't update update the real max and min, but see what they would become
            // so we remember the old values
            var oldMax = max;
            var oldMin = min;
            AdjustWithMBR(newMBR);

            // calculate the difference in area
            double newArea = GetArea();
            // now restore old values and calculate their area
            min = oldMin;
            max = oldMax;
            double oldArea = GetArea();

            return newArea - oldArea;
        }

        public double GetArea()
        {
            return (max.latitude - min.latitude) * (max.longitude - max.longitude);
        }

        public override string ToString()
        {
            return $"(min: ({min.latitude}, {min.longitude}), max: ({max.latitude}, {max.longitude})";
        }
    }
}
