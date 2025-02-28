using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
using AgarioGame.Engine.Core.Time;
using SFML.Graphics;

namespace AgarioGame.SeaBattleGame.Units
{
    public enum CellState
    {
        Empty,
        HasShip,
        Missed,
        Hited,
    }
    public class Cell : GameObject
    {
        private bool _hasShip;
        private bool _shooted;
        private bool _isVisible;
        public CellState GetCellState()
        {
            return (_hasShip, _shooted) switch
            {
                (true, true) => CellState.Hited,
                (true, false) => CellState.HasShip,
                (false, true) => CellState.Missed,
                (false, false) => CellState.Empty,
            };
        }
        public void SetShip(bool isHasShip)
        {
            _hasShip = isHasShip;
            SetNewTexture();
        }
        public void SetShooted(bool isShooted)
        {
            _shooted = isShooted;
            SetNewTexture();
        }
        public void SetVisiblity(bool isVisible)
        {
            _isVisible = isVisible;
        }
        public void SetTemporaryVisiblity(float seconds,bool visibility)
        {
            _isVisible = visibility;
            TimerManager.Instance.SetTimeout(() => _isVisible = !visibility, seconds);
        }
        private void SetNewTexture()
        {
            CellState state = GetCellState();

            Texture newTexture = null;

            if(state == CellState.Empty)
            {
                newTexture = Resources.GetTexture("newTexture");
            }
            if (state == CellState.Missed)
            {
                newTexture = Resources.GetTexture("newTexture");
            }
            if (state == CellState.Hited)
            {
                newTexture = Resources.GetTexture("newTexture");
            }
            if (state == CellState.HasShip)
            {
                newTexture = Resources.GetTexture("newTexture");
            }

            if (newTexture == null)
                return;

            SetTexture(newTexture);
        }
    }
}
