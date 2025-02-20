using AgarioGame.Engine.Core.IniExtensions;
using AgarioGame.Engine.Utilities;
using SFML.System;

namespace AgarioGame.Game.Configs
{
    public static class AudioConfig
    {
        private static string IniName = "AudioConfigurations.txt";

        public static string EatingClipPath = "eating.mp3";
        public static string MovingClipPath = "moving.mp3";
        public static string GameStartedClipPath = "gamestarted.mp3";
        public static void Initialize()
        {
            IniLoader.Load(PathUtilite.CalculatePath(IniName));

            EatingClipPath = IniParserUtil.GetString("EatingPath", EatingClipPath);
            MovingClipPath = IniParserUtil.GetString("MovingPath", MovingClipPath);
            GameStartedClipPath = IniParserUtil.GetString("GameStartedPath", GameStartedClipPath);
        }
    }
}
