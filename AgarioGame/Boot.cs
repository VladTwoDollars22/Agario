using AgarioGame.Engine;
using AgarioGame.Engine.ScenesExtentions;

namespace AgarioGame
{
    internal class Boot
    {
        public static void Main(string[] args)
        {
            GameLoop game = new GameLoop();
            SceneManager.SetScene(new GameScene());

            game.MainGameLoop();
        }
    }
}
