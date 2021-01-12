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
            DisplayManager.Init(800, 600);

            Tilemap.tileset = new Tileset();

            var json = JsonSerializer.Create();

            string[] files = System.IO.Directory.GetFiles("tiles", "*.json");

            foreach(var file in files)
            {
                var tile = json.Deserialize<Tile>(new JsonTextReader(File.OpenText(file)));
                Tilemap.tileset.tiles.Add(tile);

            }



            var filec = File.CreateText("tile.json");
            json.Serialize(filec, new Tile()
            {
                id = 0,
                sprite = "tiles/dirt",
                isObstacle = false
            });
            filec.Close();


            var config = json.Deserialize<WorldConfig>(new JsonTextReader(File.OpenText("worldconfig.json")));

            Settings.SetSetting("worldconf", config);


            var entity = json.Deserialize<Entity>(new JsonTextReader(File.OpenText("player.json")));
            entity.LoadFromFile();
            Game.entities.Add(entity);

            /*
            var entity = new Entity();
            entity.AddComponent<TransformComponent>();


            var f = File.CreateText("player.json");
            json.Serialize(new JsonTextWriter(f), entity);
            f.Close();


            */
            SceneManager.LoadScene(new EditorScene());

            Input.LoadKeys();

            //WorldGenerator.DumpBitmap(tilemap);
           
            while (DisplayManager.IsOpen())
            {
                Game.Update();
                Game.Render();
            }
        }
    }
}

