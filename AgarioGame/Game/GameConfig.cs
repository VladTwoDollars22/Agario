using AgarioGame.Engine.Core.IniExtensions;
using AgarioGame.Engine.Utilities;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Game
{
    public static class GameConfig
    {
        private static string IniName = "GameConfigurations.txt";

        public static float PlayersRadius { get; private set; } = 20f;
        public static float PlayerMass { get; private set; } = 200;
        public static float MassFactor { get; private set; } = 0.5f;
        public static float MassGrowMult { get; private set; } = 1f;
        public static float BaseSpeed { get; private set; } = 4000f;
        public static Vector2f GameFieldSize { get; private set; } = new(1600f, 900f);
        public static List<Color> FoodColors { get; private set; } = new() { Color.Red, Color.Blue, Color.Magenta, Color.Green };
        public static Color PlayerColor { get; private set; } = Color.Yellow;
        public static float FoodReward { get; private set; } = 5f;
        public static float FoodRadius { get; private set; } = 10;
        public static int FoodCount { get; private set; } = 50;
        public static int EnemyCount { get; private set; } = 10;

        public static void Initialize()
        {
            IniLoader.Load(PathUtilite.CalculatePath(IniName));

            PlayersRadius = IniParserUtil.GetFloat("PlayersRadius", PlayersRadius);
            PlayerMass = IniParserUtil.GetFloat("PlayerMass", PlayerMass);
            MassFactor = IniParserUtil.GetFloat("MassFactor", MassFactor);
            MassGrowMult = IniParserUtil.GetFloat("MassGrowMult", MassGrowMult);
            BaseSpeed = IniParserUtil.GetFloat("BaseSpeed", BaseSpeed);
            GameFieldSize = IniParserUtil.GetVector2f("GameFieldSizeX", "GameFieldSizeY", GameFieldSize);
            FoodReward = IniParserUtil.GetFloat("FoodReward", FoodReward);
            FoodRadius = IniParserUtil.GetFloat("FoodRadius", FoodRadius);
            FoodCount = IniParserUtil.GetInt("FoodCount", FoodCount);
            EnemyCount = IniParserUtil.GetInt("EnemyCount", EnemyCount);
            PlayerColor = IniParserUtil.GetColor("PlayerColor", PlayerColor);
            FoodColors = IniParserUtil.GetColorList("FoodColors", FoodColors);
        }
    }
}
