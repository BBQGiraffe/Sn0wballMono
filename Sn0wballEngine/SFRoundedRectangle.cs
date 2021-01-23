using System;
using SFML.Graphics;
using SFML.System;

namespace Sn0wballEngine
{
    public class SFRoundedRectangle : Shape
    {
        public SNVector2f size = new SNVector2f();
        private float radius;
        private uint cornerPointCount;



        public SFRoundedRectangle(SNVector2f size, float radius, uint cornerPointCount)
        {
            this.size.x = size.x;
            this.size.y = size.y;
            this.radius = radius;
            this.cornerPointCount = cornerPointCount;
        }

        public override Vector2f GetPoint(uint index)
        {
            if (index >= cornerPointCount * 4)
                return new Vector2f(0, 0);

            float deltaAngle = 90.0f / (cornerPointCount - 1);
            SNVector2f center = new SNVector2f();
            uint centerIndex = index / cornerPointCount;
            const float pi = 3.141592654f;

            switch (centerIndex)
            {
                case 0: center.x = size.x - radius; center.y = radius; break;
                case 1: center.x = radius; center.y = radius; break;
                case 2: center.x = radius; center.y = size.y - radius; break;
                case 3: center.x = size.x - radius; center.y = size.y - radius; break;
            }
            Console.WriteLine(index);

            return new Vector2f(radius * (float)Math.Cos(deltaAngle * (index - centerIndex) * pi / 180) + center.x,
                                -radius * (float)Math.Sin(deltaAngle * (index - centerIndex) * pi / 180) + center.y);
        }

        public override uint GetPointCount()
        {
            return cornerPointCount * 4;
        }

        
    }
}
