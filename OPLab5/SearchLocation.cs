namespace OPLab5
{
    public class SearchLocation
    {
        Circle circle = new Circle();
        private double max_x1 = 0;

        public void SearchInRadius()
        { 
            RTreeNode current = new RTreeNode();
            if (!current.IsLeaf)
            {
                // пересекаются ли дети с областью circle
                // если да, то вызвать серч
            }
            else
            {
               // записи, которіе в лситках добавить в рез 
            }
        }
    }
}