namespace Chess.Factory.Factory.Chessmans;

public class Queen : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }

    public Queen(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
    }

    public bool VerifyMove(Point initial, Point final)
    {
        bool valid = MoveLogic.CheckDiagonalMove(initial, final) ||
            MoveLogic.CheckVerticalMove(initial, final) || MoveLogic.CheckHorizontalMove(initial, final);
        return valid;
    }
}
