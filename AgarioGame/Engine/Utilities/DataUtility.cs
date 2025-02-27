using System;
using System.IO;
using System.Text.Json;

namespace AgarioGame.Engine.Utilities
{
    public static class DataUtility
    {
        public static readonly string DataFolderPath;
        public static readonly JsonSerializerOptions Options;

        static DataUtility()
        {
            DataFolderPath = PathUtilite.CalculatePath("Resources/Data", false);

            Options = new JsonSerializerOptions { WriteIndented = true };

            if (string.IsNullOrEmpty(DataFolderPath))
            {
                DataFolderPath = Path.Combine(PathUtilite.CalculatePath("Resources", false), "Data");
                Directory.CreateDirectory(DataFolderPath);
            }
        }

        public static T Load<T>(string fileName) where T : new()
        {
            string fullPath = Path.Combine(DataFolderPath, fileName);

            if (!File.Exists(fullPath))
            {
                Save(new T(), fileName);
            }

            try
            {
                string json = File.ReadAllText(fullPath);
                return JsonSerializer.Deserialize<T>(json) ?? new T();
            }
            catch (Exception)
            {
                return new T();
            }
        }

        public static void Save<T>(T data, string fileName)
        {
            string fullPath = Path.Combine(DataFolderPath, fileName);

            try
            {
                string json = JsonSerializer.Serialize(data, Options);
                File.WriteAllText(fullPath, json);
            }
            catch (Exception)
            {
                Console.WriteLine($"Помилка збереження файлу: {fileName}");
            }
        }
    }
}
