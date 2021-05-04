using System.Collections.Generic;

namespace OPLab5
{
    public class SearchLocation
    {
        Circle circle = new Circle(1, 2, 3);
        
        private double max_x1 = 0;
        private List<EarthPoint> pointInCircle = new List<EarthPoint>();
        public void SearchInRadius()
        {
            RTreeNode current = new RTreeNode();
            if (!current.IsLeaf)
            {
                if (RecAndCircle.Intersection(circle))
                {
                    SearchInRadius();
                }
                // пересекаются ли дети с областью circle
                // если да, то вызвать серч
            }
            else
            {
                //pointInCircle.Add();
               // записи, которіе в лситках добавить в рез 
            }
        }
    }
}