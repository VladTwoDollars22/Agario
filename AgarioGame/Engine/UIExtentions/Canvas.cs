using SFML.Graphics;
using TGUI;

namespace AgarioGame.Engine.UIExtentions
{
    public class Canvas : IDrawable
    {
        private Gui _gui;

        public Canvas(RenderWindow window)
        {
            _gui = new(window);
        }
        public void AddWidget(Widget widget,string name)
        {
            _gui.Add(widget,name);
        }
        public void Draw()
        {
            _gui.Draw();
        }
        public void Destroy()
        {
            _gui.RemoveAllWidgets();
        }
    }
}
