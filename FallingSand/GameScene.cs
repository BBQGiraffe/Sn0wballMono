using System;
using System.IO;
using Sn0wballEngine;
namespace FallingSand
{
    public class GameScene : Scene
    {
        public override void Start()
        {
            foreach(var item in Directory.GetFiles("particles", "*.json"))
            {
                var particle = Serialization.DeserializeObject<Particle>(item);
                ParticleManager.pool.Add(particle);
            }
            Serialization.SerializeObject(new Particle(), "particles/empty.json");
            for(int x = 0; x < 256; x++)
            {
                for(int y = 0; y < 256; y++)
                {
                    ParticleManager.particles[x, y] = new ParticleID()
                    {
                        id = 0
                    };

                }

            }

            for(int i = 0; i < 50; i++)
            {
                for(int y= 0; y < 50; y++)
                {
                    ParticleManager.particles[i + 50, y + 50].id = 2;
                }

            }
            for(int x = 0; x < 256; x++)
            {
                ParticleManager.particles[x, 0].id = 3;
            }

            for(int x = 0; x < 50; x++)
            {
                for(int y = 0; y < 50; y++)
                {
                    ParticleManager.particles[x, y].id = 1;
                }
            }
        }


        float updateTimer = 0f, updateTime = .01f;
        public override void Update()
        {
            
            updateTimer += Time.deltaTime;
            if(updateTimer >= updateTime)
            {
                updateTimer = 0;
                ParticleManager.Update();
            }

            if (Input.LeftClick())
            {
                var size = 15;

                var mouse = new SNVector2f(Input.GetMousePosition().x - 128, -Input.GetMousePosition().y+512) / 4;

                for(int x = (int)mouse.x; x < mouse.x + size; x++)
                {
                    for(int y = (int)mouse.y; y < mouse.y + size; y++)
                    {
                        ParticleManager.particles[x, y].id = 1;
                    }
                }
            }

        }

        public override void DrawUI()
        {
            ParticleManager.Draw();
        }
    }
}
