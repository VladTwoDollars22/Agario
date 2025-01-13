using SFML.Graphics;
using SFML.System;

namespace AgarioGame.Engine
{
    public class TextObject
    {
        private Font font;

        private Text text;

        private TextObject(Vector2f pos)
        {
            font = new Font(@"C:\Windows\Fonts\Arial.ttf");

            text = new Text()
            {
                CharacterSize = 36,
                FillColor = Color.White,
                Style = Text.Styles.Bold
            };

            text.Position = pos;
        }

        public void EditTextFilling(string filling)
        {
            text.DisplayedString = filling;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(text);
        }
    }
}
