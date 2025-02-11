using AgarioGame.Engine.Utilities;
using SFML.Audio;
using System.Collections.Generic;

namespace AgarioGame.Game.AudioExtensions
{
    public static class AudioSystem
    {
        private static Dictionary<string, Sound> sounds;
        private static string lastPlayedSound = null;

        public static void InitializeAudio()
        {
            sounds = new Dictionary<string, Sound>
            {
                { "eating", GetSound(AudioConfig.EatingClipPath) },
                { "moving", GetSound(AudioConfig.MovingClipPath) },
                { "gamestarted", GetSound(AudioConfig.GameStartedClipPath) },
            };
        }
        private static Sound GetSound(string fileName)
        {
            SoundBuffer buffer = new(PathUtilite.CalculatePath(fileName));

            return new Sound(buffer);
        }
        public static void PlaySound(string soundName)
        {
            if (lastPlayedSound == soundName && sounds[lastPlayedSound].Status == SoundStatus.Playing)
                return;

            if (sounds.ContainsKey(soundName))
            {
                sounds[soundName].Play();
                lastPlayedSound = soundName;
            }
        }
    }
}
