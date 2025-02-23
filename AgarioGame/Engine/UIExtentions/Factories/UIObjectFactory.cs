using AgarioGame.Engine.Utilities;
using TGUI;

namespace AgarioGame.Engine.UIExtentions.Factories
{
    public class UIObjectFactory
    {
        public UIObjectFactory()
        {
            Dependency.Register(this);
        }
        public Canvas InstantiateCanvas()
        {
            Canvas canvas = new(GameLoop.Window);

            Subscriber.SubscribeOnDraw(canvas);

            return canvas;
        }
        public Button InstantiateButton(Canvas canvas, Vector2f pos, Vector2f size, string Name, string Text)
        {
            Button Button = new Button();
            Button.SetPosition(pos);
            Button.Text = Text;
            Button.SetSize(size);
            canvas.AddWidget(Button, Name);

            return Button;
        }
        public TextArea InstantiateText(Canvas canvas, Vector2f pos, Vector2f size, string Name, string textContent)
        {
            TextArea text = new TextArea();
            text.SetPosition(pos);
            text.SetSize(size);
            text.Text = textContent;
            canvas.AddWidget(text, Name);
            return text;
        }
    }
}
