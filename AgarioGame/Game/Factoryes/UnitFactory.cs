using System;
using System.Numerics;
using AgarioGame.Engine;
using AgarioGame.Game.Controllers;
using SFML.Graphics;

namespace AgarioGame.Game.Factoryes
{
    public class UnitFactory
    {
        private GameLoop _gameLoop;
        public UnitFactory(GameLoop loop)
        {
            _gameLoop = loop;
        }
        public Food InstantiateFood()
        {
            Food food = new(_gameLoop);

            food.SetPosition(Mathematics.GetRandomPosition(GameConfig.GameFieldSize));
            food.SetRadius(GameConfig.FoodRadius);

            return food;
        }
        public AIController InstantiateEnemy()
        {
           PlayableObject enemy;

            enemy = new(_gameLoop);

            enemy.SetPosition(Mathematics.GetRandomPosition(GameConfig.GameFieldSize));
            enemy.SetRadius(GameConfig.PlayersRadius);
            enemy.SetColor(GameConfig.PlayerColor);

            AIController controller = new(_gameLoop);
            controller.SetPawn(enemy);

            return controller;
        }
        public PlayerController InstantiatePlayer()
        {
            PlayableObject player;

            player = new(_gameLoop);

            player.SetPosition(Mathematics.GetRandomPosition(GameConfig.GameFieldSize));
            player.SetRadius(GameConfig.PlayersRadius);
            player.SetColor(GameConfig.PlayerColor);

            PlayerController controller = new(_gameLoop);
            controller.SetPawn(player);

            return controller;
        }
    }
}
