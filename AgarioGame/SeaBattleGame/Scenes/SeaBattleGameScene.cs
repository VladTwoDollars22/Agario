using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.SeaBattleGame.Factories;
using AgarioGame.SeaBattleGame.GameExtentions;
using TGUI;

namespace AgarioGame.SeaBattleGame.Scenes
{
    public class SeaBattleGameScene : Scene
    {
        public GridMap map;
        public SeaBattleUnitFactory unitFactory;

        public SeaBattleGameScene()
        {
            unitFactory = new();

            map = new(5,5,new(200,200));
        }

        public override void Initialisation()
        {
            map.CreateField();
            map.PlaceShips(new List<int> { 1,1,1,1});
        }
    }
}
