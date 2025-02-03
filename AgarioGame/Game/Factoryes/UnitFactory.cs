using System;
using System.Numerics;
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

            AIController controller = new(_gameLoop);
            controller.SetPawn(enemy);

            return controller;
        }
        public PlayerController InstantiatePlayer(GameRules rules)
        {
            PlayableObject player =  _gameObjFactory.Instantiate<PlayableObject>(Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayersRadius);

            player.SetGameField(GameConfig.GameFieldSize);

            PlayerController controller = new(_gameLoop,rules);
            controller.SetPawn(player);

            return controller;
        }
    }
}
