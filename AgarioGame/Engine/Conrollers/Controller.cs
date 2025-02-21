namespace AgarioGame.Engine.Conrollers
{
    public class Controller : IUpdatable
    {
        private GameObject _pawn;
        protected Action<GameObject> _onPawnUpdated;
        protected bool _isActive;

        public GameObject Pawn => _pawn;

        public virtual void Update() { }

        public void SetPawn(GameObject newObj)
        {
            _pawn = newObj;
            _onPawnUpdated.Invoke(_pawn);
            _isActive = true;
        }
        public virtual void Start()
        {
        }
        public void Destroy()
        {
            _isActive = false;
            OnDestroy();
        }
        public virtual void OnDestroy()
        {

        }
    }
}
