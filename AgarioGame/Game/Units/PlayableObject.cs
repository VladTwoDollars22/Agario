using AgarioGame.Engine.Animation;
using AgarioGame.Game;
using AgarioGame.Game.AudioExtensions;
using AgarioGame.Game.Factoryes;
namespace AgarioGame.Engine
{
    public class PlayableObject : GameObject
    {
        public Animator Animator;
        public bool IsEating;

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

            Animator = AnimatorFactory.InitializePlayerAnimator(Sprite);
        }
        public override void Logic()
        {
            
        }
        public void Eat(float newMass)
        {
            IsEating = true;

            _mass += newMass * _massGrowMultiplicator;

            SetSize(new(_mass / 2000f, _mass / 2000f));

            UpdateSpeed();
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
    }
}
