using AgarioGame.Game;
using AgarioGame.Game.Controllers;
using AgarioGame.Game.Factoryes;
using AgarioGame.Engine.Factories;
using AgarioGame.Game.AudioExtensions;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Core.Time;
using SFML.Graphics;
using AgarioGame.Engine.Animation;

namespace AgarioGame.Engine
{
    public class GameRules
    {
        private GameLoop _gameLoop;

        private List<AIController> enemyList;

        private List<Food> foodList;

        private AgarioPlayerController _player;

        private GameObject _fon;

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

            Subscriber.Initialize(_gameLoop);

            _gameObjFactory = new(_gameLoop);
            _controllerFactory = new(_gameLoop);
            _keyBindManager = new(_gameLoop);

            _factory = new(_gameObjFactory,_controllerFactory);
        }
        public void Initialisation()
        {
            InitializeConfigs();
            InitializeAudio();
            InitializeFon();
            InitializeFood();
            InitializeEnemyes();
            InitializePlayer();
        }
        private void InitializeFon()
        {
            _fon = _gameObjFactory.Instantiate<GameObject>(new(0,0),new(255, 255, 255),new(1.5f,1.1f),Resources.GetTexture("paperfon.jpg"));
            _fon.SetGameField(GameConfig.GameFieldSize);
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

            PlayableObject playerPawn = _player.PlayablePawn;

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
                    _player.PlayablePawn.Eat(f.Reward);
                }
            }

            foreach (Food f in foodList)
            {
                foreach (AIController e in enemyList)
                {
                    if (f.ObjectIn(e.Pawn))
                    {
                        f.EatMe();
                        e.PPawn.Eat(f.Reward);
                    }
                }     
            }

            foreach(AIController e in enemyList)
            {
                if (_player.Pawn.ObjectIn(e.Pawn))
                {
                    _player.PlayablePawn.EatMe();
                    e.PPawn.Eat(_player.PlayablePawn.Mass);
                }
                else if (e.Pawn.ObjectIn(_player.Pawn))
                {
                    e.PPawn.EatMe();
                    _player.PlayablePawn.Eat(e.PPawn.Mass);
                }
            }
        }
    }
}
