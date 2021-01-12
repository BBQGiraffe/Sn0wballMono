using System;
using Sn0wballEngine;
namespace ArPG
{
    public class PlayerClass : Component
    {
        public int health { get; set;}
        public TransformComponent transform;

        public PlayerClass()
        {

        }

        public override void Start()
        {
             Console.Write("wow that worked?");
        }
    }
}
