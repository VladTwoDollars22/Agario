using SFML.Window;
using SFML.System;

namespace AgarioGame.Engine.Core.Input
{
    public static class MouseInput
    {
        private static Vector2f mousePos;

        public static void UpdateInput()
        {
            if (GameLoop.Window != null)
            {
                Vector2i pixelPos = Mouse.GetPosition(GameLoop.Window);
                mousePos = GameLoop.Window.MapPixelToCoords(pixelPos);
            }
        }

        public static Vector2f GetPosition()
        {
            return mousePos;
        }
    }
}
