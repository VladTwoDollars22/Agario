namespace AgarioGame.Engine.Conrollers
{
    public class Controller : IUpdatable
    {
        private GameObject _pawn;
        protected Action<GameObject> _onPawnUpdated;

        public GameObject Pawn => _pawn;

        public virtual void Update() { }

        public void SetPawn(GameObject newObj)
        {
            _pawn = newObj;
            _onPawnUpdated.Invoke(_pawn);
        }
        public virtual void Start()
        {
        }
    }
}
