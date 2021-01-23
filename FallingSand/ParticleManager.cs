using System;
using System.Collections.Generic;
using Sn0wballEngine;
using SFML.Graphics;
namespace FallingSand
{
    public class ParticleManager
    {
        public static List<Particle> pool = new List<Particle>();
        public static ParticleID[,] particles = new ParticleID[256, 256];
        static Image draw = new Image(256, 256, new Color(100, 0, 100));
        public static void Update()
        {
            foreach(var particle in particles)
            {
                particle.simulated = false;
            }

            for (int x = 0; x < 256; x++)
            {
                for(int y = 0; y < 256; y++)
                {
                    if (!particles[x, y].simulated)
                    {
                        Particle.UpdatePhysics(x, y, particles[x, y].id);
                        particles[x, y].simulated = true;
                    }

                }
            }
        }
        public static Particle GetParticle(byte id) { 
            foreach(var particle in pool)
            {
                if(particle.id == id)
                {
                    return particle;
                }
            }

            return null;
        }
        public static void Draw()
        {
            for(uint x = 0; x < 256; x++)
            {
                for(uint y = 0; y < 256; y++)
                {
                    if(particles[x,y] == null)
                    {
                        continue;
                    }
                    if (particles[x,y].id == 0)
                    {
                        draw.SetPixel(x, y, Color.Black);
                        continue;
                    }
                    var tile = GetParticle(particles[x, y].id);
                    draw.SetPixel(x, y, new Color(tile.color.r, tile.color.g, tile.color.b));
                }
            }
            var sprite = new Sprite(new Texture(draw));
            sprite.Scale = new SFML.System.Vector2f(5, -5);
            sprite.Position = new SFML.System.Vector2f(0, 640);
            DisplayManager.window.Draw(sprite);
        }

    }
}
