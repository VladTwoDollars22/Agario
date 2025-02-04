﻿namespace AgarioGame.Engine.Core.Input.Conrollers
{
    public class Controller : IUpdatable
    {
        private GameObject _pawn;

        public GameObject Pawn => _pawn;

        public virtual void Update() { }

        public void SetPawn(GameObject newObj)
        {
            _pawn = newObj;
        }
    }
}
