namespace AgarioGame.Engine.Animation
{
    public class StateMachine
    {
        private State _currentState;
        private Dictionary<State, List<Transition>> _transitions;

        public StateMachine(State startState, Dictionary<State, List<Transition>> transitions)
        {
            _currentState = startState;
            _transitions = transitions;
        }
        public void Logic()
        {
            List<Transition> currentTransitions = _transitions[_currentState];

            foreach(Transition transition in currentTransitions)
            {
                if (transition.CanDoTransition())
                {
                    ChangeState(transition.TargetState);
                }
            }
        }
        private void ChangeState(State newState)
        {
            _currentState.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }
    }
}
