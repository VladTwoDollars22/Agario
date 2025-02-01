using AgarioGame.Engine.Core.IniExtensions;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace AgarioGame.Game
{
    public static class GameConfig
    {
        private static string IniPath = "E:\\GitHub\\Agario\\AgarioGame\\Game\\IniFiles\\GameConfigurations.txt";

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
            Console.WriteLine("Initialize");
            IniLoader.Load(IniPath);

            PlayersRadius = GetFloat("PlayersRadius", PlayersRadius);
            PlayerMass = GetFloat("PlayerMass", PlayerMass);
            MassFactor = GetFloat("MassFactor", MassFactor);
            MassGrowMult = GetFloat("MassGrowMult", MassGrowMult);
            BaseSpeed = GetFloat("BaseSpeed", BaseSpeed);
            GameFieldSize = GetVector2f("GameFieldSizeX", "GameFieldSizeY", GameFieldSize);
            FoodReward = GetFloat("FoodReward", FoodReward);
            FoodRadius = GetFloat("FoodRadius", FoodRadius);
            FoodCount = GetInt("FoodCount", FoodCount);
            EnemyCount = GetInt("EnemyCount", EnemyCount);
            PlayerColor = GetColor("PlayerColor", PlayerColor);
            FoodColors = GetColorList("FoodColors", FoodColors);
        }

        private static float GetFloat(string key, float defaultValue)
        {
            string value = IniLoader.GetString(key);
            return float.TryParse(value, out float result) ? result : defaultValue;
        }

        private static int GetInt(string key, int defaultValue)
        {
            string value = IniLoader.GetString(key);
            return int.TryParse(value, out int result) ? result : defaultValue;
        }

        private static Vector2f GetVector2f(string keyX, string keyY, Vector2f defaultValue)
        {
            float x = GetFloat(keyX, defaultValue.X);
            float y = GetFloat(keyY, defaultValue.Y);
            return new Vector2f(x, y);
        }

        private static Color GetColor(string key, Color defaultValue)
        {
            string value = IniLoader.GetString(key);
            if (string.IsNullOrEmpty(value)) return defaultValue;

            var parts = value.Split(',').Select(p => byte.TryParse(p, out byte b) ? b : (byte)0).ToArray();
            return parts.Length == 3 ? new Color(parts[0], parts[1], parts[2]) : defaultValue;
        }

        private static List<Color> GetColorList(string key, List<Color> defaultValue)
        {
            string value = IniLoader.GetString(key);
            if (string.IsNullOrEmpty(value)) return defaultValue;

            return value.Split(';').Select(ParseColor).ToList();
        }

        private static Color ParseColor(string colorString)
        {
            var parts = colorString.Split(',').Select(byte.Parse).ToArray();
            return new Color(parts[0], parts[1], parts[2]);
        }
    }
}
