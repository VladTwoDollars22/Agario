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
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Vector2f StartPoint { get; private set; }

        private Cell[,] Map;
        private bool placed;
        private SeaBattleUnitFactory _unitFactory;

        public GridMap(int width, int height, Vector2f startPoint)
        {
            Width = width;
            Height = height;
            StartPoint = startPoint;
            Map = new Cell[height, width];
            _unitFactory = Dependency.Get<SeaBattleUnitFactory>();
        }

        public Cell[,] CreateField()
        {
            Map = new Cell[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Map[i, j] = _unitFactory.InstantiateCell(
                        new Vector2f(StartPoint.X + j * 100 - Width * 25, StartPoint.Y + i * 100 - Height * 25),
                        new Vector2f(0.2f, 0.2f),
                        "Cells/empty.png"
                    );

                    Map[i, j].SetVisiblity(true);
                }
            }

            return Map;
        }
        public void PlaceShips(List<int> ships)
        {
            foreach (var shipLength in ships)
            {
                placed = false;
                int iteration = 0;

                while (!placed)
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
                placed = true;
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
                Map[(int)nextPoint.X, (int)nextPoint.Y].SetShip(true);
            }
        }
        private Vector2f GetNextPoint(Vector2f mainPoint, int axis, int delta)
        {
            return axis == 1 ? new Vector2f(mainPoint.X + delta, mainPoint.Y) : new Vector2f(mainPoint.X, mainPoint.Y + delta);
        }
        public Cell GetCell(Vector2f point)
        {
            return Map[(int)point.X, (int)point.Y];
        }
        private bool CanPlaceShipPart(int X, int Y)
        {
            if (X < 0 || X >= Map.GetLength(0) || Y < 0 || Y >= Map.GetLength(1))
                return false;

            return Map[X, Y].GetCellState() == CellState.Empty;
        }
        public ShootState GetShootState(Vector2f point)
        {
            switch (Map[(int)point.X, (int)point.Y].GetCellState())
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
            return new Vector2f(_random.Next(0, Width), _random.Next(0, Height));
        }
        public Cell GetCell(int x, int y)
        {
            return Map[x, y];
        }
        public int GetMapLength()
        {
            return Map.GetLength(1);
        }
    }
}
