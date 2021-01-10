using System;

namespace Sn0wballEngine
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Settings.SetSetting("game_name", "DOOM");
            DisplayManager.Init(1280, 720);
            Entity entity = new Entity();
            entity.AddComponent<TransformComponent>().x = 69;

            entity.SaveAsPrefab("testentity");
            while (DisplayManager.IsOpen())
            {
                Game.Update();
            }
        }
    }
}
