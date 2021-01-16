using System;
namespace Sn0wballEngine
{
    public class TransformComponent : Component
    {
        public SNVector2f position { get; set; } = new SNVector2f(0, 0);
        public SNVector2f velocity { get; set; } = new SNVector2f();

        public void SetPosition(SNVector2f position)
        {
            this.position.x = position.x;
            this.position.y = position.y;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
            position += velocity * Time.deltaTime;
        }
    }
}
