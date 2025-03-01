using AgarioGame.Engine.Animation;
using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.SeaBattleGame.Factories;
using AgarioGame.SeaBattleGame.Units;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.SeaBattleGame.Scenes
{
    public class SeaBattleGameScene : Scene
    {
        public SeaBattleUnitFactory unitFactory;
        public Player player1;
        public Player player2;

        public SeaBattleGameScene()
        {
            unitFactory = new();
            player1 = unitFactory.InstantiatePlayer(new Vector2f(300, 500), new Vector2f(0.1f, 0.1f), Color.White, Resources.GetTexture("player.png"), "na", (5, 5), new Vector2f(300, 300));
            player2 = unitFactory.InstantiatePlayer(new Vector2f(300, 500), new Vector2f(0.1f, 0.1f), Color.White, Resources.GetTexture("player.png"), "na", (5, 5), new Vector2f(1300, 300));

            player1.SetEnemyMap(player2.Map);
            player2.SetEnemyMap(player1.Map);
        }

        public override void Initialisation()
        {
            player1.Map.CreateField();
            player1.Map.PlaceShips();

            player2.Map.CreateField();
            player2.Map.PlaceShips();
        }
    }
}
