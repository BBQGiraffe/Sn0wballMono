using System;
namespace FallingSand
{
    public class Particle
    {
        public ParticleType type { get; set; } = ParticleType.sand;
        public int speed { get; set; } = 2;
        public string name { get; set; } = "empty";
        public byte id { get; set; } = 0;
        public Sn0wballEngine.SNColor color { get; set; } = new Sn0wballEngine.SNColor();


        public static void UpdateWater(int x, int y, byte id)
        {
            int outx = x, outy = y;
            if (y + 1 > 255 || y - 1 < 0 || x + 1 > 255 || x - 1 < 0)
            {
                return;
            }

            ParticleManager.particles[x, y].id = 0;
            if (ParticleManager.particles[x, y - 1].id == 0)
            {
                outy--;
            }

            if(ParticleManager.particles[x , y-1].id != 0)
            {

            }








            ParticleManager.particles[outx, outy].id = id;
        }

        public static void UpdateSand(int x, int y, byte id)
        {
            int outx = x, outy = y;
            if (y + 1 > 255 || y - 1 < 0 || x + 1 > 255 || x - 1 < 0)
            {
                return;
            }

            ParticleManager.particles[x, y].id = 0;
            if (ParticleManager.particles[x, y - 1].id == 0)
            {
                outy--;

            }
            else
            {
                if (ParticleManager.particles[x + 1, outy - 1].id == 0)
                {
                    outx++;
                }
                if (ParticleManager.particles[x - 1, outy - 1].id == 0)
                {
                    outx--;
                }
            }


            ParticleManager.particles[outx, outy].id = id;
        }


        public static void UpdatePhysics(int x, int y, byte id)
        {
            if(id == 0)
            {
                return;
            }
            var particle = ParticleManager.GetParticle(id);



            switch (particle.type)
            {
                case ParticleType.liquid:
                    UpdateWater(x, y, id);
                    break;
                case ParticleType.sand:
                    UpdateSand(x, y, id);
                    break;
                default:
                    break;
            }


        }
    }
}
