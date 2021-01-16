using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Sn0wballEngine
{
    public class Input
    {
        static Dictionary<string, int> keys { get; set; } = new Dictionary<string, int>();
        static Dictionary<string, KeyboardKey> axisKeys = new Dictionary<string, KeyboardKey>();
        static Dictionary<string, float> axes = new Dictionary<string, float>();

        public static float GetAxis(string axis)
        {
            float output = 0f;
            foreach(var key in axisKeys)
            {
                var button = key.Value;
                if(button.axis == axis)
                {
                    if (Input.IsKeyDown(button.keycode))
                    {
                        axes[button.axis] = button.value;
                        output = button.value;
                    }
                }



            }

            return output;
        }

        public static bool IsKeyDown(string key)
        {
            var key_sfml = keys[key];
            return SFML.Window.Keyboard.IsKeyPressed((SFML.Window.Keyboard.Key)key_sfml) && DisplayManager.IsFocused();
        }

        public static bool IsKeyDown(int keycode)
        {
            var key_sfml = (SFML.Window.Keyboard.Key)keycode;
            return SFML.Window.Keyboard.IsKeyPressed(key_sfml) && DisplayManager.IsFocused();
        }

        public static void LoadKeys()
        {
            keys = Serialization.DeserializeObject<Dictionary<string, int>>("input.json");
            axisKeys = Serialization.DeserializeObject<Dictionary<string, KeyboardKey>>("keybinds.json");

        }

        public static SNVector2f GetMousePosition()
        {
            var mouse = SFML.Window.Mouse.GetPosition(DisplayManager.window);
            return new SNVector2f(mouse.X, mouse.Y);
        }

        public static bool LeftClick()
        {
            return SFML.Window.Mouse.IsButtonPressed(SFML.Window.Mouse.Button.Left);
        }
    }
}
