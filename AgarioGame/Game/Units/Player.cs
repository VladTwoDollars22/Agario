using System.Drawing;
using System.Numerics;
using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public class Player : GameObject,IInputHandler
    {
        private float mass = 500f;
        public Player(Vector2f spawnPos,float radius,SFML.Graphics.Color color,float speed) : base(spawnPos, radius, color)
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

            SetVelocity(InputManager.GetInput());
        }
    }
}
