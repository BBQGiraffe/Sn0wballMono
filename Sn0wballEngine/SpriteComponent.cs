using System;
namespace Sn0wballEngine
{
    public class SpriteComponent : Component
    {
        public string sprite { get; set; } = "test/zooi.png";
        private TransformComponent transform;
        public SpriteComponent()
        {

        }

        public override void Start()
        {
            transform = GetComponent<TransformComponent>();
        }

        public override void Render()
        {
            var sprite_ = ResourceManager.RequestSprite(sprite);
            sprite_.Position = new SFML.System.Vector2f(transform.position.x, transform.position.x);
            DisplayManager.window.Draw(sprite_);
        }
    }
}
