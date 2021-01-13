using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Sn0wballEngine
{
    public class Input
    {
        static Dictionary<string, int> keys { get; set; } = new Dictionary<string, int>();
        public static bool IsKeyDown(string key)
        {
            var key_sfml = keys[key];
            return SFML.Window.Keyboard.IsKeyPressed((SFML.Window.Keyboard.Key)key_sfml) && DisplayManager.IsFocused();
        }

        

        public static void LoadKeys()
        {
            keys = Serialization.DeserializeObject<Dictionary<string, int>>("input.json");
           
        }

        public static SNVector2f GetMousePosition()
        {
            var mouse = SFML.Window.Mouse.GetPosition(DisplayManager.window);
            return new SNVector2f(mouse.X, mouse.Y);
        }
    }
}
