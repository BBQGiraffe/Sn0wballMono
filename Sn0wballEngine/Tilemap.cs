using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Sn0wballEngine
{
    public class Tilemap : Component
    {
        public int[,] tiles { get; set; }

        public int width, height;

        public static Tileset tileset;

        public void Init(int width, int height)
        {
            tiles = new int[width, height];
            this.width = width;
            this.height = height;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    tiles[x, y] = 1;
                }
            }
        }





        public override void Render()
        {
            var chunkpos = Camera.transform.position / 32;

            var chunkX = (int)chunkpos.x / 32;
            var chunkY = (int)chunkpos.y / 32;



        }
    }
}
