using AgarioGame.Engine;
using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class PlayerController : BaseController,IInputHandler
    {
        private Vector2f _velocity;
        public PlayerController(GameLoop loop) : base(loop) 
        {
            RegisterActor(loop);
        }
        public void RegisterActor(GameLoop loop)
        {
            loop.UpdateEvent += InputProcess;
        }
        public override void Update()
        {
            Pawn.SetVelocity(_velocity);
        }

        public void InputProcess()
        {
            _velocity = InputManager.GetInput();
        }
    }
}
