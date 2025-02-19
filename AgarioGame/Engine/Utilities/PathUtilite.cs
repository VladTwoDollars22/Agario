namespace AgarioGame.Engine.Utilities
{
    public static class PathUtilite
    {
        private static int repeatsBorder = 5;

        public static string CalculatePath(string pathToObj, bool isFile = true)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string currentPath = Path.Combine(currentDirectory, pathToObj);

            int repeats = 0;

            while (repeats < repeatsBorder)
            {
                if (isFile && File.Exists(currentPath)) return currentPath;
                if (!isFile && Directory.Exists(currentPath)) return currentPath;

                currentDirectory = Path.GetFullPath(Path.Combine(currentDirectory, ".."));
                currentPath = Path.Combine(currentDirectory, pathToObj);
                repeats++;
            }

            return string.Empty;
        }
    }
}
