﻿using AgarioGame.Engine;
using AgarioGame.Engine.Core.Input.Conrollers;
using SFML.System;

namespace AgarioGame.Game.Controllers
{
    public class AIController : Controller
    {
        public override void Update()
        {
            Pawn.SetVelocity(new Vector2f(0, 0));
        }
    }
}
