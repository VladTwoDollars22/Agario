using System.Net;
using System.Numerics;
using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;
using AgarioGame.Game.Configs;
using AgarioGame.Game.Controllers;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public class UnitFactory
    {
        private GameObjectFactory _gameObjFactory;
        private ControllerFactory _controllerFactory;
        private KeyBindManager _keyBindManager;
        private Texture _foodTexture;
        public UnitFactory(GameObjectFactory gameObjFactory,ControllerFactory ctrlFactory,KeyBindManager kbManager)
        {
            _gameObjFactory = gameObjFactory;
            _controllerFactory = ctrlFactory;
            _keyBindManager = kbManager;

            _foodTexture = Resources.GetTexture("Food.png");
        }
        public Food InstantiateFood()
        {
            Food food = _gameObjFactory.Instantiate<Food>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),Color.Transparent,GameConfig.FoodSize, _foodTexture);
            food.SetGameField(GameConfig.GameFieldSize);

            food.SetRandomColor();

            return food;
        }
        public AIController InstantiateEnemy()
        {
            PlayableObject enemy = _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayerSize, Resources.GetTexture("PlayerAnim\\Idle\\idle1.png"));

            enemy.SetGameField(GameConfig.GameFieldSize);

            enemy.SetAnimator(AnimatorFactory.InitializePlayerAnimator(enemy.Sprite));

            AIController controller = _controllerFactory.InstantiateController<AIController>(enemy);

            controller.Start();

            return controller;
        }
        public AgarioPlayerController InstantiatePlayer(List<AIController> List)
        {
            PlayableObject player =  _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayerSize, Resources.GetTexture("PlayerAnim\\Idle\\idle1.png"));

            player.SetGameField(GameConfig.GameFieldSize);

            player.SetAnimator(AnimatorFactory.InitializePlayerAnimator(player.Sprite));

            AgarioPlayerController controller = _controllerFactory.InstantiatePlayerController<AgarioPlayerController>(player, _keyBindManager);
            controller.SetPawn(player);
            controller.SetEnemyes(List);
            controller.Start();

            return controller;
        }
    }
}
