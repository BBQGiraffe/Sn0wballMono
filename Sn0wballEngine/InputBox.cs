using System;
using SFML.Window;

namespace Sn0wballEngine
{
    public class InputBox : Widget
    {
        TextBox textBox = new TextBox();
        bool selected = false;





        float enterTimer = 0, enterTime = .3f;
        public override void Draw()
        {
            enterTimer += Time.deltaTime;

            if (Clicked())
            {
                selected = true;
            }

            if (Input.LeftClick() && !Hovering())
            {
                selected = false;
            }

            if (selected)
            {
                if (Input.IsKeyDown("Return"))
                {
                    if (enterTimer >= enterTime)
                    {
                        text += "\n";
                        enterTimer = 0;

                    }

                }
            }
            textBox.position = position;
            textBox.Draw();

            inputTimer += Time.deltaTime;



        }

        public InputBox()
        {
            DisplayManager.window.TextEntered += Window_TextEntered;
            textBox.SetText("Entity Name", "editor_font", SNColor.White());
        }

        void Window_TextEntered(object sender, TextEventArgs e)
        {
            if (selected)
            {
                text += e.Unicode.ToString();
                textBox.SetText(text, "editor_font", SNColor.White());
            }


        }

        public string GetText()
        {
            return text;    
        }

        float inputTime = .1f, inputTimer = 0f;

        string text = "";

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
