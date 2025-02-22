using AgarioGame.Engine;
using AgarioGame.Engine.Conrollers;
using SFML.System;
using System;

namespace AgarioGame.Game.Controllers
{
    public class AIController : Controller
    {
        private PlayableObject _playablePawn;
        private Vector2f _direction;
        private float _changeDirectionTime;
        private const float ChangeInterval = 5.0f;

        public PlayableObject PPawn => _playablePawn;

        public AIController()
        {
            _onPawnUpdated += pawn => _playablePawn = pawn as PlayableObject;
        }

        public override void Start()
        {
            _direction = Mathematics.GetRandomDirection();
            _changeDirectionTime = ChangeInterval;
        }

        public override void Update()
        {
            if (!_isActive) return;

            _changeDirectionTime -= Engine.Core.Time.Time.DeltaTime;

            if (_changeDirectionTime <= 0)
            {
                _direction = Mathematics.GetRandomDirection();
                _changeDirectionTime = ChangeInterval;
            }

            Pawn.SetVelocity(_direction);
        }
    }
}