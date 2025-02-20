using AgarioGame.Engine.Animation;
using SFML.Graphics;

namespace AgarioGame.Game.Configs
{
    public static class AnimationClipsConfig
    {
        public static List<Texture> Idle;
        public static List<Texture> Move;
        public static List<Texture> Eat;
        public static void Initialize()
        {
            Idle = (new List<Texture> {
                Resources.GetTexture("PlayerAnim\\Idle\\idle2.png"),Resources.GetTexture("PlayerAnim\\Idle\\idle3.png"),
            Resources.GetTexture("PlayerAnim\\Idle\\idle4.png"),Resources.GetTexture("PlayerAnim\\Idle\\idle5.png")});

            Move = (new List<Texture> {
                Resources.GetTexture("PlayerAnim\\Move\\move1.png"),Resources.GetTexture("PlayerAnim\\Move\\move2.png"),
            Resources.GetTexture("PlayerAnim\\Move\\move3.png")});

            Eat = (new List<Texture> {
                Resources.GetTexture("PlayerAnim\\Eat\\eat1.png"),Resources.GetTexture("PlayerAnim\\Eat\\eat2.png"),
            Resources.GetTexture("PlayerAnim\\Eat\\eat3.png"),Resources.GetTexture("PlayerAnim\\Eat\\eat4.png"),Resources.GetTexture("PlayerAnim\\Eat\\eat5.png")});
        }
    }
}
