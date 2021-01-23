using System;
using Sn0wballEngine;
namespace FallingSand
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Settings.SetSetting("game_name", "Particle Thingy");
            DisplayManager.Init(1024, 1024);
            //DisplayManager.SetFramerateLimit(60);

            SceneManager.LoadScene(new GameScene());
            Input.LoadKeys();

            
            while (DisplayManager.IsOpen())
            {
                Game.Update();
                Game.Render();
            }
        }
    }
}
