
namespace AgarioGame.Engine.ScenesExtentions
{
    public static class SceneManager
    {
        public static Scene CurrentScene;

        public static void ChangeSceneOn(Scene scene)
        {
            if (scene == null) return;

            CurrentScene.Delete();
            CurrentScene = scene;
            CurrentScene.Initialisation();
        }
        public static void SetScene(Scene scene)
        {
            CurrentScene = scene;
        }
    }
}
