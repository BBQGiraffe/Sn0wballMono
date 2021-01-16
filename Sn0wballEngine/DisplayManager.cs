using System;
using SFML.Window;
using SFML.Graphics;
using System.Text;
using Newtonsoft.Json;
namespace Sn0wballEngine
{
    public class DisplayManager
    {
        public static RenderWindow window;
        public static SNVector2f WindowSize;
        public static void Init(uint width, uint height)
        {
            Settings.SetSetting("window_width", width);
            Settings.SetSetting("window_height", height);
            var windowName = Settings.GetSetting<string>("game_name");

            window = new RenderWindow(new VideoMode(width, height), windowName);
            window.SetFramerateLimit(60);
            WindowSize = new SNVector2f(width, height);
        }

        public static void Clear()
        {
            window.Clear();
        }

        public static void Present()
        {
            window.Display();
        }

        public static bool IsOpen()
        {
            return window.IsOpen;
        }

        public static bool IsFocused()
        {
            return window.HasFocus();
        }

        public static void LoadSettings()
        {

        }

        public static void HandleInput()
        {
            window.DispatchEvents();
        }

        public static void SetFramerateLimit(uint fps)
        {
            window.SetFramerateLimit(fps);
        }

        
    }
}
