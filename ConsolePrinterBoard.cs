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

        string sepporator = "------";
        string blackSquare = "'";
        string blackChessman = ".";
        // мне нужно чтобы я мог конвертировать эти символы во что захочу, не только в int
        // я думаю сделать вместо (int) переменную в которую могу потожить int или string чтобы в зависимости от ситуации приводить к тому что мне сейчпс нужно
        StringBuilder board = new StringBuilder();
        for (int i = Board.Size - 1; i >= 0; i--)
        {
            for (int j = 0; j < Board.Size; j++)
            {
                // если фигура ч то "." ;клетка черная, то знак " ' "
                if (!Board.board[j, i].IsWhite)
                {
                    if (Board.board[j, i].Chessman.Name != ChessmanName.Nun && !Board.board[j, i].Chessman.IsWhite)
                        board.Append("|" + (char)(Board.board[j, i].Chessman.Name) + blackChessman + blackSquare + "\t" + "|");
                    else
                        board.Append("|" + (char)(Board.board[j, i].Chessman.Name) + blackSquare + "\t" + "|");
                }
                else // иначе добавляем без знака
                {
                    if (Board.board[j, i].Chessman.Name != ChessmanName.Nun && !Board.board[j, i].Chessman.IsWhite)
                        board.Append("|" + (char)(Board.board[j, i].Chessman.Name) + blackChessman + "\t" + "|");
                    else
                        board.Append("|" + (char)(Board.board[j, i].Chessman.Name) + "\t" + "|");
                }
            }
            board.Append("\n");
            board.AppendLine("|" +  "\t" + "|" + "|" + "\t" + "|" + "|" + "\t" + "|" + "|" + "\t" + "|" + "|" + "\t" + "|" + "|" + "\t" + "|" + "|" + "\t" + "|" + "|" + "\t" + "|");
            board.AppendLine("|" + sepporator + " |" + "|" + sepporator + "|" + "|" + sepporator + "|" + "|" + sepporator + "|" + "|" + sepporator + "|" + "|" + sepporator + "|" + "|" + sepporator + "|" + "|" + sepporator + " | ");
        }
        board.AppendLine();
        board.Append('A' + "\t" + 'B' + "\t" + 'C' + "\t" + 'D' + "\t" + 'E' + "\t" + 'F' + "\t" + 'G' + "\t" + 'H');
        board.AppendLine();
        board.AppendLine();
        board.AppendLine();
        Console.Write(board.ToString());
    }
}
