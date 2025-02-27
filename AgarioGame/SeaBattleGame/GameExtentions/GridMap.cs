﻿using AgarioGame.SeaBattleGame.Units;

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

        private Cell[,] Map;

        private bool placed;

        public void GenerateField(List<int> ships)
        {
            CreateField();
            PlaceShips(ships);
        }

        public GridMap(int width, int height)
        {
            Width = width;
            Height = height;
            Map = new Cell[height, width];
        }

        public Cell[,] CreateField()
        {
            Map = new Cell[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Map[i, j] = new();
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
                        Console.Error.WriteLine("неможливо розмістити всі кораблі");
                    else
                        iteration++;

                    Cell[,] map = Map;
                    var mainPoint = GetRandomPoint();
                    int axis = _random.Next(0, 2);

                    TryPlaceShip(mainPoint, shipLength, axis);
                }
            }
        }
        private void TryPlaceShip((int X, int Y) mainPoint, int shipLength, int axis)
        {
            if (CanPlaceShip(mainPoint, shipLength, axis))
            {
                PlaceShip(mainPoint, shipLength, axis);

                placed = true;
            }
        }
        private bool CanPlaceShip((int X, int Y) mainPoint, int shipLength, int axis)
        {
            for (int i = 0; i < shipLength; i++)
            {
                var nextPoint = GetNextPoint(mainPoint, axis, i);

                if (!CanPlaceShipPart(nextPoint.X, nextPoint.Y))
                {
                    return false;
                }
            }

            return true;
        }
        private void PlaceShip((int X, int Y) mainPoint, int shipLength, int axis)
        {
            for (int i = 0; i < shipLength; i++)
            {
                var nextPoint = GetNextPoint(mainPoint, axis, i);

                Map[nextPoint.X, nextPoint.Y].SetShip(true);
            }
        }
        private (int X, int Y) GetNextPoint((int X, int Y) mainPoint, int axis, int delta)
        {
            int x;
            int y;

            if (axis == 1)
            {
                x = mainPoint.X + delta;
                y = mainPoint.Y;
            }
            else
            {
                x = mainPoint.X;
                y = mainPoint.Y + delta;
            }

            return (x, y);
        }
        public Cell GetCell((int x,int y) point)
        {
            return Map[point.x, point.y];
        }
        private bool CanPlaceShipPart(int X, int Y)
        {
            if (X < 0 || X >= Map.GetLength(0) || Y < 0 || Y >= Map.GetLength(1))
                return false;

            return Map[X, Y].GetCellState() == CellState.Empty;
        }
        public ShootState GetShootState((int x, int y) point)
        {
            switch (Map[point.x, point.y].GetCellState())
            {
                case CellState.Empty:
                    return ShootState.Missing;
                case CellState.HasShip:
                    return ShootState.Hitting;
                default:
                    return ShootState.Repeating;
            }
        }
        public (int X, int Y) GetRandomPoint()
        {
            int x = _random.Next(0, Height);
            int y = _random.Next(0, Width);

            return (x, y);
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
