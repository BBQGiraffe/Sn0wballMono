using System;
namespace Sn0wballEngine
{
    public class Collision
    {
        public static bool BoxAndBox(SNVector2f A, SNVector2f B, int AWidth, int AHeight, int BWidth, int BHeight)
        {
            if (A.x < B.x + BWidth &&
               A.x + AWidth > B.x &&
               A.y < B.y + BHeight &&
               A.y + AHeight > B.y)
            {
                return true;
            }


            return false;
        }

        public static bool BoxAndPoint(SNVector2f Point, SNVector2f Box, int BoxWidth, int BoxHeight)
        {
            return BoxAndBox(Point, Box, 1, 1, BoxWidth, BoxHeight);
        }
    }
}
