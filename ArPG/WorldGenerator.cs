using System;
using Sn0wballEngine;
using FastBitmapLib;
using System.Threading;

namespace ArPG
{
    public class WorldGenerator
    {
        


        private static void DumpBitmapInternal(object obj)
        {

            var map = obj as Tilemap;
            var settings = Settings.GetSetting<WorldConfig>("worldconf");
            FastBitmap f = new FastBitmap(settings.WorldWidth, settings.WorldHeight);

            var tiles = map.tiles;
            var tilemap = Tilemap.tileset;
            for(int x = 0; x < settings.WorldWidth; x++)
            {
                for(int y = 0; y < settings.WorldHeight; y++)
                {
                    var tile = tilemap.tiles[tiles[x, y]];
                    var sprite = ResourceManager.RequestSprite(tile.sprite);
                    var image = sprite.Texture.CopyToImage();

                    var pixel = image.GetPixel(0, 0);

                    f.SetPixel(x, y, new FastColor(pixel.R, pixel.G, pixel.B));
                }
            }
            f.Save("map.png");

        }

        public static void DumpBitmap(Tilemap map)
        {
            Thread t = new Thread(DumpBitmapInternal);
            t.Start(map);
        }



        static int GetTile(float val)
        {
            int id = 1;
            int rounded = (int)(val * 10);
            foreach(var tile in Tilemap.tileset.tiles)
            {
                if (rounded <= tile.maxRange && rounded >= tile.minRange && tile.useInGeneration)
                {
                    id = tile.id;
                }
            }



            return id;
        }

        public static Tilemap Generate(int width, int height)
        {

            var settings = Settings.GetSetting<WorldConfig>("worldconf");

            Tilemap output = new Tilemap();
            output.Init(settings.WorldWidth, settings.WorldHeight);
            var noise = new FastNoise();// = FastNoise.NoiseType.Perlin;
            noise.SetNoiseType(FastNoise.NoiseType.Perlin);
            noise.SetFrequency(settings.NoiseFrequency);
            noise.SetInterp(FastNoise.Interp.Quintic);

            for(int x = 0; x < settings.WorldWidth; x++)
            {
                for(int y = 0; y < settings.WorldHeight; y++)
                {
                    var tile = GetTile(noise.GetValue(x, y));
                 
                    output.tiles[x, y] = tile;


                }
            }

            return output;

        }



    }
}
