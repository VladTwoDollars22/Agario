using AgarioGame.Engine;
using AgarioGame.Engine.Factories;
using AgarioGame.Game.Controllers;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public class UnitFactory
    {
        private GameLoop _gameLoop;

        private GameObjectFactory _gameObjFactory;
        private ControllerFactory _controllerFactory;
        public UnitFactory(GameLoop loop,GameObjectFactory factory)
        {
            _gameLoop = loop;

            _gameObjFactory = factory;
        }
        public Food InstantiateFood()
        {
            Food food = _gameObjFactory.Instantiate<Food>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),Color.Transparent,GameConfig.FoodRadius);
            food.SetGameField(GameConfig.GameFieldSize);

            food.SetRandomColor();

            return food;
        }
        public AIController InstantiateEnemy()
        {
            PlayableObject enemy = _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayersRadius);

            enemy.SetGameField(GameConfig.GameFieldSize);

            AIController controller = _controllerFactory.InstantiateController<AIController>(enemy);

            return controller;
        }
        public AgarioPlayerController InstantiatePlayer(GameRules rules)
        {
            PlayableObject player =  _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayersRadius);

            player.SetGameField(GameConfig.GameFieldSize);

            AgarioPlayerController controller = _controllerFactory.InstantiatePlayerController<AgarioPlayerController>(player);
            controller.SetPawn(player);

            return controller;
        }
    }
}
