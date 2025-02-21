using AgarioGame.Engine;
using AgarioGame.Engine.Conrollers;
using SFML.System;
using System;

namespace AgarioGame.Game.Controllers
{
    public class AIController : Controller
    {
        private PlayableObject _playablePawn;
        private bool _isMoving;
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
            InitializeConditions();
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

            _isMoving = true;
            Pawn.SetVelocity(_isMoving ? _direction : new Vector2f(0, 0));
        }

        private void InitializeConditions()
        {
            _playablePawn.Animator.AddConditionToTransition("Idle", "Move", () => _isMoving && !_playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Idle", "Eat", () => _playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Move", "Idle", () => !_isMoving && !_playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Move", "Eat", () => _playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Eat", "Idle", () => !_playablePawn.IsEating);
        }
    }
}