using System;
using System.Collections.Generic;
using System.IO;

namespace OPLab5
{
    public class FileWork
    {
        public static List<EarthPoint> ReadFile(string path)
        {
            List<EarthPoint> earthPoints = new List<EarthPoint>();
            using (StreamReader read = new StreamReader(path))
            {
                while (!read.EndOfStream)
                {
                    string line = read.ReadLine();
                    if (line.Length != 0)
                    {
                        string[] lineArray = line.Split(';');
                        if (lineArray.Length < 6)
                        {
                            continue;
                        }
                        double latitude = double.Parse(lineArray[0].Replace(',', '.'));
                            double longitude = double.Parse(lineArray[1].Replace(',', '.'));
                            string type = lineArray[2];
                            string subtype = lineArray[3];
                            string name = lineArray[4];
                            string address = lineArray[5];
                            EarthPoint point = new EarthPoint(latitude, longitude, type, subtype, name, address);
                            earthPoints.Add(point);
                        }
                }
            }

            return earthPoints;
        }
    }
}