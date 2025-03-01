using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using AgarioGame.Engine;
using AgarioGame.SeaBattleGame.GameExtentions;
using AgarioGame.SeaBattleGame.Units;
using TGUI;
public enum GameMode
{
    PVP,
    PVE,
    EVE,
}

public enum Action
{
    Radar,
    None,
}

public enum RoundResult
{
    Player1Win,
    Player2Win,
    Draw,
}
public class SeaBattleRound
{
    private Player _player1;
    private Player _player2;

    private (int x, int y) _actionPoint;

    private Player _attacker;
    private Player _defender;

    GameMode currentGameMode;

    private RoundResult _roundResult;
    public RoundResult GetRoundResult() => _roundResult;

    public SeaBattleRound(GameMode gameMode, Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;

        currentGameMode = gameMode;
    }
    public void RoundProcess()
    {
        while (!IsEndGame())
        {

        }
    }
    private void ShootLogic()
    {
        //if (_attacker.usingRadar)
        //{
        //    TransitionVisual();
        //    return;
        //}

        if (_actionPoint.x == -1 || _actionPoint.y == -1)
            return;

        GridMap defenderField = _defender.Map;
        ShootState shootState = defenderField.GetShootState(_actionPoint);

        if (shootState == ShootState.Hitting)
        {
            _defender.TakeDamage(1);
        }
        else if (shootState == ShootState.Missing)
        {
            (_defender, _attacker) = (_attacker, _defender);
        }

        defenderField.GetCell(_actionPoint).SetShooted(true);

    }
    private bool IsEndGame()
    {
        return _player1.HP == 0 || _player2.HP == 0;
    }
    public void Initialization()
    {
        Start();
        GenerationProcess();
    }
    private void Start()
    {
        SetRoles();
        SetGameMode();
    }
    private void SetRoles()
    {
        _attacker = _player1;
        _defender = _player2;
    }
    private void SetGameMode()
    {
        switch (currentGameMode)
        {
            case GameMode.PVP:
                _player1._isBot = false;
                _player2._isBot = false;
                break;
            case GameMode.PVE:
                _player1._isBot = false;
                _player2._isBot = true;
                break;
            default:
                _player1._isBot = true;
                _player2._isBot = true;
                break;
        }
    }
    private void GenerationProcess()
    {
        GenerateFields();
    }
    private void GenerateFields()
    {
        _player1.Map.CreateField();
        _player1.Map.PlaceShips();

        _player2.Map.CreateField();
        _player2.Map.PlaceShips();
    }
    private void CalculateRoundResult()
    {
        Player winner = GetWinner();

        if (winner == _player1)
            _roundResult = RoundResult.Player1Win;
        else if (winner == _player2)
            _roundResult = RoundResult.Player2Win;
        else
            _roundResult = RoundResult.Draw;
    }
    private Player GetWinner()
    {
        if (_player1.HP == 0)
            return _player2;
        else
            return _player1;
    }
}


