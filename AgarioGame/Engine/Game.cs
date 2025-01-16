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
            GameObject GameObj = new(new SFML.System.Vector2f(1, 1), 50, Color.Yellow);
            GameObj.RegisterObject(gameloop);
            GameObj.SetSpeed(100);
            GameObj.SetVelocity(new SFML.System.Vector2f(1,1));
            TextObject text = new TextObject(new SFML.System.Vector2f(800,100));
            text.EditTextFilling("Aboba");
            text.RegisterText(gameloop);
            
        }
        public void Logic()
        {

        }
    }
}
