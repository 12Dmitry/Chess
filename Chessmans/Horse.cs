namespace Chess.Chessmans;

public class Horse : Chessman
{
    public Horse(bool isWhite, Point position) : base(ChessmanName.Horse, isWhite, position) { }

    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = (Math.Abs(initial.X - final.X) == 1 || Math.Abs(initial.Y - final.Y) == 2)
        && (Math.Abs(initial.X - final.X) == 2 || Math.Abs(initial.Y - final.Y) == 1) ;
        return valid;
    }
}
