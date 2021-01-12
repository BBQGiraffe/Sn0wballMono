using System;
using System.Collections.Generic;
using SFML.System;
namespace Sn0wballEngine
{
    public class Game
    {
        public static List<Entity> entities = new List<Entity>();
        static Clock deltaClock = new Clock();

        public static void Update() {
            Time.deltaTime = deltaClock.Restart().AsSeconds();
            SceneManager.Update();
            foreach (var entity in entities)
            {
                entity.Update();
            }

            DisplayManager.HandleInput();
        }


        public static void Spawn(Entity entity)
        {
            entity.AddComponent<TransformComponent>();
            entities.Add(entity);
        }

        public static void LoadGameObjectDefs()
        {
            string[] files = System.IO.Directory.GetDirectories("gameobjects");
            
            foreach(var dir in files)
            {
                
            }
        }

        public static void Render()
        {
            DisplayManager.Clear();
            foreach(var entity in entities)
            {
                entity.Render();
            }
            RenderUI();
            DisplayManager.Present();
        }

        static void RenderUI()
        {
            SceneManager.RenderUI();
        }

        public static void LoadSettings()
        {

        }

        
    }
}
