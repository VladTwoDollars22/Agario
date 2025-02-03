using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class GameObject : IUpdatable,IDrawable
    {
        public CircleShape Shape;

        private Vector2f _velocity;
        private float _speed;

        private bool _isActive;
        private bool _isVisible;

        private RenderWindow _window;

        private Vector2f _gameField;
        public Vector2f GetVelocity() => _velocity;
        public GameObject()
        {
            Shape = new();
        }
        public void Update()
        {
            if (_isActive)
            {
                Logic();
                Move();
            }
        }
        public virtual void Logic()
        {

        }
        public void Draw()
        {
            if (_isVisible)
            {
                _window?.Draw(Shape);
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
            if (!_isActive)
                return;

            Vector2f nextPosition = Shape.Position + _velocity * Time.DeltaTime;
            float ShapeRadius2 = Shape.Radius * 2;

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

            Shape.Position = nextPosition;
        }
        public FloatRect GetBounds()
        {
            return Shape.GetGlobalBounds();
        }
        public bool IsFasedWith(GameObject obj)
        {
            FloatRect spriteBounds = GetBounds();
            FloatRect facedObjBounds = obj.GetBounds();

            return spriteBounds.Intersects(facedObjBounds);
        }
        public void SetPosition(Vector2f pos)
        {
            Shape.Position = pos;
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
            Shape.Radius = newRad;
        }
        public void SetColor(Color newColor)
        {
            Shape.FillColor = newColor;
        }
        public bool ObjectIn(GameObject obj)
        {
            if (!_isActive)
                return false;

            Vector2f centerThis = Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
            Vector2f centerOther = obj.Shape.Position + new Vector2f(obj.Shape.Radius, obj.Shape.Radius);

            float distance = Mathematics.Distance(centerThis, centerOther);

            return distance + Shape.Radius <= obj.Shape.Radius;
        }
        public void SetGameField(Vector2f gameField)
        {
            _gameField = gameField;
        }
    }
}