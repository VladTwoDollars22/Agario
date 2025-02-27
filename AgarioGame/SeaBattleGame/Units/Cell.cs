using AgarioGame.Engine;
using AgarioGame.Engine.Animation;
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
        public void SetShooted()
        {
            _shooted = true;
            SetNewTexture();
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
