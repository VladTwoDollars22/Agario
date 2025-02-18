namespace AgarioGame.Engine
{
    public static class Subscriber
    {
        private static GameLoop _loop;

        public static void Initialize(GameLoop loop)
        {
            _loop = loop;
        }

        public static void SubscribeOnUpdate(IUpdatable Object)
        {
            _loop.UpdateEvent += Object.Update;
        }
    }
}
