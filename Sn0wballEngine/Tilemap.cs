using System;
using System.Collections.Generic;

namespace Sn0wballEngine
{
    public class Tilemap : Component
    {
        public int[,] tiles;

        public int width, height;
        public static Tileset tileset;

        public int test { get; set; }

        public void Init(int width, int height)
        {
            tiles = new int[width, height];
            this.width = width;
            this.height = height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    tiles[x, y] = -1;
                }
            }
        }

        public Tilemap()
        {

        }


        public override void Render()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if(tiles[x,y] == -1)
                    {
                        continue;
                    }
                    var sprite = ResourceManager.RequestSprite(tileset.tiles[tiles[x, y]].sprite);
                    sprite.Position = new SFML.System.Vector2f(x * 8, y * 8);
                    DisplayManager.window.Draw(sprite);
                }
            }
        }
    }
}
