namespace AgarioGame.Engine.Animation
{
    public enum StateType
    {
        Action,
        LoopedAnim,
    }
    public class State
    {
        private AnimationClip _clip;
        private StateType _type;
        private string _name;

        public string Name => _name;
        public State(AnimationClip clip,StateType type,string name)
        {
            _clip = clip;
            _type = type;
            _name = name;
        }
        public void OnEnter()
        {
            _clip.Reset();

            if (_type == StateType.Action)
                _clip.PlayOnce();
            else if(_type == StateType.LoopedAnim)
                _clip.PlayLooped();
        }
        public void OnExit()
        {
            _clip.Stop();
        }
        public void SetClip(AnimationClip clip)
        {
            _clip = clip;
        }
        public void SetType(StateType type)
        {
            _type = type;
        }
    }
}
