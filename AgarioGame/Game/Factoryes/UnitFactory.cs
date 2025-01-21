using AgarioGame.Engine;
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
        public Player InstantiateEnemy()
        {
            Player enemy;
            enemy = new(Mathematics.GetRandomPosition(GameConfig.GameFieldSize), GameConfig.PlayersRadius, Color.White,true);
            enemy.RegisterObject(_gameLoop);

            return enemy;
        }
        public Player InstantiatePlayer()
        {
            Player player;
            player = new(Mathematics.GetRandomPosition(GameConfig.GameFieldSize), GameConfig.PlayersRadius, Color.Yellow,false);
            player.RegisterObject(_gameLoop);
            player.RegisterActor(_gameLoop);

            return player;
        }
    }
}
