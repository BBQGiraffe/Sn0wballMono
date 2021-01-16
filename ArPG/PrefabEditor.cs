using System;
using System.Collections.Generic;
using SFML.Graphics;
using Sn0wballEngine;
namespace ArPG
{
    public class PrefabEditor : Scene
    {
        Entity entity;

        WidgetWindow window;
        List<Type> components = new List<Type>();
        public override void Start()
        {
            entity = Game.CreateEntity();
            entity.AddComponent<TransformComponent>();
            SNGui.Init();


            Settings.SetSetting("editor_font", new Font("fonts/editor_font.ttf"));


            components = Component.GetAllComponents();

            savePrefab.SetText("Add Component", "editor_font", SNColor.White());





            window = new WidgetWindow();

          
            foreach(var componet in components)
            {
                var textbox = new TextBox();
                textbox.SetText(componet.Name, "editor_font", SNColor.White());
                window.AddWidget(textbox);
            }



            window.position.x = 500;
            SNGui.AddWidget(window);
            window.hidden = true;


            SNGui.AddWidget(savePrefab);
            savePrefab.SetText("Save Prefab", "editor_font", SNColor.White());

            savePrefab.position.y = DisplayManager.WindowSize.y - savePrefab.GetBounds().x / 4;

            addComponent.SetText("add component", "editor_font", SNColor.White());
            SNGui.AddWidget(addComponent);




            addedComponents.position.y = addComponent.GetBounds().y * 1.5f;
            SNGui.AddWidget(addedComponents);


            var textbox2 = new TextBox();
            textbox2.SetText("TransformComponent", "editor_font", SNColor.White());
            addedComponents.AddWidget(textbox2);
            SNGui.AddWidget(componentProperties);

            SNGui.AddWidget(entityName);
            entityName.position.x = 100;
            entityName.position.y = 200;

        }
        WidgetWindow componentProperties = new WidgetWindow();
        WidgetWindow addedComponents = new WidgetWindow();

        public TextBox addComponent = new TextBox();
        public TextBox savePrefab = new TextBox();

        InputBox entityName = new InputBox();

        public override void Update()
        {
            if(addComponent.Clicked()){
                window.hidden = false;
            }

            componentProperties.position.x = DisplayManager.WindowSize.x - componentProperties.GetBounds().x;


            if (!window.hidden && !addComponent.Hovering())
            {
                foreach (var button in window.widgets)
                {
                    if (button.Clicked() && !window.hidden)
                    {
                        entity.AddComponent(components[button.id]);
                        var text = new TextBox();
                        text.SetText(components[button.id].Name, "editor_font", SNColor.White());
                        addedComponents.AddWidget(text);
                        window.hidden = true;
                        break;
                    }


                }
            }

            foreach(var widget in addedComponents.widgets)
            {
                if (widget.Clicked())
                {
                    componentProperties.widgets.Clear();
                    var component = entity.components[widget.id].GetType();
                    foreach (var property in component.GetProperties())
                    {
                        var textbox = new TextBox();
                        textbox.SetText(property.Name, "editor_font", SNColor.White());
                        componentProperties.AddWidget(textbox);
                    }
                }
            }

            if (savePrefab.Clicked())
            {
                Serialization.SerializeObject(entity, "prefabs/test_prefab.json");
            }
        }

        public override void DrawUI()
        {
            SNGui.Draw();
        }

    }
}
