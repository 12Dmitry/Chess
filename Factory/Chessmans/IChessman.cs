namespace Chess.Factory.Factory.Chessmans;

public interface IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; }
    public Point Position { get; set; }

    //public Imagine imagine { get; set; }

    bool VerifyMove(Point initial, Point final);

    // Переопределение метода ToString
    /*public override string ToString()
    {
        return $"Chessmen: Name = {Name}, IsWhite = {IsWhite}, Valid = {Valid}";
    }*/
}
