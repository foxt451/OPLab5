using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using OPLab5;

namespace OPLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new[] {"--db=data.csv", " --lat=50"," --long=29","--size=5"};
            args = new[]{"--db=data.csv", "--lat=50", "--long=29", "--number=5", "--type=leisure", "nearest"};
            string path = Directory.GetCurrentDirectory();
            List<EarthPoint> points = FileWork.ReadFile(path+"\\"+args[0].Split('=')[1]);
            RTree tree = new RTree();
            for (int i = 0; i < points.Count; i++)
            {
                tree.AddPoint(points[i]);

            }
            List<EarthPoint> earthPoints = new List<EarthPoint>();
            SearchLocation searcher = new SearchLocation();
            if (args.Length == 5)
            {
                earthPoints = searcher.Search(tree, double.Parse(args[1].Split('=')[1]),
                    double.Parse(args[2].Split('=')[1]),
                    double.Parse(args[3].Split('=')[1]), args[4].Split('=')[1]);
            }
            else if(args.Length == 4)
            {
                earthPoints = searcher.Search(tree, double.Parse(args[1].Split('=')[1]),
                    double.Parse(args[2].Split('=')[1]),
                    double.Parse(args[3].Split('=')[1]));
            }
            else if (args.Length == 6)
            {
                earthPoints = searcher.SearchNearest(tree, double.Parse(args[1].Split('=')[1]),
                    double.Parse(args[2].Split('=')[1]),
                    int.Parse(args[3].Split('=')[1]), args[4].Split('=')[1]);
            }

            for (int i = 0; i < earthPoints.Count; i++)
            {
                Console.WriteLine(earthPoints[i]);
            }
            Console.WriteLine(earthPoints.Count);
        }
    }
}
