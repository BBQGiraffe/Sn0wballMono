using System;
using ZeroFormatter;
namespace Sn0wballEngine
{
    [ZeroFormattable]
    public class TransformComponent : Component
    {
        [Index(0)]
        public virtual float x { get; set; }
        //public SNVector2f position = new SNVector2f(0,0);

        public TransformComponent()
        {

        }

    }
}
