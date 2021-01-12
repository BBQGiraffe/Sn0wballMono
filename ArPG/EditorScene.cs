using System;
using System.Collections.Generic;
using SFML.Graphics;
using Sn0wballEngine;
namespace ArPG
{
    public class EditorScene : Scene
    {
        TextBox AddEntityButton;
        List<TextBox> componentList = new List<TextBox>();
        void AddEntity()
        {

        }


        public override void Start()
        {
            Settings.SetSetting("editor_font", new Font("fonts/editor_font.ttf"));

            var font = Settings.GetSetting<Font>("editor_font");

            int y = 0;
            foreach(var component in Component.GetAllComponents())
            {
                var textbox = new TextBox();
                textbox.SetText(component.Name, "editor_font");
                textbox.SetPosition(new SNVector2f(0, y));
                y += 30;
                componentList.Add(textbox);

            }

       
            Game.Spawn(Entity.LoadFromPrefab("prefabs/mestiez.json"));

        }

        public override void DrawUI()
        {
            foreach(var textbox in componentList)
            {
                textbox.Draw();
            }
        }



    }
}
