using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using AgarioGame.Engine.Factories;
using AgarioGame.Game.Controllers;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public class UnitFactory
    {
        private GameObjectFactory _gameObjFactory;
        private ControllerFactory _controllerFactory;
        public UnitFactory(GameObjectFactory gameObjFactory,ControllerFactory ctrlFactory)
        {
            _gameObjFactory = gameObjFactory;
            _controllerFactory = ctrlFactory;
        }
        public Food InstantiateFood()
        {
            Food food = _gameObjFactory.Instantiate<Food>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),Color.Transparent,GameConfig.FoodSize, Resources.GetTexture("circle.png"));
            food.SetGameField(GameConfig.GameFieldSize);

            food.SetRandomColor();

            return food;
        }
        public AIController InstantiateEnemy()
        {
            PlayableObject enemy = _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayerSize, Resources.GetTexture("circle.png"));

            enemy.SetGameField(GameConfig.GameFieldSize);

            AIController controller = _controllerFactory.InstantiateController<AIController>(enemy);

            return controller;
        }
        public AgarioPlayerController InstantiatePlayer(GameRules rules)
        {
            PlayableObject player =  _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayerSize, Resources.GetTexture("circle.png"));

            player.SetGameField(GameConfig.GameFieldSize);

            player.SetAnimator(AnimatorFactory.InitializePlayerAnimator(player.Sprite));

            AgarioPlayerController controller = _controllerFactory.InstantiatePlayerController<AgarioPlayerController>(player);
            controller.SetPawn(player);
            controller.Start();

            return controller;
        }
    }
}
