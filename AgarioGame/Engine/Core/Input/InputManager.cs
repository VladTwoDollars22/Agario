using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public static class InputManager
    {
        public static bool KeyPressed(Keyboard.Key key)
        {
            if (Keyboard.IsKeyPressed(key))
            {
                return true;
            }

            return false;
        }

        public static Vector2f GetMousePosition()
        {
            Vector2f position = new Vector2f();
            Vector2i mousePos = Mouse.GetPosition();

            position.X = mousePos.X;
            position.Y = mousePos.Y;

            return position;
        }
    }
}
