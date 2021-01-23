using System;
using Sn0wballEngine;
namespace Raycaster
{
    public class MapObjectBehaviour : Component
    {
        public string sprite { get; set; }
        public HitBox collider { get; set; }
        public SNVector2f position { get; set; }

    }
}
