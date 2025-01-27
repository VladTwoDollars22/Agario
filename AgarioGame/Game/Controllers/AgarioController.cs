using AgarioGame.Engine;

namespace AgarioGame.Game.Controllers
{
    public class AgarioController : IInputHandler
    {
        public PlayableObject Pawn;

        private bool _isBot;

        public AgarioController(bool isBot, GameLoop loop, PlayableObject obj)
        {
            _isBot = isBot;

            Pawn = obj;

            RegisterActor(loop);
        }
        public void RegisterActor(GameLoop loop)
        {
            loop.UpdateEvent += InputProcess;
        }

        public void InputProcess()
        {
            Pawn.SetVelocity(new(0, 0));

            if (!_isBot)
            {
                Pawn.SetVelocity(InputManager.GetInput());
            }
        }
    }
}
