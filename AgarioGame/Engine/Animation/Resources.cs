using AgarioGame.Engine.Utilities;
using SFML.Graphics;

namespace AgarioGame.Engine.Animation
{
    public static class Resources
    {
        private static readonly string _directory = PathUtilite.CalculatePath("Resources",false);

        public static Texture GetTexture(string filename)
        {
            string path = Path.Combine(_directory, filename);
            return File.Exists(path) ? new Texture(path) : null;
        }
    }
}
