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
        public PlayableObject PlayablePawn => _playablePawn;

        private List<AIController> _enemyes;

        private bool _isMoving;
        private bool _idle;
        public AgarioPlayerController()
        {
            _onPawnUpdated += pawn => _playablePawn = pawn as PlayableObject;
        }
        public override void Update()
        {
            AudioProcess();
            AnimationProcess();
            Pawn.SetVelocity(_velocity);
        }
        public override void Start()
        {
            InitializeConditions();
            InitializekeyBinds();
        }
        public void SetEnemyes(List<AIController> AIControllers)
        {
            _enemyes = AIControllers;
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
        private void AnimationProcess()
        {
            if (_velocity == new Vector2f(0, 0))
            {
                _idle = true;
                _isMoving = false;
            }
            else
            {
                _isMoving = true;
                _idle = false;
            }
        }
        public void Swap()
        {
            int randInt = Mathematics.GetRandomNumber(0, _enemyes.Count - 1);

            PlayableObject playerPawn = PlayablePawn;

            SetPawn(_enemyes[randInt].Pawn);

            _enemyes[randInt].SetPawn(playerPawn);
        }
        public override void InputProcess()
        {
            _velocity = MovementInput.GetInput();
        }
        private void InitializeConditions()
        {
            _playablePawn.Animator.AddConditionToTransition("Idle", "Move", () => _isMoving && !_playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Idle", "Eat", () => _playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Move", "Idle", () => !_isMoving && !_playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Move", "Eat", () => _playablePawn.IsEating);
            _playablePawn.Animator.AddConditionToTransition("Eat", "Idle", () => !_playablePawn.IsEating);
        }

        public override void InitializekeyBinds()
        {
            KeyBindManager.AddKeyBind("Swap",SFML.Window.Keyboard.Key.F);
            KeyBindManager.GetKeyBind("Swap").AddOnDownCallback(Swap);
        }
    }
}
