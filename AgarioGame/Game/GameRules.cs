using AgarioGame.Game;
using AgarioGame.Game.Controllers;
using AgarioGame.Game.Factoryes;
using SFML.Window;
using AgarioGame.Engine.Core.Input.KeyBind;

namespace AgarioGame.Engine
{
    public class GameRules
    {
        private GameLoop _gameLoop;

        private List<AgarioController> enemyList;
        private List<Food> foodList;

        private AgarioController _player;

        private int _foodCount;
        private int enemyCount;

        private UnitFactory _factory;
        private KeyBindManager _kbManager;
        public GameRules(GameLoop loop)
        {
            _gameLoop = loop;

            _foodCount = GameConfig.FoodCount;
            enemyCount = GameConfig.EmenyCount;

            enemyList = new();
            foodList = new();

            _factory = new(_gameLoop);
            _kbManager = new(_gameLoop);
        }
        public void Initialisation()
        {
            InitializekeyBinds();
            InitializeFood();
            InitializePlayer();
            InitializeEnemyes();
        }
        private void InitializekeyBinds()
        {
           _kbManager.AddKeyBind("Swap", Keyboard.Key.F);
           _kbManager.GetKeyBind("Swap").AddOnDownCallback(Swap);
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
            _player = _factory.InstantiatePlayer(false);
        }
        private void InitializeEnemyes()
        {
            for (int i = 0; i <= enemyCount; i++)
            {
                enemyList.Add(_factory.InstantiatePlayer(true));
            }
        }
        public void Logic()
        {
            CheckOccurences();
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
                foreach (AgarioController e in enemyList)
                {
                    if (f.ObjectIn(e.Pawn))
                    {
                        f.EatMe();
                        e.Pawn.Upgrade(f.Reward);
                    }
                }     
            }

            foreach(AgarioController e in enemyList)
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
