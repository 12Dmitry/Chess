using Chess.Chessmans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess;

public class ConsolePrinterBoard
{
    public static void Print() 
    {
        Console.Clear(); // TODO: переместить это в отдельный метод?
        string blackSquare = "'";
        string blackChessman = ".";
        StringBuilder board = new StringBuilder();
        for (int i = 7; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {  
               // если фигура ч то "." ;клетка черная, то знак " ' "
                if (!Board.board[j, i].IsWhite)
                {
                    if (Board.board[j, i].Chessman.Name != ChessmanName.Nun && !Board.board[j, i].Chessman.IsWhite)
                        board.Append((int)(Board.board[j, i].Chessman.Name) + blackChessman + blackSquare + "\t");
                    else
                        board.Append((int)(Board.board[j, i].Chessman.Name) + blackSquare + "\t");
                }
                else // иначе добавляем без знака
                {
                    if (Board.board[j, i].Chessman.Name != ChessmanName.Nun && !Board.board[j, i].Chessman.IsWhite)
                        board.Append((int)(Board.board[j, i].Chessman.Name) + blackChessman + "\t");
                    else
                        board.Append((int)(Board.board[j, i].Chessman.Name) + "\t");
                }
            }
            board.AppendLine();
            board.AppendLine();
        }
        board.AppendLine();
        board.Append('A' + "\t" + 'B' + "\t" + 'C' + "\t" + 'D' + "\t" + 'E' + "\t" + 'F' + "\t" + 'G' + "\t" + 'H');
        board.AppendLine();
        board.AppendLine();
        board.AppendLine();
        Console.Write(board.ToString());
    }
}
