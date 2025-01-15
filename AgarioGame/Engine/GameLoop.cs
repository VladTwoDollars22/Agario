using AgarioGame.Engine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarioGame
{
    public abstract class GameLoop
    {
        private RenderWindow window;

        private int targetFPS;

        private float _updateTrigger;

        public event Action Draw;
        public event Action Update;

        public RenderWindow Window => window;
        public GameLoop()
        {
            window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            targetFPS = 120;

            _updateTrigger = 1f / targetFPS;
        }


        public void DrawAll()
        {
            Draw?.Invoke();
        
        
        }
        public void UpdateAll()
        {
            Update?.Invoke();
        }

        public void MainGameLoop()
        {
            Initialisation();

            Clock clock = new Clock();
            long lastFrameTime = clock.ElapsedTime.AsMilliseconds();

            while (window.IsOpen)
            {
                long currentTime = clock.ElapsedTime.AsMilliseconds();
                GameTime.SetDeltaTime((currentTime - lastFrameTime) / 1000f);

                InputProcess();

                if (GameTime.DeltaTime  > _updateTrigger)
                {
                    lastFrameTime = currentTime;

                    Logic();
                    Render();
                }
            }
        }

        private void Initialisation()
        {
            InitializeWindowEvents();
        }
        private void InitializeWindowEvents()
        {
            window.Closed += WindowClosed;
        }
        public abstract void GameInitialisation();

        private void InputProcess()
        {
            window.DispatchEvents();
        }

        private void Logic()
        {

        }

        private void Render()
        {
            window.Display();
        }
        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}
