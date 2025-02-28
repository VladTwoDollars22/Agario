using AgarioGame.SeaBattleGame.GameExtentions;
using SFML.System;
using TGUI;

namespace AgarioGame.SeaBattleGame.Units
{
    public class Player
    {
        private string _nickName;

        private GridMap _map;
        private List<int> _ships;
        private int _hp;

        private (int width, int heigth) _radarArea;
        private float _radarUsingTime;
        private (int x, int y) _radarPoint;
        private int _radarsCount;

        private (int width, int height) _fieldSize;

        public string NickName => _nickName;
        public GridMap Map => _map;

        public Player(string nickName, int radarCount, (int X, int Y) radarArea,(int X,int Y) fieldSize,List<int> ships,SFML.System.Vector2f fieldStartPos)
        {
            _nickName = nickName;

            _radarsCount = radarCount;
            _radarPoint = (-1,-1);
            _radarArea = radarArea;

            _fieldSize = fieldSize;

            _ships = ships;

            _hp = _ships.Sum();

            _map = new(_fieldSize, fieldStartPos, _ships);
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
        }

        public void UseRadar()
        {
            _radarsCount--;
        }
        public void Reset()
        {
            _hp = _ships.Sum();
        }
    }
}
