using SFML.Graphics;
using TGUI;
using AgarioGame.Engine.ScenesExtentions;
using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using AgarioGame.Game.Configs;
using AgarioGame.Engine.UIExtentions;

namespace AgarioGame.Game.Scenes
{
    public class LobbyScene : Scene
    {
        private Canvas _canvas;

        private GameObject _fon;

        public LobbyScene() : base() { }
        public override void Initialisation()
        {
            InitializeFon();
            InitializeUI();
        }
        private void Play()
        {
            SceneManager.ChangeSceneOn(new AgarioGame());
        }
        private void InitializeFon()
        {
            _fon = _gameObjFactory.Instantiate<GameObject>(new(0, 0), new(255, 255, 255), new(1.5f, 1.1f), Resources.GetTexture("paperfon.jpg"));
            _fon.SetGameField(GameConfig.GameFieldSize);
            _activeObjects.Add(_fon);
        }
        private void InitializeUI()
        {
            _canvas = _uIObjectFactory.InstantiateCanvas();

            Button startButton = _uIObjectFactory.InstantiateButton(_canvas, new(700, 500), new(400, 150), "Play", "Розпочати гру");
            startButton.Connect("Clicked", Play);

            TextArea text = _uIObjectFactory.InstantiateText(_canvas, new(700, 300), new(400, 150), "Text", "Ласкаво просимо в шизо агаріо" +
                ",ви Кирило,вами 3 рочки й через вашу неслухняність" +
                " в садочку вас посадили в куток з карандашем та бумажкою" +
                ",й ви почали виміщати свою злобу на уявних кружечках");
        }
        public override void OnDelete()
        {
            _canvas.Destroy();
        }
    }
}
