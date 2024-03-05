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
}
