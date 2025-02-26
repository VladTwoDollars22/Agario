using AgarioGame.Engine.Animation;
using SFML.Graphics;

namespace AgarioGame.Game.Configs
{
    public static class AnimationClipsConfig
    {
        public static List<Texture> Idle;
        public static List<Texture> Move;
        public static List<Texture> Eat;

        private static readonly string[] IdlePaths = {
            "PlayerAnim\\Idle\\idle2.png",
            "PlayerAnim\\Idle\\idle3.png",
            "PlayerAnim\\Idle\\idle4.png",
            "PlayerAnim\\Idle\\idle5.png"
        };

        private static readonly string[] MovePaths = {
            "PlayerAnim\\Move\\move1.png",
            "PlayerAnim\\Move\\move2.png",
            "PlayerAnim\\Move\\move3.png"
        };

        private static readonly string[] EatPaths = {
            "PlayerAnim\\Eat\\eat1.png",
            "PlayerAnim\\Eat\\eat2.png",
            "PlayerAnim\\Eat\\eat3.png",
            "PlayerAnim\\Eat\\eat4.png",
            "PlayerAnim\\Eat\\eat5.png"
        };

        public static void Initialize()
        {
            Idle = LoadAnimation(IdlePaths);
            Move = LoadAnimation(MovePaths);
            Eat = LoadAnimation(EatPaths);
        }

        private static List<Texture> LoadAnimation(string[] paths)
        {
            var textures = new List<Texture>();
            foreach (var path in paths)
            {
                textures.Add(Resources.GetTexture(path));
            }
            return textures;
        }
    }
}
