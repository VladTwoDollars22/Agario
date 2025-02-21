using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class TextObject : IDrawable
    {
        private Font _font;
        private Text _text;

        private bool _isVisible;
        private RenderWindow? _window;

        public TextObject(Vector2f pos)
        {
            _font = new Font(@"C:\Windows\Fonts\Arial.ttf");

            _text = new Text()
            {
                Font = _font,
                CharacterSize = 36,
                FillColor = Color.White,
                Style = Text.Styles.Bold,
                DisplayedString = "null",
            };

            _text.Position = pos;

            _isVisible = true;

            _window = null;
        }

        public void EditTextFilling(string filling)
        {
            _text.DisplayedString = filling;
        }
        public void RegisterText(GameLoop gameLoop)
        {
            Subscriber.SubscribeOnDraw(this);
        }
        public void Draw(RenderWindow window)
        {
            if (_isVisible)
            {
                window?.Draw(_text);
            }
        }
        public void SetVisiblity(bool isVisible)
        {
            _isVisible = isVisible;
        }
    }
}
