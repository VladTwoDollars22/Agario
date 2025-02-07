using AgarioGame.Engine;
using AgarioGame.Engine.Conrollers;
using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class AIController : Controller
    {
        private PlayableObject _playablePawn;

        public PlayableObject PPawn => _playablePawn;
        public AIController()
        {
            _onPawnUpdated += pawn => _playablePawn = pawn as PlayableObject;
        }
        public override void Update()
        {
            Pawn.SetVelocity(new Vector2f(0, 0));
        }
    }
}
