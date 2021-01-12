using System;
using SFML.Graphics;
namespace Sn0wballEngine
{
    public class TextBox
    {
        float clickTime = .3f, clickTimer;

        private Text textbox;
        public void Draw()
        {
            DisplayManager.window.Draw(textbox);
        }

        public void SetPosition(SNVector2f position)
        {
            textbox.Position = new SFML.System.Vector2f(position.x, position.y);
        }

        public void SetText(string text, string fontname)
        {
            var font = Settings.GetSetting<Font>(fontname);
            textbox = new Text(text, font);
            textbox.CharacterSize = 24;
            textbox.Color = new Color(255, 255, 255);
        }

        static bool Hovering()
        {
            return false;
        }

        public static bool Clicked()
        {
            return false;
        }


    }
}
