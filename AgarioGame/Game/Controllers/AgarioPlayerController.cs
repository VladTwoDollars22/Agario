using AgarioGame.Engine;
using AgarioGame.Engine.Core.Input.Conrollers;
using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class AgarioPlayerController : PlayerController
    {
        private Vector2f _velocity;
        private PlayableObject _playablePawn;
        public PlayableObject PPawn => _playablePawn;
        public AgarioPlayerController()
        {
            _onPawnUpdated += pawn => _playablePawn = pawn as PlayableObject;
        }
        public override void Update()
        {
            Pawn.SetVelocity(_velocity);
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
