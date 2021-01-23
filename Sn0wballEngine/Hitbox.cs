using System;
namespace Sn0wballEngine
{
    public class HitBox
    {
        public uint width { get; set; }
        public uint height { get; set; }
        public SNVector2f offset { get; set; } = new SNVector2f();
    }
}
