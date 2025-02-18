using SFML.Graphics;

namespace AgarioGame.Engine.Animation
{
    public class Animator : IUpdatable
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
        public void Update()
        {
            _stateMachine.Logic();
        }
        public void SetSprite(Sprite sprite)
        {
            _animatedSprite = sprite;
        }
        public void CreateState(string name, AnimationClip clip,StateType type)
        {
            State state = new(clip,type,name);
            List<Transition> transitions = new();

            _transitions.Add(state, transitions);
        }
        public void AddConditionToTransition(string from, string to, Func<bool> condition)
        {
            State fromState = GetStateByName(from);
            State toState = GetStateByName(to);

            if (fromState != null && toState != null && _transitions.ContainsKey(fromState))
            {
                var transition = _transitions[fromState].FirstOrDefault(t => t.TargetState == toState);

                if (transition != null)
                {
                    transition.AddCondition(condition);
                }
                else
                {
                    Console.WriteLine($"Не знайдено переходу з {from} до {to}.");
                }
            }
            else
            {
                Console.WriteLine($"Стан {from} або {to} не мають переходу.");
            }
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
        private State GetStateByName(string name)
        {
            return _transitions.Keys.FirstOrDefault(state => state.Name == name);
        }
    }
}
