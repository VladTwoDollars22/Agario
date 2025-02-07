using AgarioGame.Game;
using AgarioGame.Game.AudioExtensions;
namespace AgarioGame.Engine
{
    public class PlayableObject : GameObject
    {
        private float mass;
        private float massFactor;
        private float massGrowMultiplicator;

        private float baseSpeed;
        public float Mass => mass;
        public PlayableObject() : base()
        {
            mass = GameConfig.PlayerMass;
            massFactor = GameConfig.MassFactor;
            massGrowMultiplicator = GameConfig.MassGrowMult;
            baseSpeed = GameConfig.BaseSpeed;

            UpdateSpeed();
        }
        public override void Logic()
        {
            
        }
        public void Upgrade(float newMass)
        {
            mass += newMass * massGrowMultiplicator;

            SetRadius(mass / 12.5f);

            UpdateSpeed();
        }
        private void UpdateSpeed()
        {
            float newSpeed = baseSpeed / (float)Math.Sqrt(mass * massFactor);

            SetSpeed(newSpeed);
        }
        public void EatMe()
        {
            AudioSystem.PlaySound("eating");
            Destroy();
        }
    }
}
