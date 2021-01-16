using System;
using System.Collections.Generic;
using SFML.Graphics;
namespace Sn0wballEngine
{
    public class WidgetWindow : Widget
    {
        public List<Widget> widgets = new List<Widget>();

        RectangleShape background = new RectangleShape();

        SNVector2f offset = new SNVector2f();

        private int count = 0;

        void HandleMouse()
        {
            if (Clicked())
            {
                foreach(var widget in widgets)
                {
                    if (widget.Clicked())
                    {
                        return;
                    }
                }



                if (Dragged())
                {
                    var mouse = Input.GetMousePosition() - position;
                    position += mouse;
                }


            }
        }

        public void AddWidget(Widget widget)
        {
            widget.id = count;
            count++;
            widgets.Add(widget);
        }

        public override void Draw()
        {
            HandleMouse();
            background.FillColor = new Color(color.r, color.g, color.b);
            background.Position = new SFML.System.Vector2f(position.x - 25, position.y - 25);
            background.Size = new SFML.System.Vector2f(GetBounds().x + 50, GetBounds().y + 50);

            DisplayManager.window.Draw(background);

            float y = position.y + 5;
            foreach(var widget in widgets)
            {
                widget.position.x = position.x + GetBounds().x / 2 - widget.GetBounds().x / 2;


                widget.position.y = y;

                y += widget.GetBounds().y;

                widget.Draw();

            }

            if (Clicked())
            {

            }

        }
        public WidgetWindow()
        {
            color = new SNColor()
            {
                r = 80,
                g = 80,
                b = 80,
                a = 240
            };
        }

        public override bool Hovering()
        {
            return Collision.BoxAndPoint(Input.GetMousePosition(), position - 25, (int)GetBounds().x + 50, (int)GetBounds().y + 50);
        }

        public override SNVector2f GetBounds()
        {
            float width = 0;
            float height = 0;
            foreach(var widget in widgets)
            {
                height += widget.GetBounds().y;
                if(widget.GetBounds().x > width)
                {
                    width = widget.GetBounds().x;
                }
            }

            return new SNVector2f(width, height);
        }

    }
}
