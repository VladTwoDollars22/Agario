using System;
using AgarioGame.Engine;
using AgarioGame.Game.Units;
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
            Food food = new(Mathematics.GetRandomPosition(GameConfig.GameFieldSize), 10, Color.Green);
            food.RegisterObject(_gameLoop);

            return food;
        }
        public Controller InstantiateEnemy()
        {
            PlayableObject enemy;
            enemy = new(Mathematics.GetRandomPosition(GameConfig.GameFieldSize), GameConfig.PlayersRadius, Color.White,_gameLoop);

            Controller controller = new(true,_gameLoop,enemy);

            return controller;
        }
        public Controller InstantiatePlayer()
        {
            PlayableObject player;
            player = new(Mathematics.GetRandomPosition(GameConfig.GameFieldSize), GameConfig.PlayersRadius, Color.Yellow,_gameLoop);

            Controller controller = new(false, _gameLoop, player);

            return controller;
        }
    }
}
