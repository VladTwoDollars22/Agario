using AgarioGame.Engine.Conrollers;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.Utilities;

namespace AgarioGame.Engine.Factories
{
    public class ControllerFactory
    {
        private List<Controller> _activeControllers;
        public ControllerFactory()
        {
            Dependency.Register(this);
        }
        public void SetActiveControllersList(List<Controller> controllers)
        {
            _activeControllers = controllers;
        }
        public T InstantiateController<T>(GameObject pawn) where T : Controller,new()
        {
            T controller = new();

            controller.SetPawn(pawn);

            Subscriber.SubscribeOnUpdate(controller);

            _activeControllers.Add(controller);

            return controller;
        }
        public T InstantiatePlayerController<T>(GameObject pawn,KeyBindManager kb) where T : PlayerController, new()
        {
            T controller = new();

            controller.SetPawn(pawn);
            controller.SetKeyBindManager(kb);

            Subscriber.SubscribeOnUpdate(controller);
            Subscriber.SubscribeOnInput(controller);

            _activeControllers.Add(controller);

            return controller;
        }
    }
}
