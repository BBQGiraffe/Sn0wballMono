using System;
namespace Sn0wballEngine
{
    public class Tile
    {
        public string sprite { get; set; }
        public bool isObstacle { get; set; }
        public int id { get; set; }
        public int minRange { get; set; }
        public int maxRange { get; set; }
        public bool useInGeneration { get; set; }
        public Tile()
        {
            sprite = "tiles/dirt.png";
            isObstacle = false;
            id = 0;
        }
    }
}
