using SFML.Graphics;
using TGUI;

namespace AgarioGame.Engine.UIExtentions
{
    public class Canvas : IDrawable
    {
        private Gui _gui;
        private List<Widget> _widgets;

        public Canvas(RenderWindow window)
        {
            _gui = new(window);
            _widgets = new List<Widget>();
        }
        public void AddWidget(Widget widget,string name)
        {
            _gui.Add(widget,name);
            _widgets.Add(widget);
        }
        public void Draw()
        {
            _gui.Draw();
        }
        public void Destroy()
        {
            foreach(Widget widget in _widgets)
            {
                _gui.Remove(widget);
            }
        }
    }
}
