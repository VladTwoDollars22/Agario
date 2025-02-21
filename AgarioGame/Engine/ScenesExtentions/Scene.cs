using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Factories;

namespace AgarioGame.Engine.ScenesExtentions
{
    public class Scene
    {
        protected GameLoop _gameLoop;

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
        }
        public virtual void Initialisation()
        {

        }
        public virtual void Logic()
        {
            
        }
    }
}
