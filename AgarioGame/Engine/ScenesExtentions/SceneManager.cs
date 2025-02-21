
namespace AgarioGame.Engine.ScenesExtentions
{
    public static class SceneManager
    {
        public static Scene CurrentScene;

        public static void SetScene(Scene scene)
        {

            CurrentScene = scene;
            CurrentScene.Initialisation();
        }
    }
}
