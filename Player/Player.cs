using Chess.Factory;
using Chess.Factory.Factory.Chessmans;

namespace Chess.Player;

public abstract class Player
{
    public static bool CurrentPlayerIsWhite { get; set; }
    public string Name { get; private set; }
    public abstract bool IsWhite { get; }
    public Player(string name)
    {
        Name = name;
    }
    public List<IChessman> PlayerChessmans { get; protected set; } = new List<IChessman>();

    public void AddChessman(IChessman chessman)
    {
        PlayerChessmans.Add(chessman);
    }
}
