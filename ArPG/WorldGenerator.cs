using System;
using Sn0wballEngine;
using FastBitmapLib;
using System.Threading;

namespace ArPG
{
    public static class WorldGenerator
    {

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

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
            int id = 0;

            int rounded = (int)val;
            foreach(var tile in Tilemap.tileset.tiles)
            {
                if (rounded <= tile.maxRange && rounded >= tile.minRange && tile.useInGeneration)
                {
                    id = tile.id;
                }
            }



            return id;
        }

        static int[,] GenerateInts(int seed, int width, int height, float frequency)
        {
            int[,] output = new int[width,height];
            SimplexNoise.Noise.Seed = seed;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var noise = SimplexNoise.Noise.CalcPixel2D(x, y, frequency);
                    var tileID = GetTile(noise / 10);
                    output[x, y] = tileID;

                }
            }

            return output;

        }

        public static Chunk GenerateChunk()
        {
            Chunk output = new Chunk();

            var settings = Settings.GetSetting<WorldConfig>("worldconf");


            int[,] tiles = new int[16, 16];
            for (int i = 0; i < settings.NoiseIterations; i++)
            {
                var j = GenerateInts(6592 + i * 14, settings.WorldWidth, settings.WorldHeight, settings.NoiseFrequency);
                var k = GenerateInts(2342 + i * 12, settings.WorldWidth, settings.WorldHeight, settings.NoiseFrequency);
                for (int x = 0; x < settings.WorldWidth; x++)
                {
                    for (int y = 0; y < settings.WorldHeight; y++)
                    {
                        var e = (j[x, y] + k[x, y]) / 2;
                        tiles[x, y] = e;
                    }
                }

            }


            return output;
        }

        public static Tilemap Generate()
        {
            var settings = Settings.GetSetting<WorldConfig>("worldconf");

            Tilemap output = new Tilemap();
            output.Init(settings.WorldWidth, settings.WorldHeight);

            int[,] tiles = new int[settings.WorldWidth, settings.WorldHeight];
            for(int i = 0; i < settings.NoiseIterations; i++)
            {
                var j = GenerateInts(6592+ i*14, settings.WorldWidth, settings.WorldHeight, settings.NoiseFrequency);
                var k = GenerateInts(2342 + i*12, settings.WorldWidth, settings.WorldHeight, settings.NoiseFrequency);
                for (int x = 0; x < settings.WorldWidth; x++)
                {
                    for(int y = 0; y < settings.WorldHeight; y++)
                    {
                        var e = (j[x, y] + k[x, y]) / 2;
                        tiles[x, y] = e;
                    }
                }

            }
            output.tiles = tiles;


            lock (Game.entities)
            {
                Game.CreateEntity().AddComponent(output);
            }
            //DumpBitmap(output);

            return output;

        }





    }
}
