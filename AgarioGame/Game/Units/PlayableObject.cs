using AgarioGame.Engine.Animation;
using AgarioGame.Engine.Core.Time;
using AgarioGame.Game.AudioExtensions;
using AgarioGame.Game.Configs;
using AgarioGame.Game.Factoryes;
namespace AgarioGame.Engine
{
    public class PlayableObject : GameObject
    {
        public Animator Animator;
        public bool IsEating;
        private bool _isMoving;

        private float _mass;
        private float _massFactor;
        private float _massGrowMultiplicator;

        private float baseSpeed;
        public float Mass => _mass;
        public PlayableObject() : base()
        {
            _mass = GameConfig.PlayerMass;
            _massFactor = GameConfig.MassFactor;
            _massGrowMultiplicator = GameConfig.MassGrowMult;
            baseSpeed = GameConfig.BaseSpeed;

            UpdateSpeed();

            SetSize(new(_mass / 2000f, _mass / 2000f));
            IsEating = false;
        }
        public override void Start()
        {
            InitializeConditions();
        }
        public override void Logic()
        {
            AnimationLogic();
        }
        public void SetAnimator(Animator newAnimator)
        {
            Animator = newAnimator; 
        }
        private void AnimationLogic()
        {
            if (GetVelocity() == new SFML.System.Vector2f(0,0))
            {
                _isMoving = false;
            }
            else
            {
                _isMoving = true;
            }
        }
        public void Eat(float newMass)
        {
            IsEating = true;
            TimerManager.Instance.SetTimeout(ResetEating, 1f);

            _mass += newMass * _massGrowMultiplicator;

            SetSize(new(_mass / 2000f, _mass / 2000f));

            UpdateSpeed();
        }
        private void ResetEating()
        {
            IsEating = false;
        }
        private void UpdateSpeed()
        {
            float newSpeed = baseSpeed / (float)Math.Sqrt(_mass * _massFactor);

            SetSpeed(newSpeed);
        }
        public void EatMe()
        {
            AudioSystem.PlaySound("eating");
            Destroy();
        }
        private void InitializeConditions()
        {
            Animator.AddConditionToTransition("Idle", "Move", () => _isMoving && !IsEating);
            Animator.AddConditionToTransition("Idle", "Eat", () => IsEating);
            Animator.AddConditionToTransition("Move", "Idle", () => !_isMoving && !IsEating);
            Animator.AddConditionToTransition("Move", "Eat", () => IsEating);
            Animator.AddConditionToTransition("Eat", "Idle", () => !IsEating);
        }
    }
}
