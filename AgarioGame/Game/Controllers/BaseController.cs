using AgarioGame.Engine;

namespace AgarioGame.Game.Controllers
{
    public abstract class BaseController : IUpdatable
    {
        private PlayableObject _pawn;

        public PlayableObject Pawn => _pawn;

        public BaseController(GameLoop loop)
        {
            RegisterController(loop);
        }
        private void RegisterController(GameLoop loop)
        {
            loop.UpdateEvent += Update;
        }
        public abstract void Update();
        public void SetPawn(PlayableObject newObj)
        {
            _pawn = newObj;
        }
    }
}
