using System;
using System.Collections.Generic;
using SFML.System;
namespace Sn0wballEngine
{
    public class Game
    {
        static List<Entity> entities = new List<Entity>();
        static Clock deltaClock = new Clock();

        public static void Update() {
            Time.deltaTime = deltaClock.Restart().AsSeconds();
            SceneManager.Update();
            DisplayManager.HandleInput();
        }

        public static void RenderUI()
        {
            SceneManager.RenderUI();
        }

        public static void LoadSettings()
        {

        }

    }
}
