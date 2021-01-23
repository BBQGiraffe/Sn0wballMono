using System;
using Sn0wballEngine;
namespace Raycaster
{
    public class RaycasterScene : Scene
    {
        BitmapImage image = new BitmapImage();
        public static byte[] framebuffer;
        public static byte[,] tilemap;
        int width, height;
        public RaycasterScene()
        {
            framebuffer = new byte[(int)DisplayManager.WindowSize.x * (int)DisplayManager.WindowSize.y * 4];
            width = (int)DisplayManager.WindowSize.x;
            height = (int)DisplayManager.WindowSize.y;

            tilemap = new byte[20, 10]
            {
                { 2,2,2,2,2,2,2,2,2,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,2,2,0,0,0,0,2},
                { 2,0,0,2,2,2,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,2,2,2,2,2,2,2,2,2}

            };

            var playerEnt = Game.CreateEntity();
            playerEnt.AddComponent<TransformComponent>();
            player = playerEnt.AddComponent<PlayerBehaviour>();
            bmp = new BitmapImage();
            bmp.LoadFromFile("tile.png");

            Serialization.SerializeObject(new Wall(), "walls/base.json");


        }

        PlayerBehaviour player;
        BitmapImage bmp;
        private void RenderRaycaster()
        {



            var dirX = player.dir.x;
            var dirY = player.dir.y;
            var planeX = player.plane.x;
            var planeY = player.plane.y;
            var posX = player.transform.position.x;
            var posY = player.transform.position.y;

            var bitmap = bmp.GetBuffer();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    framebuffer[4 * (x + y * width)] = 0; // R?
                    framebuffer[4 * (x + y * width) + 1] = 0; // G?
                    framebuffer[4 * (x + y * width) + 2] = 0; // B?
                    framebuffer[4 * (x + y * width) + 3] = 0; // A?
                }
            }
            for (int x = 0; x < width; x++)
            {
                //calculate ray position and direction
                float cameraX = 2 * x / (float)width - 1; //x-coordinate in camera space
                float rayDirX = dirX + planeX * cameraX;
                float rayDirY = dirY + planeY * cameraX;

                //which box of the map we're in
                int mapX = (int)posX;
                int mapY = (int)posY;

                //length of ray from current position to next x or y-side
                float sideDistX;
                float sideDistY;

                //length of ray from one x or y-side to next x or y-side
                float deltaDistX = Math.Abs(1 / rayDirX);
                float deltaDistY = Math.Abs(1 / rayDirY);

                float perpWallDist;

                //what direction to step in x or y-direction (either +1 or -1)
                int stepX;
                int stepY;

                int hit = 0; //was there a wall hit?
                int side = 0; //was a NS or a EW wall hit?

                //calculate step and initial sideDist
                if (rayDirX < 0)
                {
                    stepX = -1;
                    sideDistX = (posX - mapX) * deltaDistX;
                }
                else
                {
                    stepX = 1;
                    sideDistX = (mapX + 1.0f - posX) * deltaDistX;
                }
                if (rayDirY < 0)
                {
                    stepY = -1;
                    sideDistY = (posY - mapY) * deltaDistY;
                }
                else
                {
                    stepY = 1;
                    sideDistY = (mapY + 1.0f - posY) * deltaDistY;
                }

                //perform DDA
                while (hit == 0)
                {
                    //jump to next map square, OR in x-direction, OR in y-direction
                    if (sideDistX < sideDistY)
                    {
                        sideDistX += deltaDistX;
                        mapX += stepX;
                        side = 0;
                    }
                    else
                    {
                        sideDistY += deltaDistY;
                        mapY += stepY;
                        side = 1;
                    }
                    //Check if ray has hit a wall
                    if (tilemap[mapX,mapY] > 0) hit = 1;
                }
                //Calculate distance projected on camera direction (Euclidean distance will give fisheye effect!)
                if (side == 0) perpWallDist = (mapX - posX + (1 - stepX) / 2) / rayDirX;
                else perpWallDist = (mapY - posY + (1 - stepY) / 2) / rayDirY;

                //Calculate height of line to draw on screen
                int lineHeight = (int)(height/ perpWallDist);

                //calculate lowest and highest pixel to fill in current stripe
                int drawStart = -lineHeight / 2 + height / 2;
                if (drawStart < 0) drawStart = 0;
                int drawEnd = lineHeight / 2 + height / 2;
                if (drawEnd >= height) drawEnd = height - 1;


                var step = 1.0 * 8 / lineHeight;
                var texPos = (drawStart - height / 2 + lineHeight / 2) * step;


                float wallX; //where exactly the wall was hit
                if (side == 0) wallX = posY + perpWallDist * rayDirY;
                else wallX = posX + perpWallDist * rayDirX;
                wallX -= (float)Math.Floor((wallX));


                int texX = (int)(wallX * 8);
                for (int y = drawStart; y < drawEnd; y++)
                {

                    int texY = (int)texPos & (8 - 1);
                    texPos += step;

                    if(side == 1)
                    {
                        
                    }

                    framebuffer[4 * (x + y * width)] = bitmap[4 * (texX + texY * bmp.width)]; // R?
                    framebuffer[4 * (x + y * width) + 1] = bitmap[4*(texX+texY*bmp.width) + 1]; // G?
                    framebuffer[4 * (x + y * width) + 2] = bitmap[4 * (texX + texY * bmp.width) + 2]; // B?
                    framebuffer[4 * (x + y * width) + 3] = 255;
                }

            }


        }

        public override void DrawUI()
        {
            Console.WriteLine(1f / Time.deltaTime);
            RenderRaycaster();
            image.SetBuffer(framebuffer, (uint)width, (uint)height);
            image.Draw();
        }
    }
}
