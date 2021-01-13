using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Sn0wballEngine
{
    public class Component
    {
        [JsonIgnore]
        public Entity entity;

        [JsonIgnore]
        public bool started = false;//for serialization reasons :3
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Render() { }
        public virtual void Destroy() { }



        public T GetComponent<T>() where T : Component
        {
            return entity.GetComponent<T>();
        }

        public T AddComponent<T>() where T : Component
        {
            return entity.AddComponent<T>();
        }



        public static Component GetComponentByName(string name)
        {
            return Activator.CreateInstance(Type.GetType(name)) as Component;
        }

        public static Type GetComponentTypeByName(string name)
        {
            return Type.GetType(name);
        }

        public static List<Type> GetAllComponents()
        {
            List<Type> output = new List<Type>();
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in a.GetTypes())
                {
                    if(t.IsSubclassOf(typeof(Component)))
                    {
                        output.Add(t);
                    }

                }
            }
            return output;
        }
    }
}
