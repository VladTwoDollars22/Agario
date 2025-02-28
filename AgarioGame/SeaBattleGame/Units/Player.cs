using AgarioGame.SeaBattleGame.GameExtentions;
using TGUI;

namespace AgarioGame.SeaBattleGame.Units
{
    public class Player
    {
        public string NickName;
        public List<int> ships;
        public GridMap map;

        public int HP { get; private set; }

        public (int width, int heigth) radarArea;
        public bool usingRadar = false;
        public float radarUsingTime;
        public (int x, int y) radarPoint;
        public int radarsCount;

        public (int width, int height) fieldSize;

        public Player(string nickName)
        {
            NickName = nickName;
            radarsCount = 1;
            radarPoint = (-1, -1);
            radarArea = (3, 3);

            fieldSize = (9, 9);

            ships = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            HP = ships.Sum();
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }

        public void UseRadar()
        {
            radarsCount--;
        }
        public void Reset()
        {
            HP = ships.Sum();
        }
    }
}
