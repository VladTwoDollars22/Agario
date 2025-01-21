using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public static class InputManager
    {
        public static Vector2f direction;
        public static bool fIsPressed;
        public static Vector2f GetInput()
        {
            return direction;
        }
        public static void UpdateInput()
        {
            UpdateDirectionInput();
            UpdateActionsInput();
        }
        public static void UpdateActionsInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
            {
                fIsPressed = true;
            }
        }
        public static void UpdateDirectionInput()
        {
            direction = new(0, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                direction.Y -= 1f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                direction.Y += 1f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                direction.X -= 1f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                direction.X += 1f;
            }
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
