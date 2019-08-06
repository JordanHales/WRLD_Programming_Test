using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLD_Programming_Test
{
    class Node
    {
        public string name;
        public Vector2 position = new Vector2(0,0);
        public double closestNodeDistance = 9007199254740991.0d;

        public double CalculateDistance(Node node)
        {
            return (double)Math.Sqrt(Math.Pow(node.position.x - position.x, 2) + Math.Pow(node.position.y - position.y, 2));
        }
    }
}
