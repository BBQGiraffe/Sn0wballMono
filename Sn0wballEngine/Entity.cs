using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Sn0wballEngine
{
    public class Entity
    {
        public List<Component> components { get; set; } = new List<Component>();


        [JsonIgnore]
        public int id;
        public string name { get; set; } = "unnamed entity";


        //for serialization reasons

        public void Update()
        {
            foreach (var component in components)
            {
                component.Update();
            }
        }

        public void Render()
        {
            foreach (var component in components)
            {
                component.Render();
            }
        }

        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance(typeof(T));
            (component as T).entity = this;
            components.Add(component as T);
            (component as T).Start();
            return component as T;
        }

        public void AddComponent(Component component)
        {
            component.entity = this;
            components.Add(component);
            component.Start();
        }

        

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component.GetType().Equals(typeof(T))) { 
                    return component as T;
                
                }

            }
            return null;
        }

        public void LoadFromFile()
        {
            foreach(var component in components)
            {
                component.entity = this;
                component.Start();

            }
        }


        //loads an entity and instantiates it
        public static Entity LoadFromPrefab(string filename)
        {
            var entity = Serialization.DeserializeObject<Entity>(filename);
            entity.LoadFromFile();
            return entity;
            
        }



    }
}
