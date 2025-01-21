﻿using AgarioGame.Game;
using SFML.System;

namespace AgarioGame.Engine
{
    public class Player : GameObject,IInputHandler
    {
        private float mass;
        private float massFactor;
        private float massGrowMultiplicator;

        public bool IsBot;

        private float baseSpeed;

        public float Mass => mass;
        public Player(Vector2f spawnPos,float radius, SFML.Graphics.Color color, bool isBot) : base(spawnPos, radius, color)
        {
            mass = GameConfig.PlayerMass;
            massFactor = GameConfig.MassFactor;
            massGrowMultiplicator = GameConfig.MassGrowMult;
            baseSpeed = GameConfig.BaseSpeed;

            SetGameField(GameConfig.GameFieldSize);

            UpdateSpeed();

            IsBot = isBot;
        }
        public void RegisterActor(GameLoop gameLoop)
        {
            gameLoop.UpdateInput += InputProcess;
        }
        public override void Logic()
        {
            
        }
        public void InputProcess()
        {
            if (!IsBot)
            {
                SetVelocity(new Vector2f(0, 0));

                SetVelocity(InputManager.GetInput());
            }
            else
            {
                return;
            }
        }
        public void Upgrade(float newMass)
        {
            mass += newMass * massGrowMultiplicator;

            SetRadius(mass / 10f);

            UpdateSpeed();
        }
        private void UpdateSpeed()
        {
            float newSpeed = baseSpeed / (float)Math.Sqrt(mass * massFactor);

            SetSpeed(newSpeed);
        }
        public void EatMe()
        {
            Destroy();
        }
    }
}
