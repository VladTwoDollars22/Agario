using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.SeaBattleGame.Factories;
using AgarioGame.SeaBattleGame.GameExtentions;
using AgarioGame.SeaBattleGame.Units;
using TGUI;

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
            player1 = unitFactory.InstantiatePlayer("na", 3, (3, 3), (7, 7), new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 },new(300,300));
            player2 = unitFactory.InstantiatePlayer("nana", 3, (3, 3), (7, 7), new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 },new(1300,300));
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
