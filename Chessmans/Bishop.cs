namespace Chess.Chessmans;

public class Bishop : Chessman
{
    public Bishop(bool isWhite, Point position) : base(ChessmanName.Bishop, isWhite, position) { }
    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = MoveLogic.CheckDiagonalMove(initial, final);
        return valid;
    }
}
