using System;
using System.Collections.Generic;
using SFML.System;
namespace Sn0wballEngine
{
    public class Game
    {
        public static List<Entity> entities = new List<Entity>();
        static Clock deltaClock = new Clock();

        public static bool paused = false;


        public static void Update() {
            Time.deltaTime = deltaClock.Restart().AsSeconds();
            SceneManager.Update();
            if (!paused)
            {
                lock (entities)
                {
                    foreach (var entity in entities)
                    {

                        entity.Update();
                    }
                }
            }



            DisplayManager.HandleInput();
        }


        public static Entity CreateEntity()
        {
            var entity = new Entity();
            entity.id = entities.Count;
            lock (entities)
            {
                entities.Add(entity);
            }


            return entity;
        }

        

        public static Entity CreateEntity(string prefabFile)
        {
            var entity = Entity.LoadFromPrefab(prefabFile);


            lock (entities) {
                entities.Add(entity);
            }


            return entity;
            
        }


        public static Entity Instantiate(Entity entity)
        {
            var entityB = CreateEntity();
            entityB.name = entity.name;
            foreach(var component in entity.components)
            {
                var type = component.GetType();
                entityB.AddComponent(type);
            }

            
            
            return entityB;
        }


        public static void Render()
        {
            DisplayManager.Clear();

            lock (entities)
            {
                foreach (var entity in entities)
                {
                    entity.Render();
                }
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
