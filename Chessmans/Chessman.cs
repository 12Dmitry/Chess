namespace Chess.Chessmans;
public enum ChessmanName { Nun = 0, Pawn = 1, Horse = 3, Bishop = 4, Rook = 5, Queen = 9, King = 111 }; // TODO: мб можно через кодировку залать фигуры King = '\u2654'

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
