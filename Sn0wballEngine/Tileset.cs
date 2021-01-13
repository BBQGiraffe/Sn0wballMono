using System;
using System.Collections.Generic;

namespace Sn0wballEngine
{
    public class Tileset
    {
        public uint width, height;
        public List<Tile> tiles { get; set; } = new List<Tile>();
    }
}
