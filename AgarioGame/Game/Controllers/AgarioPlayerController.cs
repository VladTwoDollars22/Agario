using AgarioGame.Engine;
using AgarioGame.Engine.Core.Input.Conrollers;
using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class AgarioPlayerController : PlayerController
    {
        private Vector2f _velocity;
        private PlayableObject _pawn;

        public AgarioPlayerController(GameObject pawn)
        {
            _pawn = (PlayableObject)pawn;
            SetPawn(pawn);
        }

        public override void Update()
        {
            _pawn.SetVelocity(_velocity);
        }

        public override void InputProcess()
        {
            _velocity = MovementInput.GetInput();
        }

        public override void InitializekeyBinds()
        {
            
        }
    }
}
