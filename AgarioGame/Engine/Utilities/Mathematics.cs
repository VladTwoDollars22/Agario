using System;
using SFML.System;

namespace AgarioGame.Engine
{
    public static class Mathematics
    {
        private static Random _random = new Random();
        public static Vector2f Normalize(Vector2f vector)
        {
            float length = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

            if (length > 0)
            {
                return new Vector2f(vector.X / length, vector.Y / length);
            }
            else
            {
                return new Vector2f(0, 0);
            }
        }
        public static Vector2f GetRandomPosition(Vector2f field)
        {
            float x = (float)_random.NextDouble() * field.X;
            float y = (float)_random.NextDouble() * field.Y;

            return new Vector2f(x, y);
        }
        public static Vector2f GetRandomDirection()
        {
            float angle = (float)(_random.NextDouble() * Math.PI * 2);
            return new Vector2f((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
        public static int GetRandomNumber(int min,int max)
        {
           return _random.Next(min, max);
        }
        public static float Distance(Vector2f pointA, Vector2f pointB)
        {
            float deltaX = pointB.X - pointA.X;
            float deltaY = pointB.Y - pointA.Y;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        public static (int x, int y) GetRandomPoint((int X,int Y) size)
        {
            (int newX, int newY) point;

            point.newX = _random.Next(0,size.X);
            point.newY = _random.Next(0,size.Y);

            return point;
        }
    }
}
