using Chess.Factory.Factory.Chessmans;
using Chess.Factory;

namespace Chess.Player;

public class BlackPlayer : Player
{
    public BlackPlayer(string name) : base(name) { }
    public override bool IsWhite
    {
        get { return false; }
    }

    public override void ReplaceChessman(IChessman chessman, ChessmanName name, Point position)
    {
        var bFactory = new BlackChessmanFactory();
        int index = PlayerChessmans.IndexOf(chessman);
        if (index >= 0)
            PlayerChessmans[index] = bFactory.CreateChessman(name, position);
        else // ?
            throw new ArgumentException($"The {chessman} is not found in the list");
    }
}
