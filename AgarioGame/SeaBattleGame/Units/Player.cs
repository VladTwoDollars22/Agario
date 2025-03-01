using AgarioGame.Engine;
using AgarioGame.Engine.Core.Input;
using AgarioGame.SeaBattleGame.GameExtentions;
using SFML.System;
using SFML.Window;

namespace AgarioGame.SeaBattleGame.Units
{
    public class Player : IInputHandler
    {
        public bool _isBot;

        private string _nickName;

        private GridMap _map;
        private List<int> _ships;
        private int _hp;

        private (int width, int heigth) _radarArea;
        private float _radarUsingTime;
        private (int x, int y) _radarPoint;
        private int _radarsCount;

        private (int width, int height) _fieldSize;

        private (int x, int y) _shootPoint;

        private GridMap _enemyMap;
        
        public string NickName => _nickName;
        public GridMap Map => _map;
        public int HP => _hp;
        public void Initialize()
        {
            _radarsCount = 3;
            _radarPoint = (-1,-1);
            _radarArea = (3,3);

            _ships = new List<int> { 4,3,3};

            _hp = _ships.Sum();
        }
        public void InputProcess()
        {
            if (_isBot)
            {
                _shootPoint = Mathematics.GetRandomPoint(_fieldSize);
            }
            else 
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _shootPoint = _enemyMap.GetCelWithPoint(MouseInput.GetPosition());

                    if(_shootPoint != (-1,-1))
                        Console.WriteLine(_shootPoint);

                }
            }
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
        public void SetNickName(string NickName)
        {
            _nickName = NickName;
        }
        public void InitializeMap((int X,int Y) fieldSize,SFML.System.Vector2f fieldStartPos,bool gridVisibility)
        {
            _fieldSize = fieldSize;
            _map = new(fieldSize, fieldStartPos, _ships, gridVisibility);
        }
        public void SetEnemyMap(GridMap map)
        {
            _enemyMap = map;
        }
    }
}
