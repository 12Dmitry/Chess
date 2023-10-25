namespace Chess.Chessmans;

public class Pawn : Chessman
{
    public bool HasMove { get; private set; }
    public Pawn(bool isWhite, Point position) : base(ChessmanName.Pawn, isWhite, position)
    {
        HasMove = false;
    }

    public bool Cut(Point initial, Point final) // отдельно нужен чтобы проверить шах
    {
        bool hasChessman = (Board.DeterminateChessman(final).Name != ChessmanName.Nun) ? true : false;
        return hasChessman && initial.Y + 1 == final.Y && (initial.X == final.X - 1 || initial.X == final.X + 1);
    }
    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = (initial.X == final.X && initial.Y + 1 == final.Y) || Cut(initial, final) ||
            (MoveLogic.CheckVerticalMove(initial, final) && final.Y == initial.Y + 2 && !HasMove);
        if (valid)
            HasMove = true;
        if (final.Y == 8 && valid) ;
        //MoveLogic.BecomeAnotherChessman();
        return valid;
    }
}
