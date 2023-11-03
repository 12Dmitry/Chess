using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Board
{
    public const int Size = 8;

    public static Square[,] board = new Square[Size, Size]; // TODO : вроде как использовать статическое полу не самая хорошая идея 

    public static void MakeBoard()
    {
        for (int y = 0; y < Size; y++)
            for (int x = 0; x < Size; x++)
                board[y, x] = new Square(new Nun(new Point(x + 1, y + 1)), Convert.ToBoolean((y + x) % 2));
    }

    public static IChessman DeterminateChessman(Point position) // TODO :помоему это не тут должно быть
    {
        return board[position.X - 1, position.Y - 1].Chessman;
    }

    public static void AddMoveToBoard(Point initial, Point final) // TODO : мб назвать SetChessmanAt
    {
        board[final.X - 1, final.Y - 1].Chessman = board[initial.X - 1, initial.Y - 1].Chessman;
        board[initial.X - 1, initial.Y - 1].Chessman = new Nun(initial);

        ConsolePrinterBoard.Print();
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
