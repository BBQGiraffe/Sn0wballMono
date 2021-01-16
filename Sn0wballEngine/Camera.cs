using System;
namespace Sn0wballEngine
{
    public class Camera
    {
        public static TransformComponent transform = new TransformComponent();

        public static SNVector2f ScreenToWorld(SNVector2f screenPos)
        {
            return transform.position + screenPos - (DisplayManager.WindowSize/2);
        }
    }
}
