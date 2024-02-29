using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Board
{
    public const int Size = 8; // TODO: мб вынести это в namespace

    public static Square[,] board { get; private set; } = new Square[Size, Size];

    public static void MakeBoard()
    {
        for (int y = 0; y < Size; y++)
            for (int x = 0; x < Size; x++)
                board[y, x] = new Square(new Nun(new Point(x + 1, y + 1)), Convert.ToBoolean((y + x) % 2));
    }

    public static IChessman DeterminateChessman(Point position) // TODO :помоему это не тут должно быть, хз мб выделить зависимый класс в котором логика
    {
        return board[position.X - 1, position.Y - 1].Chessman;
    }

    public static void MoveChessman((Point initial, Point final) coordinates)
    {
        board[coordinates.final.X - 1, coordinates.final.Y - 1].Chessman = board[coordinates.initial.X - 1, coordinates.initial.Y - 1].Chessman;
        board[coordinates.final.X - 1, coordinates.final.Y - 1].Chessman.Position = coordinates.final;
        RemoveChessman(coordinates.initial);

        ConsolePrinterBoard.Print();
    }

    public static void RemoveChessman(Point position)
    {
        board[position.X - 1, position.Y - 1].Chessman = new Nun(position);
    }

    public static void AddChessmansToBoard(List<IChessman> chessmans) 
    {
        foreach (var chessman in chessmans)
        board[chessman.Position.X - 1, chessman.Position.Y - 1].Chessman = chessman;

        ConsolePrinterBoard.Print();
    }

    //public static IChessman FindOneCopyChessmanToName(ChessmanName name, bool isWhite) //этотработать будет только для фигур в одном экз(но по идее этот метод нужен только для короля) 
    //{
    //    return Chessmen.Find(c => c.Name == name && c.IsWhite == isWhite)!;
    //}
}
