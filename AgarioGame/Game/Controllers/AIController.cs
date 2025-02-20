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
        private int _directionChangeCount;
        private const float ChangeInterval = 2.0f;
        private const int MaxDirectionChanges = 3;

        public PlayableObject PPawn => _playablePawn;

        public AIController()
        {
            _onPawnUpdated += pawn => _playablePawn = pawn as PlayableObject;
        }

        public override void Start()
        {
            InitializeConditions();
            _direction = GetRandomDirection();
            _changeDirectionTime = ChangeInterval;
            _directionChangeCount = 0;
        }

        public override void Update()
        {
            if (_directionChangeCount < MaxDirectionChanges)
            {
                _changeDirectionTime -= Engine.Core.Time.Time.DeltaTime;

                if (_changeDirectionTime <= 0)
                {
                    _direction = GetRandomDirection();
                    _directionChangeCount++;
                    _changeDirectionTime = ChangeInterval;
                }

                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }

            Pawn.SetVelocity(_isMoving ? _direction : new Vector2f(0, 0));
        }

        private Vector2f GetRandomDirection()
        {
            Random rand = new Random();
            float angle = (float)(rand.NextDouble() * Math.PI * 2);
            return new Vector2f((float)Math.Cos(angle), (float)Math.Sin(angle));
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
