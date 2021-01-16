using System;
using Sn0wballEngine;
namespace ArPG
{
    public class PlayerBehaviour : Component, IAlive
    {
        public int Health { get; set; }
        public int speed { get; set; }


        private TransformComponent transform;
        private SpriteComponent sprite;


        public override void Start()
        {
            sprite = GetComponent<SpriteComponent>();
            transform = GetComponent<TransformComponent>();
            sprite.sprite = "player/player_side.png";
        }

        public override void Update()
        {
            transform.velocity = SNVector2f.Zero();
            transform.velocity.x = Input.GetAxis("horizontal") * speed;
            transform.velocity.y = Input.GetAxis("vertical") * speed;


            Camera.transform.position = transform.position;
        }

        public void Hit(IAlive alive)
        {

        }
    }
}
