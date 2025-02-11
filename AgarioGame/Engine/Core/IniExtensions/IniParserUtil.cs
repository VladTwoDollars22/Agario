using SFML.System;
using SFML.Graphics;

namespace AgarioGame.Engine.Core.IniExtensions
{
    public static class IniParserUtil
    {
        public static float GetFloat(string key, float defaultValue)
        {
            string value = IniLoader.GetString(key);
            return float.TryParse(value, out float result) ? result : defaultValue;
        }

        public static int GetInt(string key, int defaultValue)
        {
            string value = IniLoader.GetString(key);
            return int.TryParse(value, out int result) ? result : defaultValue;
        }
        public static string GetString(string key,string defaultValue)
        {
            string value = IniLoader.GetString(key);

            if(string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return value;
        }
        public static Vector2f GetVector2f(string keyX, string keyY, Vector2f defaultValue)
        {
            float x = GetFloat(keyX, defaultValue.X);
            float y = GetFloat(keyY, defaultValue.Y);
            return new Vector2f(x, y);
        }

        public static Color GetColor(string key, Color defaultValue)
        {
            string value = IniLoader.GetString(key);
            if (string.IsNullOrEmpty(value)) return defaultValue;

            var parts = value.Split(',').Select(p => byte.TryParse(p, out byte b) ? b : (byte)0).ToArray();
            return parts.Length == 3 ? new Color(parts[0], parts[1], parts[2]) : defaultValue;
        }

        public static List<Color> GetColorList(string key, List<Color> defaultValue)
        {
            string value = IniLoader.GetString(key);
            if (string.IsNullOrEmpty(value)) return defaultValue;

            return value.Split(';').Select(ParseColor).ToList();
        }

        public static Color ParseColor(string colorString)
        {
            var parts = colorString.Split(',').Select(byte.Parse).ToArray();
            return new Color(parts[0], parts[1], parts[2]);
        }
    }
}
