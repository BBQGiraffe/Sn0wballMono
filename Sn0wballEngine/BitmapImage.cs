using System;
using SFML.Graphics;
namespace Sn0wballEngine
{
    /*editable image*/
    public sealed class BitmapImage
    {
        private byte[] buffer;
        private Image image;
        private Sprite sprite = new Sprite();
        public uint width, height;


        private void SetBufferInternal()
        {
            image = new Image(width, height, buffer);
            sprite.Texture = new Texture(image);
        }
        public void SetBuffer(byte[] buffer, uint width, uint height)
        {
            this.width = width;
            this.height = height;
            this.buffer = buffer;
            SetBufferInternal();
            
        }

        public void LoadFromFile(string file)
        {
            image = new Image(file);
            width = image.Size.X;
            height = image.Size.Y;
            buffer = new byte[width * height  * 4];
            for(uint x = 0; x < width; x++)
            {
                for(uint y = 0; y < width; y++)
                {
                    var color = image.GetPixel(x, y);
                    buffer[4 * (x + y * width)] = color.R; // R?
                    buffer[4 * (x + y * width) + 1] = color.G;
                    buffer[4 * (x + y * width) + 2] = color.B;
                    buffer[4 * (x + y * width) + 3] = color.A;
                }
            }
        }

        public byte[] GetBuffer()
        {
            return buffer;
        }

        public void Draw()
        {
            DisplayManager.window.Draw(sprite);
        }
    }
}
