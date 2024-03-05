namespace Chess.Factory.Factory.Chessmans;

public class Bishop : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }

    public Bishop(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
    }
    public bool VerifyMove((Point initial, Point final) coordinates)
    {
        Move move = new(coordinates);
        return move.CheckDiagonalMove();
    }
}
