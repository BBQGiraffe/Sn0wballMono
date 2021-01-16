using System;
using SFML.Window;

namespace Sn0wballEngine
{
    public class InputBox : Widget
    {
        TextBox textBox = new TextBox();
        bool selected = false;


        SFML.Window.Event Event;

        public override void Draw()
        {


            if (Clicked())
            {
                selected = true;
            }

            if(Input.LeftClick() && !Hovering())
            {
                selected = false;
            }

            if (selected)
            {

            }
            textBox.SetText(text, "editor_font", SNColor.White());
            textBox.position = position;
            textBox.Draw();

            inputTimer += Time.deltaTime;



        }

        public InputBox()
        {
            DisplayManager.window.TextEntered += Window_TextEntered;
        }

        void Window_TextEntered(object sender, TextEventArgs e)
        {
            if (selected)
            {
                Console.WriteLine("shit");
                text += e.Unicode.ToString();
                textBox.SetText(text, "editor_font", SNColor.White());
            }

        }


        float inputTime = .1f, inputTimer = 0f;

        string text = "bingus";

        public override SNVector2f GetBounds()
        {
            return textBox.GetBounds();
        }

        public override void SetBackgroundColor(SNColor color)
        {
            textBox.SetBackgroundColor(color);
        }
    }
}
