using System;
namespace Sn0wballEngine
{
    public class TransformComponent : Component
    {
        public SNVector2f position { get; set; } = new SNVector2f();
        
        public TransformComponent()
        {

        }

        public override void Start()
        {
            Console.WriteLine("im going to shoot myself");
        }

        public override void Update()
        {
        }

    }
}
