namespace AgarioGame.Engine.Core.Time
{
    public class TimerManager : IUpdatable
    {
        public static TimerManager Instance = new();
        private List<Timer> timers = new List<Timer>();
        private Dictionary<string, Timer> namedIntervals = new Dictionary<string, Timer>();

        public TimerManager()
        {
            Subscriber.SubscribeOnUpdate(this);
        }
        public void SetTimeout(Action action, float delay)
        {
            timers.Add(new Timer(action, delay, false));
        }

        public void SetInterval(string name, Action action, float interval)
        {
            if (namedIntervals.ContainsKey(name))
                return;

            var timer = new Timer(action, interval, true);
            namedIntervals[name] = timer;
            timers.Add(timer);
        }
        public void SetRepeatedInterval(string name, Action action, float interval, int repeatCount)
        {
            if (namedIntervals.ContainsKey(name))
                return;

            var timer = new Timer(action, interval, true, repeatCount);
            namedIntervals[name] = timer;
            timers.Add(timer);
        }

        public void StopInterval(string name)
        {
            if (namedIntervals.TryGetValue(name, out var timer))
            {
                timers.Remove(timer);
                namedIntervals.Remove(name);
            }
        }

        public void Update()
        {
            for (int i = timers.Count - 1; i >= 0; i--)
            {
                if (timers[i].Tick(Time.DeltaTime))
                {
                    timers.RemoveAt(i);
                }
            }
        }
    }
}
