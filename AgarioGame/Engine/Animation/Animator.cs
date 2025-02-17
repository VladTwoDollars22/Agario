using SFML.Graphics;

namespace AgarioGame.Engine.Animation
{
    public class Animator
    {
        private StateMachine _stateMachine;
        private Sprite _animatedSprite;

        private Dictionary<State, List<Transition>> _transitions;

        public Animator(Sprite sprite,State startState)
        {
            _animatedSprite = sprite;
            _transitions = new();

            _stateMachine = new(startState,_transitions);
        }
        public void CreateState(string name, AnimationClip clip,StateType type)
        {
            State state = new(clip,type,name);
            List<Transition> transitions = new();

            _transitions.Add(state, transitions);
        }
        public void AddTransition(string from, string to)
        {
            State stateFrom = null;
            State stateTo = null;

            foreach (State state in _transitions.Keys)
            {
                if (state.Name == from)
                {
                    stateFrom = state;
                    continue;
                }

                if (state.Name == to)
                {
                    stateTo = state;
                }
            }

            if (stateFrom != null && stateTo != null)
            {
                _transitions[stateFrom].Add(new Transition(stateTo));
            }
        }
    }
}
