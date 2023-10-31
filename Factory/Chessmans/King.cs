namespace Chess.Factory.Factory.Chessmans;

public class King : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }
    public bool HasMove { get; private set; }
    public bool HasCastling { get; private set; } // мб эт не нужно совсем
    public King(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
        HasMove = false;
        HasCastling = false; // TODO : мб убрать..
    }

    public bool Castling(Point initial, Point final)
    {
        IChessman chessman = Board.DeterminateChessman(final);
        return !HasMove && chessman.Name == ChessmanName.Rook && !((Rook)chessman).HasMove; // если будет возникать ошибка приведения, то можно через is\as 
    }

    // public bool DeclareCheck(Point final) {}

    public bool VerifyMove(Point initial, Point final)
    {
        bool valid = Math.Abs(final.X - initial.X) <= 1 || Math.Abs(final.Y - initial.Y) <= 1
            || Castling(initial, final);
        if (valid)
            HasMove = true;
        return valid;
    }
}
