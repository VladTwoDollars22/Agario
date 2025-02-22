using AgarioGame.Game.Controllers;
using AgarioGame.Game.Factoryes;
using AgarioGame.Game.AudioExtensions;
using AgarioGame.Engine.Animation;
using AgarioGame.Game.Configs;
using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.Engine;

namespace AgarioGame.Game.Scenes
{
    public class GameScene : Scene
    {
        private List<AIController> _enemyList;

        private List<Food> foodList;

        private AgarioPlayerController _player;

        private GameObject _fon;

        private int _foodCount;
        private int enemyCount;

        private UnitFactory _unitFactory;
        public GameScene() : base()
        {
            _enemyList = new();
            foodList = new();

            _unitFactory = new(_gameObjFactory, _controllerFactory, _keyBindManager);
        }
        public override void Initialisation()
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
            _fon = _gameObjFactory.Instantiate<GameObject>(new(0, 0), new(255, 255, 255), new(1.5f, 1.1f), Resources.GetTexture("paperfon.jpg"));
            _fon.SetGameField(GameConfig.GameFieldSize);
            _activeObjects.Add(_fon);
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

            AnimationClipsConfig.Initialize();
        }
        private void InitializeFood()
        {
            for (int i = 0; i <= _foodCount; i++)
            {
                Food food = _unitFactory.InstantiateFood();
                foodList.Add(food);
                _activeObjects.Add(food);
            }
        }
        private void InitializePlayer()
        {
            AgarioPlayerController player = _unitFactory.InstantiatePlayer(_enemyList);
            _player = player;
            _activeObjects.Add(player.Pawn);
            _activeControllers.Add(player);
        }
        private void InitializeEnemyes()
        {
            for (int i = 0; i <= enemyCount; i++)
            {
                AIController AI = _unitFactory.InstantiateEnemy();
                _enemyList.Add(AI);
                _activeObjects.Add(AI.Pawn);
                _activeControllers.Add(AI);
            }
        }
        public override void Logic()
        {
            CheckOccurences();
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
                foreach (AIController e in _enemyList)
                {
                    if (f.ObjectIn(e.Pawn))
                    {
                        f.EatMe();
                        e.PPawn.Eat(f.Reward);
                    }
                }
            }

            foreach (AIController e in _enemyList)
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
