namespace AgarioGame.Engine.Animation
{
    public class Transition
    {
        private State _target;
        private List<Func<bool>> _conditions;

        public State TargetState => _target;
        public Transition(State state)
        {
            _target = state;
            _conditions = new();
        }
        public void AddCondition(Func<bool> condition)
        {
            _conditions.Add(condition);
        }
        public bool CanDoTransition()
        {
            if(_conditions.Count == 0)
            {
                return false;
            }

            return _conditions.All(condition => condition());
        }
    }
}
