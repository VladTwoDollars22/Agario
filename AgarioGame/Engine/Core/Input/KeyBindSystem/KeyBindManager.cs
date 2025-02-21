using SFML.Window;

namespace AgarioGame.Engine.Core.Input.KeyBind
{
    public class KeyBindManager : IUpdatable
    {
        private List<KeyBind> _keyBinds = new List<KeyBind>();

        public KeyBindManager()
        {
            RegisterManager();
        }
        public void Update()
        {
            UpdateKeyBinds();
            InvokeCallbacks();
        }
        public void UpdateKeyBinds()
        {
            foreach (KeyBind kb in _keyBinds)
                kb.Update();
        }
        public void InvokeCallbacks()
        {
            foreach (KeyBind kb in _keyBinds)
                kb.InvokeCallBacks();
        }
        public KeyBind AddKeyBind(string name, Keyboard.Key key)
        {
            KeyBind newKeyBind = new KeyBind(name, key);
            _keyBinds.Add(newKeyBind);

            return newKeyBind;
        }
        public KeyBind GetKeyBind(string name)
            => _keyBinds.Single(x => x.Name == name);

        public void RegisterManager()
        {
            Subscriber.SubscribeOnUpdate(this);
        }
    }
}
