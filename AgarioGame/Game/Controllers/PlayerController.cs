using AgarioGame.Engine;
using AgarioGame.Engine.Core.Input.KeyBind;
using SFML.System;
using SFML.Window;

namespace AgarioGame.Game.Controllers
{
    public class PlayerController : BaseController,IInputHandler
    {
        private Vector2f _velocity;
        private KeyBindManager _keyBindManager;
        public PlayerController(GameLoop loop,GameRules rules) : base(loop) 
        {
            _keyBindManager = new(loop);

            InitializekeyBinds(rules);

            RegisterActor(loop);
        }
        public void RegisterActor(GameLoop loop)
        {
            loop.UpdateEvent += InputProcess;
        }
        public override void Update()
        {
            Pawn.SetVelocity(_velocity);
        }

        public void InputProcess()
        {
            _velocity = InputManager.GetInput();
        }
        private void InitializekeyBinds(GameRules rules)
        {
            _keyBindManager.AddKeyBind("Swap", Keyboard.Key.F);
            _keyBindManager.GetKeyBind("Swap").AddOnDownCallback(rules.Swap);
        }
    }
}
