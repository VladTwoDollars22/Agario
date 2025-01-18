using SFML.System;

namespace AgarioGame.Engine
{
    public static class Mathematics
    {
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
    }
}
