using System;
namespace Sn0wballEngine
{
    public class SNColor
    {
        public byte r { get; set; } = 255;
        public byte g { get; set; } = 255;
        public byte b { get; set; } = 255;
        public byte a { get; set; } = 255;

        public static SNColor White()
        {
            return new SNColor()
            {
                r = 255,
                g = 255,
                b = 255,
                a = 255
            };
        }

        public static SNColor Red()
        {
            return new SNColor()
            {
                r = 255,
                g = 0,
                b = 0,
                a = 255
            };
        }
    }
}
