using AgarioGame.Engine;
using AgarioGame.Engine.Conrollers;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Game.AudioExtensions;
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
            AudioProcess();
            Pawn.SetVelocity(_velocity);
        }
        private void AudioProcess()
        {
            if (_velocity == new Vector2f(0, 0))
            {
                return;
            }
            else
            {
                AudioSystem.PlaySound("moving");
            }
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
