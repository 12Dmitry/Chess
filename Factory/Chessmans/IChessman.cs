namespace Chess.Factory.Factory.Chessmans;

public interface IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; }
    public Point Position { get; set; }

    bool VerifyMove((Point initial, Point final) coordinates);
}
