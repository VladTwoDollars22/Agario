namespace AgarioGame.Engine
{
    public static class Time
    {
        private static float deltaTime = 0;
        private static float timeScale = 1f;

        public static float DeltaTime => deltaTime * timeScale;

        public static void SetDeltaTime(float currentDelta)
        {
            deltaTime = currentDelta;
        }
        public static void SetTimeScale(float newTimeScale)
        {
            timeScale = newTimeScale;
        }
    }
}
