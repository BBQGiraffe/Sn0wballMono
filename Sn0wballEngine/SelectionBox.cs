using System;
using System.Collections.Generic;

namespace Sn0wballEngine
{
    public class SelectionBox : Widget
    {
        public List<TextBox> boxes = new List<TextBox>();

        public SelectionBox()
        {
            color = new SNColor()
            {
                r = 0,
                g = 0,
                b = 0
            };
        }



        public void AddBox(string text, string font)
        {
            var box = new TextBox
            {
                id = boxes.Count
            };

            box.SetText(text, font, SNColor.White());
            boxes.Add(box);
        }


        public override void Draw()
        {
            float y = position.y; 
            foreach(var box in boxes)
            {
                box.position.y = y;
                box.position.x = position.x - box.GetBounds().x / 2;
                box.Draw();
               

                y += box.GetBounds().y;
            }
        }

        public override SNVector2f GetBounds()
        {
            var output = new SNVector2f();

            float bigY = 0;
            foreach(var box in boxes)
            {
                output.y += box.GetBounds().y;

                if(box.GetBounds().x > bigY)
                {
                    bigY = box.GetBounds().x;
                }
                
            }
            

            return output;
        }
    }
}
