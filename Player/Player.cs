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

    public IChessman FindChessman(IChessman chessman)
    {
        int index = PlayerChessmans.IndexOf(chessman);
        if (index >= 0)
            return PlayerChessmans[index];
        else // ??
            return new Nun(new Point(0, 0)); // TODO: такооое, как по мне, хзхзхзхз....
    }

    public void RemoveChessman(IChessman chessman)
    {
        if (PlayerChessmans.Contains(chessman))
            PlayerChessmans.Remove(chessman);
        else
            throw new ArgumentException($"The chessman {chessman} is not found in the list");
    }

    public abstract void ReplaceChessman(IChessman chessman, ChessmanName name, Point position); // TODO: вроде как это ваабще не нужно, за этоо будет доска отвечать.
}
