using System;
using Sn0wballEngine;
namespace Raycaster
{
    public class PlayerBehaviour : Component
    {
        public TransformComponent transform;
        public SNVector2f dir = new SNVector2f(-1, 0);
        public SNVector2f plane = new SNVector2f(0, 0.66f);

        float rotation = 0;
        public override void Start()
        {
            transform = GetComponent<TransformComponent>();
            transform.position = new SNVector2f(3, 4);
        }

        float moveSpeed = 5;
        public override void Update()
        {
            float oldRot = rotation;
            if (Input.IsKeyDown("Up"))
            {
                transform.position.x += dir.x * moveSpeed * Time.deltaTime;
                transform.position.y += dir.y * moveSpeed * Time.deltaTime;
            }

            if (Input.IsKeyDown("Right"))
            {
                rotation += 3 * Time.deltaTime;
            }

            if (Input.IsKeyDown("Left"))
            {
                rotation -= 3 * Time.deltaTime;
            }

            dir.x = (float)Math.Cos(rotation);
            dir.y = (float)Math.Sin(rotation);

            float oldPlaneX = plane.x;

            plane.x = plane.x * (float)Math.Cos(rotation - oldRot) - plane.y * (float)Math.Sin(rotation - oldRot);
            plane.y = oldPlaneX * (float)Math.Sin(rotation - oldRot) + plane.y * (float)Math.Cos(rotation - oldRot);
        }
    }
}
