using System.Resources;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine.Factories
{
    public class GameObjectFactory
    {
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

            return obj;
        }
        private void RegisterObject(GameObject obj)
        {
            Subscriber.SubscribeOnUpdate(obj);
            Subscriber.SubscribeOnDraw(obj);
        }
    }
}
