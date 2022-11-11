using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Jacky
{
    public class NodeHelp
    {
        public const int NodeSize = 55;


        public static Vector2 GetPosition(int x, int y, int width, int height)
        {
            float leftBottomX = - width * NodeSize / 2;
            float leftBottomY = - height * NodeSize / 2;
            float finalX = x * NodeSize + leftBottomX - NodeSize / 2;
            float finalY = leftBottomY + y * NodeSize - NodeSize / 2;
            return new Vector2(finalX, finalY);
        }
    }
}