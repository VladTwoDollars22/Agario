using AgarioGame.Game;
using AgarioGame.Game.Controllers;
using AgarioGame.Game.Factoryes;
using AgarioGame.Engine.Factories;
using AgarioGame.Game.AudioExtensions;
using AgarioGame.Engine.Core.Input.KeyBind;

namespace AgarioGame.Engine
{
    public class GameRules
    {
        private GameLoop _gameLoop;

        private List<AIController> enemyList;

        private List<Food> foodList;

        private AgarioPlayerController _player;

        private int _foodCount;
        private int enemyCount;

        private UnitFactory _factory;
        private GameObjectFactory _gameObjFactory;
        private ControllerFactory _controllerFactory;
        private KeyBindManager _keyBindManager;
        public GameRules(GameLoop loop)
        {
            _gameLoop = loop;

            enemyList = new();
            foodList = new();

            _gameObjFactory = new(_gameLoop);
            _controllerFactory = new(_gameLoop);
            _keyBindManager = new(_gameLoop);

            _factory = new(_gameObjFactory,_controllerFactory);
        }
        public void Initialisation()
        {
            InitializeConfigs();
            InitializeAudio();
            InitializeFood();
            InitializeEnemyes();
            InitializePlayer();
        }
        private void InitializeAudio()
        {
            AudioSystem.InitializeAudio();

            AudioSystem.PlaySound("gamestarted");
        }
        private void InitializeConfigs()
        {
            GameConfig.Initialize();

            _foodCount = GameConfig.FoodCount;
            enemyCount = GameConfig.EnemyCount;

            AudioConfig.Initialize();
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
            _player = _factory.InstantiatePlayer(this);
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
        }
        public void Swap()
        {
            int randInt = Mathematics.GetRandomNumber(0,enemyCount - 1);

            PlayableObject playerPawn = _player.PPawn;

            _player.SetPawn(enemyList[randInt].Pawn);

            enemyList[randInt].SetPawn(playerPawn);
        }
        public void CheckOccurences()
        {
            foreach (Food f in foodList)
            {
                if (f.ObjectIn(_player.Pawn))
                {
                    f.EatMe();
                    _player.PPawn.Upgrade(f.Reward);
                }
            }

            foreach (Food f in foodList)
            {
                foreach (AIController e in enemyList)
                {
                    if (f.ObjectIn(e.Pawn))
                    {
                        f.EatMe();
                        e.PPawn.Upgrade(f.Reward);
                    }
                }     
            }

            foreach(AIController e in enemyList)
            {
                if (_player.Pawn.ObjectIn(e.Pawn))
                {
                    _player.PPawn.EatMe();
                    e.PPawn.Upgrade(_player.PPawn.Mass);
                }
                else if (e.Pawn.ObjectIn(_player.Pawn))
                {
                    e.PPawn.EatMe();
                    _player.PPawn.Upgrade(e.PPawn.Mass);
                }
            }
        }
    }
}
