﻿using AgarioGame.Engine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarioGame
{
    public class GameLoop
    {
        private RenderWindow _window;

        private int _targetFPS;

        private float _updateTrigger;

        public event Action DrawEvent;
        public event Action UpdateEvent;
        public event Action UpdateInput;

        private GameRules _game;

        public RenderWindow Window => _window;
        public GameLoop()
        {
            _window = new RenderWindow(new VideoMode(1920, 1080), "Agario");

            _targetFPS = 120;

            _updateTrigger = 1f / _targetFPS;

            _game = new GameRules(this);
        }
        public void MainGameLoop()
        {
            Initialisation();

            Clock clock = new Clock();
            long lastFrameTime = clock.ElapsedTime.AsMilliseconds();

            while (_window.IsOpen)
            {
                long currentTime = clock.ElapsedTime.AsMilliseconds();
                Engine.Time.SetDeltaTime((currentTime - lastFrameTime) / 1000f);

                InputProcess();

                if (Engine.Time.DeltaTime  > _updateTrigger)
                {
                    lastFrameTime = currentTime;

                    Update();
                    Render();
                }
            }
        }
        private void Initialisation()
        {
            _game.Initialisation();
            InitializeWindowEvents();
        }
        private void InitializeWindowEvents()
        {
            _window.Closed += WindowClosed;
        }
        public void GameInitialisation()
        {
            _game.Initialisation();
        }
        private void InputProcess()
        {
            _window.DispatchEvents();

            MovementInput.UpdateInput();
            UpdateInput?.Invoke();
        }
        private void Update()
        {
            UpdateAll();

            _game.Logic();
        }
        private void UpdateAll()
        {
            UpdateEvent?.Invoke();
        }
        private void Render()
        {
            _window.Clear();

            DrawAll();

            _window.Display();
        }
        public void DrawAll()
        {
            DrawEvent?.Invoke();
        }
        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}
