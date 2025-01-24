using AgarioGame.Game;
using AgarioGame.Game.Factoryes;
using AgarioGame.Game.Units;

namespace AgarioGame.Engine
{
    public class GameRules
    {
        private GameLoop _gameLoop;

        private List<Controller> enemyList;
        private List<Food> foodList;

        private Controller _player;

        private int _foodCount;
        private int enemyCount;

        private UnitFactory _factory;
        public GameRules(GameLoop loop)
        {
            _gameLoop = loop;

            _foodCount = GameConfig.FoodCount;
            enemyCount = GameConfig.EmenyCount;

            enemyList = new();
            foodList = new();

            _factory = new(_gameLoop);
        }
        public void Initialisation()
        {
            InitializeFood();
            InitializePlayer();
            InitializeEnemyes();
        }
        private void InitializeFood()
        {
            for (int i = 0; i <= _foodCount; i++)
            {
                foodList.Add(_factory.InstantiateFood());
            }
        }
        private void InitializePlayer()
        {
            _player = _factory.InstantiatePlayer();
        }
        private void InitializeEnemyes()
        {
            for (int i = 0; i <= enemyCount; i++)
            {
                enemyList.Add(_factory.InstantiateEnemy());
            }
        }
        public void Logic()
        {
            CheckOccurences();

            if(InputManager.fIsPressed == true)
            {
                Swap();
            }
        }
        private void Swap()
        {
            int randInt = Mathematics.GetRandomNumber(0,enemyCount - 1);

            (enemyList[randInt].Pawn,_player.Pawn) = (_player.Pawn, enemyList[randInt].Pawn);

            InputManager.fIsPressed = false;
        }
        public void CheckOccurences()
        {
            foreach (Food f in foodList)
            {
                if (f.ObjectIn(_player.Pawn))
                {
                    f.EatMe();
                    _player.Pawn.Upgrade(f.Reward);
                }
            }

            foreach (Food f in foodList)
            {
                foreach (Controller e in enemyList)
                {
                    if (f.ObjectIn(e.Pawn))
                    {
                        f.EatMe();
                        e.Pawn.Upgrade(f.Reward);
                    }
                }     
            }

            foreach(Controller e in enemyList)
            {
                if (_player.Pawn.ObjectIn(e.Pawn))
                {
                    _player.Pawn.EatMe();
                    e.Pawn.Upgrade(_player.Pawn.Mass);
                }
                else if (e.Pawn.ObjectIn(_player.Pawn))
                {
                    e.Pawn.EatMe();
                    _player.Pawn.Upgrade(e.Pawn.Mass);
                }
            }
        }
    }
}
