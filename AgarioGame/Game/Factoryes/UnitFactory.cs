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
            Food food = new();
            GameObject foodObject = food.GetObject();

            _gameObjFactory.InstantiateGameObject(foodObject,Mathematics.GetRandomPosition(GameConfig.GameFieldSize),Color.Transparent,GameConfig.FoodRadius);
            foodObject.SetGameField(GameConfig.GameFieldSize);

            food.SetRandomColor();

            return food;
        }
        public AIController InstantiateEnemy()
        {
            PlayableObject enemy = new();
            GameObject enemyObject = enemy.GetObject();

            _gameObjFactory.InstantiateGameObject(enemyObject,Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayersRadius);

            enemyObject.SetGameField(GameConfig.GameFieldSize);

            AIController controller = new(_gameLoop);
            controller.SetPawn(enemy);

            return controller;
        }
        public PlayerController InstantiatePlayer(GameRules rules)
        {
            PlayableObject player = new();
            GameObject playerObject = player.GetObject();

            _gameObjFactory.InstantiateGameObject(playerObject,Mathematics.GetRandomPosition(GameConfig.GameFieldSize),
                GameConfig.PlayerColor, GameConfig.PlayersRadius);

            playerObject.SetGameField(GameConfig.GameFieldSize);

            PlayerController controller = new(_gameLoop,rules);
            controller.SetPawn(player);

            return controller;
        }
    }
}
