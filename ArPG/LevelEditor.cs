using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SFML.Graphics;
using Sn0wballEngine;
using Microsoft.CSharp;

namespace ArPG
{
    public class LevelEditor : Scene
    {

        public float spawnTimer = .3f, spawnTime = .3f;


        public void HandleObjectCreation()
        {
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnTime)
            {
                if (Input.IsKeyDown("G"))
                {
                    var entity = Game.Instantiate(SpawnableObjects[0]);
                    var mouse = Camera.ScreenToWorld(Input.GetMousePosition());
                    
                    entity.GetComponent<TransformComponent>().position = new SNVector2f(mouse.x, mouse.y);
                    spawnTimer = 0f;

                    Console.WriteLine(mouse.y);

                }

            }

            float cameraVel = 15f;

            Camera.transform.position.x += Input.GetAxis("horizontal") * cameraVel;
            Camera.transform.position.y += Input.GetAxis("vertical") * cameraVel;

        }

        public override void Update()
        {
            HandleObjectCreation();
        }

        TextBox fps = new TextBox();
        TextBox sceneview = new TextBox();

        public List<Entity> SpawnableObjects = new List<Entity>();

        public void LoadObjectDefs()
        {
            var files = Directory.GetFiles("prefabs", "*.json");
            foreach(var file in files)
            {
                var entity = Serialization.DeserializeObject<Entity>(file);
                SpawnableObjects.Add(entity);
                
            }
        }

        public override void Start()
        {
            Settings.SetSetting("editor_font", new Font("fonts/editor_font.ttf"));

            LoadObjectDefs();


        }



        public override void DrawUI()
        {
            int y = 30;


            foreach(var spawnableObject in SpawnableObjects)
            {
                //TextBox.Draw(spawnableObject.name, "editor_font");
                y += 24;

            }
        }



    }
}
