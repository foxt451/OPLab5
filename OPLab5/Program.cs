using System;
using System.Collections.Generic;
using System.Net;
using OPLab5;

namespace OPLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            RTree tree = new RTree();
            List<EarthPoint> points = FileWork.ReadFile(@"C:\Users\linds\Downloads\Telegram Desktop\ukraine_poi.csv");
            for (int i = 0; i < 10000; i++)
            {
                tree.AddPoint(points[i]);
            }
            Console.WriteLine(tree);
        }
    }
}
