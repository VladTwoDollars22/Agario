using System.Xml.Linq;
using AgarioGame.Engine.Conrollers;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;
using AgarioGame.Engine.UIExtentions.Factories;
using AgarioGame.Engine.Utilities;

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
            _activeObjects = new List<GameObject>();
            _activeControllers = new List<Controller>();

            _gameObjFactory = Dependency.Get<GameObjectFactory>() ?? new GameObjectFactory();
            _controllerFactory = Dependency.Get<ControllerFactory>() ?? new ControllerFactory();
            _keyBindManager = Dependency.Get<KeyBindManager>() ?? new KeyBindManager();
            _uIObjectFactory = Dependency.Get<UIObjectFactory>() ?? new UIObjectFactory();

            _gameObjFactory.SetActiveObjectsList(_activeObjects);
            _controllerFactory.SetActiveControllersList(_activeControllers);
        }

        public virtual void Initialisation() { }

        public virtual void Logic() { }

        public virtual void OnDelete() { }

        public void Delete()
        {
            OnDelete();
            DestroyObjects();
            DestroyControllers();
            ClearKeyBinds();
        }

        private void DestroyObjects()
        {
            foreach (GameObject gameObj in _activeObjects)
            {
                gameObj.Destroy();
            }
        }

        private void DestroyControllers()
        {
            foreach (Controller ctrl in _activeControllers)
            {
                ctrl.Destroy();
            }
        }
        private void ClearKeyBinds()
        {
            _keyBindManager.RemoveAllBinds();
        }
    }
}
