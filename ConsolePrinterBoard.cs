using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess;

public class ConsolePrinterBoard
{
    public static void Print() // HACK :!!! Я МЕНЯЮ ФИГУРЫ!!! ЧЕРНЫЕ СТАЛИ БЕЛЫМИ!!!! МБ ПОТОМ ЭТО ИСПРАВИТЬ... (пока влияет только на метод Pawn.VerifyMove) но по моему так быть не должно
    {
        Console.Clear(); // TODO: переместить это в отдельный метод?
               
        string sepporator = "-------";
        string blackSpace = "#######";
        string blackLine = "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|";
        string whiteLine = "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|";
        string seporatorLine = "|" + sepporator + "|" + sepporator + "|" + sepporator + "|" + sepporator + "|" + sepporator + "|" + sepporator + "|" + sepporator + "|" + sepporator + "| ";
        string blackSquare = " ###";
        string blackChessman = "'";
        // QUIZ : мне нужно чтобы я мог конвертировать эти символы во что захочу, не только char
        var board = new StringBuilder();
        board.AppendLine("\n" + seporatorLine);
        for (int i = Board.Size -1; i >= 0; i--) // HACK !доска должна быть перевернута, иначе будут перевернуты координаты! + условие для чкрных фигур контринтуитивно!!
        {
            for (int j = 0; j < Board.Size; j++)
            {
                board.Append('|');
                if (!Board.board[j, i].IsWhite) 
                {
                    if (Board.board[j, i].Chessman.Name != ChessmanName.Nun && !Board.board[j, i].Chessman.IsWhite)
                        board.Append((char)(Board.board[j, i].Chessman.Name) + blackChessman + blackSquare + "\t");
                    else
                        board.Append((char)(Board.board[j, i].Chessman.Name) + blackSquare + "\t");
                }
                else // иначе добавляем без знака
                {
                    if (Board.board[j, i].Chessman.Name != ChessmanName.Nun && !Board.board[j, i].Chessman.IsWhite)
                        board.Append((char)(Board.board[j, i].Chessman.Name) + blackChessman + "\t");
                    else
                        board.Append((char)(Board.board[j, i].Chessman.Name) + "\t");
                }
            }
            board.Append('|');
            board.Append("\n");
            string line = (i % 2 == 0) ? blackLine : whiteLine;
            board.AppendLine(line);
            board.AppendLine(seporatorLine + (1 + i));
        }

        board.AppendLine();
        board.Append('A' + "\t" + 'B' + "\t" + 'C' + "\t" + 'D' + "\t" + 'E' + "\t" + 'F' + "\t" + 'G' + "\t" + 'H');
        board.AppendLine();
        board.AppendLine();
        board.AppendLine();
        Console.Write(board.ToString());
    }
}
