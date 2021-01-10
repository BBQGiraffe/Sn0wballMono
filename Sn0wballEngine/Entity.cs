using System;
using System.Collections.Generic;
using System.IO;
using ZeroFormatter;

namespace Sn0wballEngine
{
    public class Entity
    {
        private List<Component> components = new List<Component>();

        public int id;

        

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
            components.Add(component as T);
            (component as T).Start();
            return component as T;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component.GetType().Equals(typeof(T))) { return component as T; }

            }
            return null;
        }

        public void SaveAsPrefab(string filename)
        {
            var file = new BinaryWriter(File.OpenWrite("prefabs/" + filename + ".prefab"));
            foreach(var component in components)
            {
                var bytes = ZeroFormatterSerializer.Serialize(component);
                file.Write(bytes);
            }
            file.Close();
        }
    }
}
