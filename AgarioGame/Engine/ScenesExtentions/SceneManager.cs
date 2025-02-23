
namespace AgarioGame.Engine.ScenesExtentions
{
    public static class SceneManager
    {
        public static Scene CurrentScene;

        public static void ChangeSceneOn(Scene scene)
        {
            if (scene == null) return;

            if(CurrentScene == null)
            {
                CurrentScene = scene;
            }
            else
            {
                CurrentScene.Delete();
                CurrentScene = scene;
                CurrentScene.Initialisation();
            }
        }
    }
}
