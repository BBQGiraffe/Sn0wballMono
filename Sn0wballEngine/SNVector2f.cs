using System;
namespace Sn0wballEngine
{
    public class SNVector2f
    {
        public float x, y;

        public SNVector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static SNVector2f operator + (SNVector2f A, SNVector2f B)
        {
            return new SNVector2f(A.x + B.x, A.y + B.y);
        }
    }
}
