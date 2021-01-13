using System;
using System.Collections.Generic;
using SFML.Graphics;
using Sn0wballEngine;
namespace ArPG
{
    public class EditorScene : Scene
    {
        

        public override void Update()
        {
           
        }

        public override void Start()
        {
            Settings.SetSetting("editor_font", new Font("fonts/editor_font.ttf"));
       
            

            Serialization.SerializeObject(new Tile(), "tile_template.json");


            var tile = WorldGenerator.Generate();
            Serialization.SerializeObject(tile, "levels/test.json");
            Game.CreateEntity("prefabs/mestiez.json").AddComponent(tile);
        }

        public override void DrawUI()
        {
            
        }



    }
}
