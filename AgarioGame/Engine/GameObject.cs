using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class GameObject : IUpdatable,IDrawable
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
        public void Update()
        {
            Move();
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(_shape);
        }
        public void SetVelocity(Vector2f direction)
        {
            _velocity = Mathematics.Normalize(direction) * _speed;
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
    }
}