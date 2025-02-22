using TGUI;

namespace AgarioGame.Engine
{
    public static class Subscriber
    {
        private static GameLoop _loop;

        public static void Initialize(GameLoop loop)
        {
            _loop = loop;
        }
        public static void SubscribeGUIOnDraw(Gui gui)
        {
            _loop.DrawEvent += gui.Draw;
        }
        public static void SubscribeOnUpdate(IUpdatable Object)
        {
            _loop.UpdateEvent += Object.Update;
        }
        public static void SubscribeOnDraw(IDrawable Object)
        {
            _loop.DrawEvent += Object.Draw;
        }
        public static void SubscribeOnInput(IInputHandler Object)
        {
            _loop.UpdateInput += Object.InputProcess;
        }
    }
}
