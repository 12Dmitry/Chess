using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Chessmans;

namespace Chess;

public class Board
{
    public const int Size = 8;

    public static Square[,] board = new Square[Size, Size];

    public static void MakeBoard()
    {
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                board[i, j] = new Square(new Nun(new Point(i + 1, j + 1)), Convert.ToBoolean((i + j) % 2));
    }

    public static Chessman DeterminateChessman(Point position) // TODO :помоему это не тут должно быть
    {
        return board[position.X - 1, position.Y - 1].Chessman;
    }

    public static void AddMoveToBoard(Point initial, Point final) 
    {
        board[final.X - 1, final.Y - 1].Chessman = board[initial.X - 1, initial.Y - 1].Chessman;
        board[initial.X - 1, initial.Y - 1].Chessman = new Nun(initial);

        ConsolePrinterBoard.Print();
    }


    public static void AddToBoard(Chessman chessman) // TODO : пееределать
    {
        board[chessman.Position.X - 1, chessman.Position.Y - 1].Chessman = chessman;

        ConsolePrinterBoard.Print();
    }

    public static void AddChessman(Chessman chessman) 
    {

        AddToBoard(chessman);
    }

    private static void SetChessmanAt(Point point, Chessman chessman)
    {

    }

    //public static Chessman FindOneCopyChessmanToName(ChessmanName name, bool isWhite) //этотработать будет только для фигур в одном экз(но по идее этот метод нужен только для короля) 
    //{
    //    return Chessmen.Find(c => c.Name == name && c.IsWhite == isWhite)!;
    //}
}
