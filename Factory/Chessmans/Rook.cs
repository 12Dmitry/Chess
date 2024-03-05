namespace Chess.Factory.Factory.Chessmans;

public class Rook : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }
    public bool HasMove { get; set; }
    public Rook(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
        HasMove = false;
    }
    public bool VerifyMove((Point initial, Point final) coordinates)
    {
        Move move = new(coordinates);
        bool valid = move.CheckVerticalMove() || move.CheckHorizontalMove();
        if (valid)
            HasMove = true;
        return valid;
    }
}
