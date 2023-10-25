namespace Chess.Chessmans;

public class Rook : Chessman
{
    public bool HasMove { get; set; }
    public Rook(bool isWhite, Point position) : base(ChessmanName.Rook, isWhite, position)
    {
        HasMove = false;
    }
    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = MoveLogic.CheckVerticalMove(initial, final) || MoveLogic.CheckHorizontalMove(initial, final);
        if (valid)
            HasMove = true;
        return valid;
    }
}
