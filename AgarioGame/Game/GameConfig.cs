using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Game
{
    public static class GameConfig
    {
        public const float PlayersRadius = 20f;

        public const float PlayerMass = 200;
        public const float MassFactor = 0.5f;
        public const float MassGrowMult = 1f;

        public const float BaseSpeed = 4000f;

        public static Vector2f GameFieldSize = new(1600f, 900f);

        public static List<Color> FoodColors = new List<Color> { Color.Red, Color.Blue, Color.Yellow, Color.Green };
        public const float FoodReward = 5f;

        public const int FoodCount = 50;
        public const int EmenyCount = 10;
    }
}
