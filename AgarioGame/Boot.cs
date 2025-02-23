using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.Game.Scenes;

namespace AgarioGame
{
    internal class Boot
    {
        public static void Main(string[] args)
        {
            GameLoop game = new GameLoop();
            SceneManager.ChangeSceneOn(new LobbyScene());

            game.MainGameLoop();
        }
    }
}
