using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarioGame.Engine
{
    public abstract class GameObject : IUpdatable,IDrawable
    {
        private CircleShape _shape;

        private Vector2f _velocity;
        private float _speed;

        private RenderWindow _window;

        private bool _isActive;
        private bool _isVisible;

        private Vector2f _gameField;
        public Vector2f GetVelocity() => _velocity;

        public GameObject()
        {
            _shape = new();

            _isActive = true;
            _isVisible = true;
        }
        public void Update()
        {
            if (_isActive)
            {
                Logic();
                Move();
            }
        }
        public abstract void Logic();
        public void Draw()
        {
            if (_isVisible)
            {
                _window?.Draw(_shape);
            }
        }
        public void RegisterObject(GameLoop gameLoop)
        {
            SetWindow(gameLoop.Window);

            gameLoop.DrawEvent += Draw;
            gameLoop.UpdateEvent += Update;
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
            if (!_isActive)
                return;

            Vector2f nextPosition = _shape.Position + _velocity * Time.DeltaTime;
            float ShapeRadius2 = _shape.Radius * 2;

            if (nextPosition.X < 0)
            {
                nextPosition.X = 0;
                _velocity.X = 0;
            }
            else if (nextPosition.X + ShapeRadius2 > _gameField.X)
            {
                nextPosition.X = _gameField.X - ShapeRadius2;
                _velocity.X = 0;
            }

            if (nextPosition.Y < 0)
            {
                nextPosition.Y = 0;
                _velocity.Y = 0; 
            }
            else if (nextPosition.Y + ShapeRadius2 > _gameField.Y)
            {
                nextPosition.Y = _gameField.Y - ShapeRadius2;
                _velocity.Y = 0;
            }

            _shape.Position = nextPosition;
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
        public void SetWindow(RenderWindow window)
        {
            _window = window;
        }
        public void Destroy()
        {
            SetVisiblity(false);
            SetActive(false);
        }
        public void SetVisiblity(bool isVisible)
        {
            _isVisible = isVisible;
        }
        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }
        public void SetRadius(float newRad)
        {
            _shape.Radius = newRad;
        }
        public void SetColor(Color newColor)
        {
            _shape.FillColor = newColor;
        }
        public bool ObjectIn(GameObject obj)
        {
            if (!_isActive)
                return false;

            Vector2f centerThis = _shape.Position + new Vector2f(_shape.Radius, _shape.Radius);
            Vector2f centerOther = obj._shape.Position + new Vector2f(obj._shape.Radius, obj._shape.Radius);

            float distance = Mathematics.Distance(centerThis, centerOther);

            return distance + _shape.Radius <= obj._shape.Radius;
        }
        public void SetGameField(Vector2f gameField)
        {
            _gameField = gameField;
        }
    }
}