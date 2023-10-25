namespace Chess.Chessmans;

public class Queen : Chessman
{
    public Queen(bool isWhite, Point position) : base(ChessmanName.Queen, isWhite, position) { }

    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = MoveLogic.CheckDiagonalMove(initial, final) ||
            MoveLogic.CheckVerticalMove(initial, final) || MoveLogic.CheckHorizontalMove(initial, final);
        return valid;
    }
}
