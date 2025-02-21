using AgarioGame.Engine;
using AgarioGame.Engine.Conrollers;
using AgarioGame.Engine.Core.Input.KeyBind;

namespace AgarioGame.Engine.Factories
{
    public class ControllerFactory
    {
        public T InstantiateController<T>(GameObject pawn) where T : Controller,new()
        {
            T controller = new();

            controller.SetPawn(pawn);

            Subscriber.SubscribeOnUpdate(controller);

            return controller;
        }
        public T InstantiatePlayerController<T>(GameObject pawn,KeyBindManager kb) where T : PlayerController, new()
        {
            T controller = new();

            controller.SetPawn(pawn);
            controller.SetKeyBindManager(kb);

            Subscriber.SubscribeOnUpdate(controller);
            Subscriber.SubscribeOnInput(controller);

            return controller;
        }
    }
}
