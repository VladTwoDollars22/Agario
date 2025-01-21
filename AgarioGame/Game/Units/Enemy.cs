using AgarioGame.Game;
using SFML.System;

namespace AgarioGame.Engine
{
    public class Enemy : GameObject
    {
        private float mass;
        private float massFactor;
        private float massGrowMultiplicator;

        private float baseSpeed;

        public float Mass => mass;
        public Enemy(Vector2f spawnPos, float radius, SFML.Graphics.Color color) : base(spawnPos, radius, color)
        {
            mass = GameConfig.PlayerMass;
            massFactor = GameConfig.MassFactor;
            massGrowMultiplicator = GameConfig.MassGrowMult;
            baseSpeed = GameConfig.BaseSpeed;

            SetGameField(GameConfig.GameFieldSize);

            UpdateSpeed();
        }
        public override void Logic()
        {

        }
        public void Upgrade(float newMass)
        {
            mass += newMass * massGrowMultiplicator;

            SetRadius(mass / 10f);

            UpdateSpeed();
        }
        private void UpdateSpeed()
        {
            float newSpeed = baseSpeed / (float)Math.Sqrt(mass * massFactor);

            SetSpeed(newSpeed);
        }
        public void EatMe()
        {
            Destroy();
        }
    }
}
