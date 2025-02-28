using AgarioGame.Engine.Utilities;
using AgarioGame.Game.Factoryes;
using AgarioGame.SeaBattleGame.Factories;
using AgarioGame.SeaBattleGame.Units;
using SFML.System;

namespace AgarioGame.SeaBattleGame.GameExtentions
{
    public enum ShootState
    {
        Missing,
        Hitting,
        Repeating,
    }

    public class GridMap
    {
        private Random _random = new Random();
        public (int width, int height) Size { get; private set; }
        public Vector2f StartPoint { get; private set; }

        private List<int> _ships;
        private Cell[,] _map;
        private bool _placed;
        private SeaBattleUnitFactory _unitFactory;

        public GridMap((int width, int height) size, Vector2f startPoint, List<int> ships)
        {
            Size = size;
            StartPoint = startPoint;
            _ships = ships;
            _map = new Cell[size.height, size.width];

            _unitFactory = Dependency.Get<SeaBattleUnitFactory>();
        }

        public void SetSize((int width, int height) newSize)
        {
            Size = newSize;
            _map = new Cell[newSize.height, newSize.width];
        }

        public Cell[,] CreateField()
        {
            _map = new Cell[Size.height, Size.width];

            for (int i = 0; i < Size.height; i++)
            {
                for (int j = 0; j < Size.width; j++)
                {
                    _map[i, j] = _unitFactory.InstantiateCell(
                        new Vector2f(StartPoint.X + j * 100 - Size.width * 25, StartPoint.Y + i * 100 - Size.height * 25),
                        new Vector2f(0.2f, 0.2f),
                        "Cells/empty.png"
                    );

                    _map[i, j].SetVisiblity(true);
                }
            }

            return _map;
        }

        public void PlaceShips()
        {
            foreach (var shipLength in _ships)
            {
                _placed = false;
                int iteration = 0;

                while (!_placed)
                {
                    if (iteration > 10000)
                        Console.Error.WriteLine("Неможливо розмістити всі кораблі");
                    else
                        iteration++;

                    var mainPoint = GetRandomPoint();
                    int axis = _random.Next(0, 2);

                    TryPlaceShip(mainPoint, shipLength, axis);
                }
            }
        }

        private void TryPlaceShip(Vector2f mainPoint, int shipLength, int axis)
        {
            if (CanPlaceShip(mainPoint, shipLength, axis))
            {
                PlaceShip(mainPoint, shipLength, axis);
                _placed = true;
            }
        }

        private bool CanPlaceShip(Vector2f mainPoint, int shipLength, int axis)
        {
            for (int i = 0; i < shipLength; i++)
            {
                var nextPoint = GetNextPoint(mainPoint, axis, i);
                if (!CanPlaceShipPart((int)nextPoint.X, (int)nextPoint.Y))
                {
                    return false;
                }
            }
            return true;
        }

        private void PlaceShip(Vector2f mainPoint, int shipLength, int axis)
        {
            for (int i = 0; i < shipLength; i++)
            {
                var nextPoint = GetNextPoint(mainPoint, axis, i);
                _map[(int)nextPoint.X, (int)nextPoint.Y].SetShip(true);
            }
        }

        private Vector2f GetNextPoint(Vector2f mainPoint, int axis, int delta)
        {
            return axis == 1 ? new Vector2f(mainPoint.X + delta, mainPoint.Y) : new Vector2f(mainPoint.X, mainPoint.Y + delta);
        }

        public Cell GetCell(Vector2f point)
        {
            return _map[(int)point.X, (int)point.Y];
        }

        private bool CanPlaceShipPart(int X, int Y)
        {
            if (X < 0 || X >= _map.GetLength(0) || Y < 0 || Y >= _map.GetLength(1))
                return false;

            return _map[X, Y].GetCellState() == CellState.Empty;
        }

        public ShootState GetShootState(Vector2f point)
        {
            switch (_map[(int)point.X, (int)point.Y].GetCellState())
            {
                case CellState.Empty:
                    return ShootState.Missing;
                case CellState.HasShip:
                    return ShootState.Hitting;
                default:
                    return ShootState.Repeating;
            }
        }

        public Vector2f GetRandomPoint()
        {
            return new Vector2f(_random.Next(0, Size.width), _random.Next(0, Size.height));
        }

        public Cell GetCell(int x, int y)
        {
            return _map[x, y];
        }

        public int GetMapLength()
        {
            return Size.width;
        }
    }
}
