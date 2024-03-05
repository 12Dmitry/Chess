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
        HasCastling = false; 
    }

    public bool Castling((Point initial, Point final)coordinates)
    {
        IChessman chessman = Game.Board.DeterminateChessman(coordinates.final);
        return !HasMove && chessman.Name == ChessmanName.Rook && !((Rook)chessman).HasMove; //TODO можно через is\as 
    }

    public bool VerifyMove((Point initial, Point final) coordinates)
    {
        bool valid = Math.Abs(coordinates.final.X - coordinates.initial.X) <= 1
            || Math.Abs(coordinates.final.Y - coordinates.initial.Y) <= 1
            || Castling(coordinates);
        if (valid)
            HasMove = true;
        return valid;
    }
}
