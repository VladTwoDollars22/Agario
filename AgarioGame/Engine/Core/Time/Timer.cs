namespace AgarioGame.Engine.Core.Time
{
    public class Timer
    {
        public Action Action;
        public float RemainingTime;
        public bool IsRepeating;
        public float Interval;
        public int RepeatCount;

        public Timer(Action action, float time, bool repeating, int repeatCount = -1)
        {
            Action = action;
            RemainingTime = time;
            IsRepeating = repeating;
            Interval = time;
            RepeatCount = repeatCount;
        }

        public bool Tick(float deltaTime)
        {
            RemainingTime -= deltaTime;
            if (RemainingTime > 0) return false;

            Action.Invoke();

            if (IsRepeating)
            {
                if (RepeatCount > 0)
                {
                    RepeatCount--;
                    if (RepeatCount == 0) return true;
                }
                RemainingTime = Interval;
                return false;
            }

            return true;
        }
    }
}
