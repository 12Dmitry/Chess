namespace Chess.Chessmans;

public class Nun : Chessman
{
    public Nun(Point position) : base(ChessmanName.Nun, false, position) { }

    public override bool VerifyMove(Point initial, Point final)
    {
        return false;
    }
}
