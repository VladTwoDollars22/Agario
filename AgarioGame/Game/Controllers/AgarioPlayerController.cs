using AgarioGame.Engine;
using AgarioGame.Game.Scenes;
using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.Game.AudioExtensions;
using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class AgarioPlayerController : PlayerController
    {
        private Vector2f _velocity;
        private PlayableObject _playablePawn;
        public PlayableObject PlayablePawn => _playablePawn;

        private List<AIController> _enemyes;
        public AgarioPlayerController()
        {
            _onPawnUpdated += pawn => _playablePawn = pawn as PlayableObject;
        }
        public override void Update()
        {
            if (!_isActive) return;

            AudioProcess();
            Pawn.SetVelocity(_velocity);
        }
        public override void Start()
        {
            InitializekeyBinds();
        }
        public void SetEnemyes(List<AIController> AIControllers)
        {
            _enemyes = AIControllers;
        }
        private void AudioProcess()
        {
            if (_velocity == new Vector2f(0, 0))
            {
                return;
            }
            else
            {
                AudioSystem.PlaySound("moving");
            }
        }
        public void Swap()
        {
            int randInt = Mathematics.GetRandomNumber(0, _enemyes.Count - 1);

            PlayableObject playerPawn = PlayablePawn;

            SetPawn(_enemyes[randInt].Pawn);

            _enemyes[randInt].SetPawn(playerPawn);
        }
        public override void InputProcess()
        {
            if (!_isActive) return;

            _velocity = MovementInput.GetInput();
        }
        public override void InitializekeyBinds()
        {
            KeyBindManager.AddKeyBind("Swap",SFML.Window.Keyboard.Key.F);
            KeyBindManager.GetKeyBind("Swap").AddOnDownCallback(Swap);

            KeyBindManager.AddKeyBind("Rest", SFML.Window.Keyboard.Key.R);
            KeyBindManager.GetKeyBind("Rest").AddOnDownCallback(RestartGame);
        }
        public void RestartGame()
        {
            SceneManager.ChangeSceneOn(new AgarioGame.Game.Scenes.AgarioGame());
        }
        public void OnDestroy()
        {
            KeyBindManager.GetKeyBind("Swap").ResetOnDownCallback();
            KeyBindManager.GetKeyBind("Rest").ResetOnDownCallback();
        }
    }
}
