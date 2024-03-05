using System.Xml.Linq;

namespace Chess.Factory.Factory.Chessmans;

public class Horse : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }

    public Horse(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
    }

    public bool VerifyMove((Point initial, Point final) coordinates)
    {
        return (Math.Abs(coordinates.initial.X - coordinates.final.X) == 1
        && Math.Abs(coordinates.initial.Y - coordinates.final.Y) == 2)
        || (Math.Abs(coordinates.initial.X - coordinates.final.X) == 2 
        && Math.Abs(coordinates.initial.Y - coordinates.final.Y) == 1);
    }
}
