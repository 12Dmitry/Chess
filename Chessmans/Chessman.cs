namespace Chess.Chessmans;
public enum ChessmanName { Nun = ' ', Pawn = 'p', Horse = 'N', Bishop = 'B', Rook = 'R', Queen = 'Q', King = 'K' }; // TODO: мб можно через кодировку залать фигуры King = '\u2654' 

public abstract class Chessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }

    //public Imagine imagine { get; set; }

    public Chessman(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
    }

    public abstract bool VerifyMove(Point initial, Point final);

    // Переопределение метода ToString
    /*public override string ToString()
    {
        return $"Chessmen: Name = {Name}, IsWhite = {IsWhite}, Valid = {Valid}";
    }*/
}
