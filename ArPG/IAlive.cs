using System;
namespace ArPG
{
    public interface IAlive
    {
        int Health { get; set; }
        void Hit(IAlive alive);

    }
}
