namespace AgarioGame.Engine.Core.Time
{
    public class TimerManager : IUpdatable
    {
        private class Timer
        {
            public Action Action { get; }
            public float RemainingTime { get; set; }
            public bool IsRepeating { get; }
            public float Interval { get; }

            public Timer(Action action, float time, bool repeating)
            {
                Action = action;
                RemainingTime = time;
                IsRepeating = repeating;
                Interval = time;
            }
        }

        private List<Timer> timers = new List<Timer>();
        private Dictionary<string, Timer> namedIntervals = new Dictionary<string, Timer>();

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
                var timer = timers[i];
                timer.RemainingTime -= Time.DeltaTime;

                if (timer.RemainingTime <= 0)
                {
                    timer.Action.Invoke();

                    if (timer.IsRepeating)
                    {
                        timer.RemainingTime = timer.Interval;
                    }
                    else
                    {
                        timers.RemoveAt(i);
                    }
                }
            }
        }
        public void RegisterManager(GameLoop loop)
        {
            loop.UpdateEvent += Update;
        }
    }
}
