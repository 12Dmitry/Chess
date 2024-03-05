using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;

public abstract class Pawn : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; }
    public Point Position { get; set; }
    public bool HasMove { get; internal set; }
    public Pawn(ChessmanName name, Point position)
    {
        Name = name;
        IsWhite = this is WhitePawn;
        Position = position;
        HasMove = false;
    }

    public abstract bool Cut((Point initial, Point final) coordinates); // отдельно нужен чтобы проверить шах

    internal abstract void TransformToAnotherChessman(Point finalPosition);
    public abstract bool VerifyMove((Point initial, Point final) coordinates);
}
