using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.Game.Scenes;
using AgarioGame.SeaBattleGame.Scenes;

namespace AgarioGame
{
    internal class Boot
    {
        public static void Main(string[] args)
        {
            GameLoop game = new GameLoop();
            SceneManager.ChangeSceneOn(new SeaBattleGameScene());

            game.MainGameLoop();
        }
    }
}
