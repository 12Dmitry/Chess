using Chess.Factory.Factory.Chessmans;
using Chess.Factory;

namespace Chess.Player;

public class WhitePlayer : Player
{
    public WhitePlayer(string name) : base(name) { }
    public override bool IsWhite
    {
        get { return true; }
    }

    public override void ReplaceChessman(IChessman chessman, ChessmanName name, Point position)
    {
        var wFactory = new WhiteChessmanFactory();
        int index = PlayerChessmans.IndexOf(chessman);
        if (index >= 0)
            PlayerChessmans[index] = wFactory.CreateChessman(name, position);
        else // ?
            throw new ArgumentException($"The chessman {chessman} is not found in the list");
    }
}
