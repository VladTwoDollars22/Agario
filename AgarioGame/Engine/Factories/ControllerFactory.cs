using AgarioGame.Engine;
using AgarioGame.Engine.Core.Input.Conrollers;

namespace AgarioGame.Engine.Factories
{
    public class ControllerFactory
    {
        private GameLoop _gameLoop;

        public ControllerFactory(GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
        }
        public T InstantiateController<T>(GameObject pawn) where T : Controller,new()
        {
            T controller = new();

            controller.SetPawn(pawn);

            _gameLoop.UpdateEvent += controller.Update;

            return controller;
        }
        public T InstantiatePlayerController<T>(GameObject pawn) where T : PlayerController, new()
        {
            T controller = new();

            controller.SetPawn(pawn);

            _gameLoop.UpdateEvent += controller.Update;
            _gameLoop.UpdateInput += controller.InputProcess;

            return controller;
        }
    }
}
