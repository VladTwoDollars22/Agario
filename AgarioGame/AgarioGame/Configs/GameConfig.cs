using AgarioGame.Engine.Utilities;
using AgarioGame.Engine.Utilities.IniExtensions;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Game.Configs
{
    public static class GameConfig
    {
        private static string IniName = "GameConfigurations.txt";

        public static Vector2f PlayerSize { get; private set; } = new(0.05f, 0.05f);
        public static float PlayerMass { get; private set; } = 200;
        public static float MassFactor { get; private set; } = 0.5f;
        public static float MassGrowMult { get; private set; } = 1f;
        public static float BaseSpeed { get; private set; } = 4000f;
        public static Vector2f GameFieldSize { get; private set; } = new(1600f, 900f);
        public static List<Color> FoodColors { get; private set; } = new() { Color.Red, Color.Blue, Color.Magenta, Color.Green };
        public static Color PlayerColor { get; private set; } = Color.Transparent;
        public static float FoodReward { get; private set; } = 5f;
        public static Vector2f FoodSize { get; private set; } = new(0.016f, 0.016f);
        public static int FoodCount { get; private set; } = 10;
        public static int EnemyCount { get; private set; } = 10;

        public static string CircleTexturePath = "E:\\GitHub\\Agario\\AgarioGame\\Resources\\circle.png";

        public static void Initialize()
        {
            IniLoader.Load(PathUtilite.CalculatePath(IniName));
            PlayerSize = IniParserUtil.GetVector2f("PlayerSizeX", "PlayerSizeY", PlayerSize);
            PlayerMass = IniParserUtil.GetFloat("PlayerMass", PlayerMass);
            MassFactor = IniParserUtil.GetFloat("MassFactor", MassFactor);
            MassGrowMult = IniParserUtil.GetFloat("MassGrowMult", MassGrowMult);
            BaseSpeed = IniParserUtil.GetFloat("BaseSpeed", BaseSpeed);
            GameFieldSize = IniParserUtil.GetVector2f("GameFieldSizeX", "GameFieldSizeY", GameFieldSize);
            FoodReward = IniParserUtil.GetFloat("FoodReward", FoodReward);
            FoodSize = IniParserUtil.GetVector2f("FoodSizeX", "FoodSizeY", FoodSize);
            FoodCount = IniParserUtil.GetInt("FoodCount", FoodCount);
            EnemyCount = IniParserUtil.GetInt("EnemyCount", EnemyCount);
            PlayerColor = IniParserUtil.GetColor("PlayerColor", PlayerColor);
            FoodColors = IniParserUtil.GetColorList("FoodColors", FoodColors);
        }
    }
}
