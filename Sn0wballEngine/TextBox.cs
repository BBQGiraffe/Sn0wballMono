using System;
using SFML.Graphics;
namespace Sn0wballEngine
{
    public class TextBox : Widget
    {
        private Text textbox;
        private RectangleShape background;
        public SNColor backgroundColor { get; set; } = new SNColor();
        private string text;
        private int width, height;

        public void SetText(string text, string fontname, SNColor color)
        {

            var font = Settings.GetSetting<Font>(fontname);
            textbox = new Text(text, font);
            textbox.CharacterSize = 24;
            this.text = text;
            textbox.Color = new Color(color.r, color.g, color.b, color.a);

            width = (int)textbox.GetLocalBounds().Width;
            height = (int)textbox.GetLocalBounds().Height;

            background = new RectangleShape();
            background.FillColor = new Color(50, 50, 50);

            
        }

        public override void SetBackgroundColor(SNColor color)
        {
            background.FillColor = new Color(color.r, color.g, color.b);
        }

        public TextBox()
        {
            //SetText("EXAMPLE TEXT", "editor_font", SNColor.White());
        }


        public SNColor hoverColor = new SNColor()
        {
            r = 100,
            g = 100,
            b = 100
        };

        public SNColor clickColor = new SNColor()
        {
            r = 50,
            g = 50,
            b = 50
        };


        public override void Draw()
        {

            SetBackgroundColor(new SNColor()
            {
                r = 150,
                g = 150,
                b = 150
            });
            if (Hovering())
            {
                SetBackgroundColor(hoverColor);
            }
            if (Clicked())
            {
                SetBackgroundColor(clickColor);
            }


            var bounds = new SNVector2f(width, height);

            textbox.Position = new SFML.System.Vector2f(position.x + bounds.x / 4, position.y + bounds.y / 2);
            background.Position = new SFML.System.Vector2f(position.x, position.y);
            background.Size = new SFML.System.Vector2f(bounds.x + bounds.x / 2, bounds.y + bounds.y * 2);

            DisplayManager.window.Draw(background);
            DisplayManager.window.Draw(textbox);
        }

        public void Select()
        {

        }

        public string GetText()
        {
            return text;
        }




        public override SNVector2f GetBounds()
        {
            var bounds = new SNVector2f(width, height);
            background.Size = new SFML.System.Vector2f(bounds.x + bounds.x / 2, bounds.y + bounds.y * 2);
            return new SNVector2f(background.Size.X, background.Size.Y);
        }

    }
}
