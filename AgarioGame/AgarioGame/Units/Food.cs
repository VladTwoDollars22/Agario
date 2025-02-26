using AgarioGame.Game.AudioExtensions;
using AgarioGame.Game.Configs;
using SFML.Graphics;

namespace AgarioGame.Engine
{
    public class Food : GameObject
    {
        private float _mass;

        private bool _isEaten;

        private List<Color> _foodColors;

        public float Reward => _mass;
        public Food() : base()
        {
            _foodColors = GameConfig.FoodColors;
            _mass = GameConfig.FoodReward;
        }
        public override void Logic()
        {
            if(_isEaten == true)
            {
                Respawn();
            }
        }
        public void EatMe()
        {
            AgarioAudioSystem.PlaySound("eating");
            _isEaten = true;
            SetVisibility(false);
        }
        private void Respawn()
        {
            SetPosition(Mathematics.GetRandomPosition(GameConfig.GameFieldSize));

            _isEaten = false;

            SetRandomColor();
            SetVisibility(true);
        }
        public void SetRandomColor()
        {
            int rand = Mathematics.GetRandomNumber(0, _foodColors.Count - 1);
            SetColor(_foodColors[rand]);
        }
    }
}
