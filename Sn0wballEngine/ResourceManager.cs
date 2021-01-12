using System;
using System.Collections.Generic;
using SFML.Graphics;   
namespace Sn0wballEngine
{
    public class ResourceManager
    {
        static Dictionary<string, object> resources = new Dictionary<string, object>();

        static T GetResource<T>(string name) where T : class
        {
            return resources[name] as T;
        }

        public static Sprite RequestSprite(string name)
        {
            if (resources.ContainsKey(name))
            {
                return GetResource<Sprite>(name);
            }
            Sprite sprite = new Sprite(new Texture("art/sprites/" + name));
            resources.Add(name, sprite);
            return sprite;
        }
    }
}
