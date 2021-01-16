using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sn0wballEngine;
namespace ArPG
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Settings.SetSetting("game_name", "ArPG");
            DisplayManager.Init(1280, 720);

          
            

            Tilemap.tileset = Serialization.DeserializeObject<Tileset>("tiles/tileset.json");


            



            var config = Serialization.DeserializeObject<WorldConfig>("worldconfig.json");
            Settings.SetSetting("worldconf", config);



            SceneManager.LoadScene(new PrefabEditor());

            Input.LoadKeys();
                       
            while (DisplayManager.IsOpen())
            {
                Game.Update();
                Game.Render();
            }
        }
    }
}

