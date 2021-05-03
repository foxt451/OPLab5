using System.Collections.Generic;
using System.IO;

namespace OPLab5
{
    public class FileWork
    {
        private List<EarthPoint> ReadFile(string path)
        {
            List<EarthPoint> earthPoints = new List<EarthPoint>();
            using (StreamReader read = new StreamReader(path))
            {
                string line = read.ReadLine();
                if (line.Length != 0)
                {
                    string[] lineArray = Split(line);
                    double latitude = double.Parse(lineArray[0]);
                    double longitude = double.Parse(lineArray[1]);
                    string type = lineArray[2];
                    string subtype = lineArray[3];
                    string name = lineArray[4];
                    string address = lineArray[5];
                    EarthPoint point = new EarthPoint(latitude, longitude, type, subtype, name, address);
                    earthPoints.Add(point);
                }
            }

            return earthPoints;
        }

        private string[] Split(string line)
        {
            string[] split = new string[6];
            int count = 0;
            string tempString = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ';')
                {
                    tempString += line[i];
                }
                else
                {
                    if (tempString.Length!=0)
                    {
                        split[i] = tempString;
                        count++;
                        tempString = "";
                    }
                }
            }

            return split;
        }
    }
}