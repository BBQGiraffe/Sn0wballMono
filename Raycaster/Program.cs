using System;
using Sn0wballEngine;
namespace Raycaster
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Settings.SetSetting("game_name", "Sn0wCaster");
            DisplayManager.Init(640, 480);

            SceneManager.LoadScene(new RaycasterScene());
            Input.LoadKeys();
            while (DisplayManager.IsOpen())
            {
                Game.Update();
                Game.Render();
            }
        }
    }
}
