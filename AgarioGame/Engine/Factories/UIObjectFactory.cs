using TGUI;

namespace AgarioGame.Engine.Factories
{
    public class UIObjectFactory
    {
        public Gui InstantiateCanvas()
        {
            Gui canvas = new(GameLoop.Window);

            Subscriber.SubscribeGUIOnDraw(canvas);

            return canvas;
        }
        public Button InstantiateButton(Gui canvas,Vector2f pos,Vector2f size,string Name,string Text)
        {
            Button Button = new Button();
            Button.SetPosition(pos);
            Button.Text = Text;
            Button.SetSize(size);
            canvas.Add(Button, Name);

            return Button;
        }
        public TextArea InstantiateText(Gui canvas, Vector2f pos, Vector2f size, string Name, string textContent)
        {
            TextArea text = new TextArea();
            text.SetPosition(pos);
            text.SetSize(size);
            text.Text = textContent;
            canvas.Add(text, Name);
            return text;
        }
    }
}
