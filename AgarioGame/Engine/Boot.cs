﻿namespace AgarioGame.Engine
{
    internal class Boot
    {
        public static void Main(string[] args)
        {
            GameLoop game = new GameLoop();

            game.MainGameLoop();
        }
    }
}
