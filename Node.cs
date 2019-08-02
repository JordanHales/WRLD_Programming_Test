using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRLD_Programming_Test
{
    class Node
    {
        public Vector2 position;
        public Node parent;
        public Node child;
        
        public float CalculateDistance(Node point)
        {
            return (float)Math.Sqrt(Math.Pow(position.x - point.position.x, 2) + Math.Pow(position.y - point.position.y, 2));
        }
    }
}
