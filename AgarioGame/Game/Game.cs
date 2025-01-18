using SFML.Graphics;

namespace AgarioGame.Engine
{
    public class Game
    {
        GameLoop gameloop;
        public Game(GameLoop loop)
        {
            gameloop = loop;
        }
        public void Initialisation()
        {
            PlayerController GameObj = new(new SFML.System.Vector2f(50, 50), 50, Color.Yellow, 340);
            GameObj.RegisterObject(gameloop);
            GameObj.RegisterActor(gameloop);
            
        }
        public void Logic()
        {

        }
    }
}
