using System;
using ZeroFormatter;

namespace Sn0wballEngine
{
    public class Component
    {
        public Entity entity;
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
    }
}
