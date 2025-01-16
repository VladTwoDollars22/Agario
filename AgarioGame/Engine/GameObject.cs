using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public class GameObject : IUpdatable,IDrawable
    {
        private CircleShape _shape;

        private Vector2f _velocity;
        private float _speed;

        private RenderWindow _window;

        private bool _isActive;
        private bool _isVisible;

        public Vector2f GetVelocity() => _velocity;

        public GameObject(Vector2f spawnPosition, float radius, Color color)
        {
            Console.WriteLine("Created");
            _shape = new CircleShape()
            {
                Radius = radius,
                FillColor = color,
                Position = spawnPosition,
            };

            _speed = 340;

            _isActive = true;
            _isVisible = true;
        }
        public void Update()
        {
            if (_isActive)
            {
                Move();
            }
        }
        public void Draw(RenderWindow window)
        {
            if (_isVisible)
            {
                window.Draw(_shape);
            }
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
        public void RegisterObject(GameLoop gameLoop)
        {
            SetWindow(gameLoop.Window);

            gameLoop.DrawEvent += Draw;
            gameLoop.UpdateEvent += Update;
        }
        public void SetWindow(RenderWindow window)
        {
            _window = window;
        }
        public void Draw()
        {
            _window?.Draw(_shape);
        }
        public void Destroy()
        {
            _isActive = false;
            _isVisible = false;
        }
        public void SetVisiblity(bool isVisible)
        {
            _isVisible = isVisible;
        }
        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }
    }
}