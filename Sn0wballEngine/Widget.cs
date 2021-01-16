using System;
using SFML.System;

namespace Sn0wballEngine
{
    public class Widget
    {
        public SNVector2f position { get; set; } = new SNVector2f();
        public SNColor color { get; set; } = new SNColor();
        public int id;
        public bool hidden = false;

        public virtual SNVector2f GetBounds()
        {
            return new SNVector2f(0, 0);
        }
        public virtual void Draw()
        {

        }

        public virtual bool Hovering()
        {
            return Collision.BoxAndPoint(Input.GetMousePosition(), position, (int)GetBounds().x, (int)GetBounds().y);
        }

        public bool Clicked()
        {
            return Hovering() && Input.LeftClick();
        }

        Clock dragClock = new Clock();

        public bool Dragged()
        {
            if(Clicked() && dragClock.ElapsedTime.AsMilliseconds() >= 100)
            {
                return true;
            }
            else
            {
                dragClock.Restart();
                return false;
            }
        }

        public virtual void SetBackgroundColor(SNColor color)
        {

        }
    }
}
