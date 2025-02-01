using IniParser;
using IniParser.Model;
namespace AgarioGame
{
    public static class IniLoader
    {
        private static Dictionary<string, string> _values = new();

        public static void Load(string path)
        {
            _values.Clear();

            Console.WriteLine("Load");

            if (!File.Exists(path))
            {
                Console.WriteLine("Config file not found! Using default values.");
                return;
            }

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(path);

            foreach (var section in data.Sections)
            {
                Console.WriteLine(1);
                foreach (var keyData in section.Keys)
                {
                    Console.WriteLine(2);
                    _values[keyData.KeyName] = keyData.Value;  
                }
            }
        }

        public static string GetString(string key)
        {
            return _values.TryGetValue(key, out string value) ? value : null;
        }
    }
}

