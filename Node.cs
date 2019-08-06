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
        public double closestNodeDistance = 340282300000000000000000000000000000000.0f;

        public float CalculateDistance(Node node)
        {
            return (float)Math.Sqrt(Math.Pow(node.position.x - position.x, 2) + Math.Pow(node.position.y - position.y, 2));
        }
    }
}
