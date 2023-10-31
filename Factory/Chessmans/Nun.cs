namespace Chess.Factory.Factory.Chessmans;

public class Nun : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }

    public Nun(Point position)
    {
        Name = ChessmanName.Nun;
        IsWhite = true;
        Position = position;
    }
    public Nun(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
    }
    public bool VerifyMove(Point initial, Point final)
    {
        return false;
    }
}
