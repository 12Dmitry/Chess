namespace Chess.Chessmans;

public class King : Chessman
{
    public bool HasMove { get; private set; }
    public bool HasCastling { get; private set; } // мб эт не нужно совсем
    public King(bool isWhite, Point position) : base(ChessmanName.King, isWhite, position)
    {
        HasMove = false;
        HasCastling = false;
    }

    public bool Castling(Point initial, Point final)
    {
        Chessman chessman = Board.DeterminateChessman(final);
        return !HasMove && chessman.Name == ChessmanName.Rook && !((Rook)chessman).HasMove; // если будет возникать ошибка приведения, то можно через is\as 
    }

    // public bool DeclareCheck(Point final) {}

    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = Math.Abs(final.X - initial.X) <= 1 || Math.Abs(final.Y - initial.Y) <= 1
            || Castling(initial, final);
        if (valid)
            HasMove = true;
        return valid;
    }
}
