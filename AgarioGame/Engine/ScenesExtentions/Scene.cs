using AgarioGame.Engine.Conrollers;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;
using AgarioGame.Engine.UIExtentions.Factories;

namespace AgarioGame.Engine.ScenesExtentions
{
    public class Scene
    {
        protected List<GameObject> _activeObjects;
        protected List<Controller> _activeControllers;

        protected GameObjectFactory _gameObjFactory;
        protected ControllerFactory _controllerFactory;
        protected KeyBindManager _keyBindManager;
        protected UIObjectFactory _uIObjectFactory;
        public Scene()
        {
            _gameObjFactory = new();
            _controllerFactory = new();
            _keyBindManager = new();
            _uIObjectFactory = new();

            _activeObjects = new();
            _activeControllers = new();
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
