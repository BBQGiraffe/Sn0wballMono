using System;
using System.Collections.Generic;

namespace Sn0wballEngine
{
    public class SNGui
    {
        static List<Widget> widgets = new List<Widget>();
        public static void AddWidget(Widget widget)
        {
            widget.hidden = false;
            widgets.Add(widget);
        }
        public static void Init()
        {

        }

        public static void Draw()
        {
            foreach(var widget in widgets)
            {
                if (widget.hidden) { continue; }
                widget.Draw();
            }
        }

    }
}
