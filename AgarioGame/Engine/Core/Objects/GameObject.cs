using AgarioGame.Engine.Core.Time;
using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class GameObject : IUpdatable, IDrawable
    {
        public Sprite Sprite { get; private set; }

        private Vector2f _velocity;
        private float _speed;

        private bool _isActive;
        private bool _isVisible;

        private Vector2f _gameField;

        public Vector2f GetVelocity() => _velocity;

        public GameObject()
        {
            Sprite = new Sprite();
        }

        public void Update()
        {
            if (_isActive)
            {
                Logic();
                Move();
            }
        }

        public virtual void Logic() { }

        public void Draw(RenderWindow window)
        {
            if (_isVisible)
            {
                window.Draw(Sprite);
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
        public void SetSize(Vector2f newSize)
        {
            Sprite.Scale = newSize;
        }
        public void SetTexture(Texture texture)
        {
            Sprite.Texture = texture;
        }
        public void Move()
        {
            if (!_isActive)
                return;

            Vector2f nextPosition = Sprite.Position + _velocity * AgarioGame.Engine.Core.Time.Time.DeltaTime;
            FloatRect bounds = Sprite.GetGlobalBounds();

            bool isTooWide = bounds.Width >= _gameField.X;
            bool isTooTall = bounds.Height >= _gameField.Y;

            if (!isTooWide)
            {
                if (nextPosition.X < 0)
                {
                    nextPosition.X = 0;
                    _velocity.X = 0;
                }
                else if (nextPosition.X + bounds.Width > _gameField.X)
                {
                    nextPosition.X = _gameField.X - bounds.Width;
                    _velocity.X = 0;
                }
            }

            if (!isTooTall)
            {
                if (nextPosition.Y < 0)
                {
                    nextPosition.Y = 0;
                    _velocity.Y = 0;
                }
                else if (nextPosition.Y + bounds.Height > _gameField.Y)
                {
                    nextPosition.Y = _gameField.Y - bounds.Height;
                    _velocity.Y = 0;
                }
            }

            Sprite.Position = nextPosition;
        }


        public FloatRect GetBounds()
        {
            return Sprite.GetGlobalBounds();
        }

        public bool IsFasedWith(GameObject obj)
        {
            return GetBounds().Intersects(obj.GetBounds());
        }

        public void SetPosition(Vector2f pos)
        {
            Sprite.Position = pos;
        }
        public void Destroy()
        {
            SetVisibility(false);
            SetActive(false);
        }

        public void SetVisibility(bool isVisible)
        {
            _isVisible = isVisible;
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }

        public void SetColor(Color newColor)
        {
            Sprite.Color = newColor;
        }

        public bool ObjectIn(GameObject obj)
        {
            if (!_isActive || !obj._isActive)
                return false;

            FloatRect thisBounds = GetBounds();
            FloatRect objBounds = obj.GetBounds();

            
            bool isInside =
                thisBounds.Left >= objBounds.Left &&
                thisBounds.Top >= objBounds.Top &&
                thisBounds.Left + thisBounds.Width <= objBounds.Left + objBounds.Width &&
                thisBounds.Top + thisBounds.Height <= objBounds.Top + objBounds.Height;

            return isInside;
        }


        public void SetGameField(Vector2f gameField)
        {
            _gameField = gameField;
        }
    }
}
