using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPLab5
{
    class RTreeNode
    {
        // true if contains points themselves, not other RTreeNode's
        public bool IsLeaf { get; private set; }

        // if !IsLeaf, will contain other, deeper, nodes
        private List<RTreeNode> subNodes = new();
        // similarily, will contain points if IsLeaf
        // we don't use ErathXYZPoint, because we need to remember the actual point, with its name etc.
        private List<EarthPoint> points = new();
    }
}
