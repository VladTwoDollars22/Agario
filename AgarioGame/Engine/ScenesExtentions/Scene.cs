using AgarioGame.Engine.Conrollers;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;

namespace AgarioGame.Engine.ScenesExtentions
{
    public class Scene
    {
        protected GameLoop _gameLoop;

        protected List<GameObject> _activeObjects;
        protected List<Controller> _activeControllers;

        protected GameObjectFactory _gameObjFactory;
        protected ControllerFactory _controllerFactory;
        protected KeyBindManager _keyBindManager;
        public Scene(GameLoop loop)
        {
            _gameLoop = loop;

            _gameObjFactory = new(_gameLoop);
            _controllerFactory = new(_gameLoop);
            _keyBindManager = new(_gameLoop);

            Subscriber.Initialize(_gameLoop);

            _activeObjects = new();
            _activeControllers = new();

            _keyBindManager.AddKeyBind("DeleteScene",SFML.Window.Keyboard.Key.J);
            _keyBindManager.GetKeyBind("DeleteScene").AddOnDownCallback(Delete);
        }
        public virtual void Initialisation() { }
        public virtual void Logic() { }
        public virtual void OnDelete() { }
        public void Delete()
        {
            OnDelete();
            DestroyObjects();
            DestroyControlles();
        }

        private void DestroyObjects()
        {
            foreach(GameObject gameObj in _activeObjects)
            {
                gameObj.Destroy();
            }
        }

        private void DestroyControlles()
        {
            foreach(Controller ctrl in _activeControllers)
            {
                ctrl.Destroy();
            }
        }
    }
}
