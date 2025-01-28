using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class AIController : BaseController
    {
        public AIController(GameLoop loop) : base(loop)
        {

        }

        public override void Update()
        {
            Pawn.SetVelocity(new (0,0));
        }
    }
}
