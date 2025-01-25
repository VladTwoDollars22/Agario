using AgarioGame.Game;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class Food : GameObject
    {
        private float _mass;

        private bool _isEaten;

        private List<Color> _foodColors;

        public float Reward => _mass;
        public Food(GameLoop loop) : base()
        {
            _foodColors = GameConfig.FoodColors;

            SetGameField(GameConfig.GameFieldSize);

            _mass = GameConfig.FoodReward;

            RegisterObject(loop);

            SetRandomColor();
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
            _isEaten = true;
            SetVisiblity(false);
        }
        private void Respawn()
        {
            SetPosition(Mathematics.GetRandomPosition(GameConfig.GameFieldSize));

            _isEaten = false;

            SetRandomColor();
            SetVisiblity(true);
        }
        private void SetRandomColor()
        {
            int rand = Mathematics.GetRandomNumber(0, _foodColors.Count - 1);
            SetColor(_foodColors[rand]);
        }
    }
}
