using AgarioGame.Engine.Animation;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;
using AgarioGame.Engine.Utilities;
using AgarioGame.SeaBattleGame.Units;
using SFML.System;

namespace AgarioGame.SeaBattleGame.Factories
{
    public class SeaBattleUnitFactory
    {
        private GameObjectFactory _gameObjFactory;
        private ControllerFactory _controllerFactory;
        private KeyBindManager _keyBindManager;

        public SeaBattleUnitFactory()
        {
            _gameObjFactory = Dependency.Get<GameObjectFactory>();
            _controllerFactory = Dependency.Get<ControllerFactory>();
            _keyBindManager = Dependency.Get<KeyBindManager>();

            Dependency.Register(this);
        }

        public Cell InstantiateCell(Vector2f pos,Vector2f size,string texturePath)
        {
            Cell cell = _gameObjFactory.Instantiate<Cell>(pos,SFML.Graphics.Color.White,size, Resources.GetTexture(texturePath));

            cell.SetShip(false);
            cell.SetShooted(false);

            return cell;
        }

        public Player InstantiatePlayer(string nickName, int radarCount, (int X, int Y) radarArea, (int X, int Y) fieldSize, List<int> ships, Vector2f fieldStartPos)
        {
            Player player = new(nickName,radarCount,radarArea,fieldSize,ships,fieldStartPos);

            return player;
        }
    }
}
