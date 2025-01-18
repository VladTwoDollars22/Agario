using System.Drawing;
using System.Numerics;
using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public class PlayerController : GameObject,IInputHandler
    {
        private float mass = 500f;
        public PlayerController(Vector2f spawnPos,float radius,SFML.Graphics.Color color,float speed) : base(spawnPos, radius, color)
        {
            SetSpeed(speed);
        }
        public void RegisterActor(GameLoop gameLoop)
        {
            gameLoop.UpdateInput += InputProcess;
        }
        public override void Logic()
        {
            SetRadius(mass / 10f);
            Move();
        }

        public void InputProcess()
        {
            SetVelocity(new Vector2f(0, 0));

            if (InputManager.KeyPressed(Keyboard.Key.Space))
            {
                mass+=0.01f;
            }

            Vector2f direction = new Vector2f();

            if (InputManager.KeyPressed(Keyboard.Key.W)) 
            {
                direction.Y -= 1f;
            }
            if (InputManager.KeyPressed(Keyboard.Key.S))
            {
                direction.Y += 1f;
            }
            if (InputManager.KeyPressed(Keyboard.Key.A)) 
            {
                direction.X -= 1f;
            }
            if (InputManager.KeyPressed(Keyboard.Key.D)) 
            {
                direction.X += 1f;
            }

            Console.WriteLine(direction);
            SetVelocity(direction);
        }
    }
}
