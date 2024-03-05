using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Square 
{
    public IChessman Chessman { get; set; }
    public bool IsWhite { get; private set; }

    public Square(IChessman chessman, bool white)
    {
        Chessman = chessman;
        IsWhite = white;
    }
}
