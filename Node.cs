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
        
        public float CalculateDistance(Node node)
        {
            return (float)Math.Sqrt(Math.Pow(position.x - node.position.x, 2) + Math.Pow(position.y - node.position.y, 2));
        }
    }
}
