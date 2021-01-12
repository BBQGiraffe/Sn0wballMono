using System;
namespace Sn0wballEngine
{
    public class SceneManager
    {
        private static Scene scene;

        public static void LoadScene(Scene scene)
        {
            SceneManager.scene = scene;
            scene?.Start();
        }

        public static void Update()
        {
            scene?.Update();
        }

        public static void RenderUI()
        {
            scene?.DrawUI();
        }

        public static Scene GetCurrentScene()
        {
            return scene;
        }
    }
}
