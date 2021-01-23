using System;
using Sn0wballEngine;
namespace RobotController
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Settings.SetSetting("game_name", "Robot Communication Thing");

            DisplayManager.Init(800, 600);
            
            while (DisplayManager.IsOpen())
            {
                Game.Update();
                Game.Render();
            }

        }
    }
}
