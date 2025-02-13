using System.Resources;
using SFML.Graphics;
using SFML.System;
using static System.Net.Mime.MediaTypeNames;

namespace AgarioGame.Engine.Factories
{
    public class GameObjectFactory
    {
        private GameLoop _gameLoop;

        public GameObjectFactory(GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
        }

        public T Instantiate<T>(Vector2f pos,Color color,Vector2f size,Texture texture) where T : GameObject,new()
        {
            T obj = new T();

            obj.SetPosition(pos);
            obj.SetTexture(texture);
            obj.SetColor(color);
            obj.SetSize(size);

            RegisterObject(obj);

            obj.SetActive(true);
            obj.SetVisibility(true);

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
