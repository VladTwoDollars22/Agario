using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public static class MovementInput
    {
        public static Vector2f direction;
        public static Vector2f GetInput()
        {
            return direction;
        }
        public static void UpdateInput()
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
    }
}
