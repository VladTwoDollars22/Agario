using System.Drawing;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class GameObject
    {
        private CircleShape _shape;
        private Vector2f _velocity;
        private float _speed;

        public Vector2f GetVelocity() => _velocity;

        public GameObject(Vector2f spawnPosition, Vector2f scale, float radius, SFML.Graphics.Color color)
        {
            _shape = new CircleShape()
            {
                Radius = radius,
                FillColor = color,
                Position = spawnPosition,
            };

            _speed = 340;
        }
        public void SetVelocity(Vector2f direction)
        {
            _velocity = Normalize(direction) * _speed;
        }
        public void SetSpeed(float speed)
        {
            _speed = speed; 
        }
        public void Move()
        {
            _shape.Position += _velocity * GameTime.DeltaTime;
        }
        public FloatRect GetBounds()
        {
            return _shape.GetGlobalBounds();
        }
        public bool IsFasedWith(GameObject obj)
        {
            FloatRect spriteBounds = GetBounds();
            FloatRect facedObjBounds = obj.GetBounds();

            return spriteBounds.Intersects(facedObjBounds);
        }
        public void SetPosition(Vector2f pos)
        {
            _shape.Position = pos;
        }
        private Vector2f Normalize(Vector2f vector)
        {
            float length = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

            if (length > 0)
            {
                return new Vector2f(vector.X / length, vector.Y / length);
            }
            else
            {
                return new Vector2f(0, 0);
            }
        }
        public void Destroy()
        {
            
        }
    }
}