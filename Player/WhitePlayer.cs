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
}
