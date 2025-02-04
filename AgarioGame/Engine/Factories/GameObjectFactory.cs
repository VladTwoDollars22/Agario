﻿using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine.Factories
{
    public class GameObjectFactory
    {
        private GameLoop _gameLoop;

        public GameObjectFactory(GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
        }

        public T Instantiate<T>(Vector2f pos,Color color,float radius) where T : GameObject,new()
        {
            T obj = new T();

            obj.SetPosition(pos);
            obj.SetColor(color);
            obj.SetRadius(radius);

            RegisterObject(obj);

            obj.SetActive(true);
            obj.SetVisiblity(true);

            obj.SetWindow(_gameLoop.Window);

            return obj;
        }
        private void RegisterObject(GameObject obj)
        {
            _gameLoop.UpdateEvent += obj.Update;
            _gameLoop.DrawEvent += obj.Draw;
        }
    }
}
