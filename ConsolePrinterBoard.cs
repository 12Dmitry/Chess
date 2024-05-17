﻿using System.Text;

namespace Chess;

public class ConsolePrinterBoard
{
    public static void Print()
    {
        Console.Clear(); // QUIZ: переместить это в отдельный метод?
               
        Console.WindowWidth = 120;
        Console.WindowHeight = 39;
        Console.BufferWidth = 120;
        Console.BufferHeight = 220; // Установка высоты буфера консоли
        
        const string separator = "-------";
        const string blackSpace = "#######";
        const string blackLine = "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|";
        const string whiteLine = "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|";
        const string separatorLine = "|" + separator + "|" + separator + "|" + separator + "|" + separator + "|" + separator + "|" + separator + "|" + separator + "|" + separator + "| ";
        const string blackSquare = " ###";
        Func<char, char> blackChessman = Char.ToLower;
        var board = new StringBuilder();
        board.AppendLine("\n" + separatorLine);
        for (int i = Board.Size -1; i >= 0; i--) // HACK !доска должна быть перевернута, иначе будут перевернуты координаты! + условие для чкрных фигур контринтуитивно!!
        {
            for (int j = 0; j < Board.Size; j++)
            {
                board.Append('|');
                if (!Game.Board.ChessBoard[j, i].IsWhite) 
                {
                    if (Game.Board.ChessBoard[j, i].Chessman.Name != ChessmanName.Nun && !Game.Board.ChessBoard[j, i].Chessman.IsWhite)
                        board.Append(blackChessman((char)(Game.Board.ChessBoard[j, i].Chessman.Name)) + blackSquare + "\t");
                    else
                        board.Append((char)(Game.Board.ChessBoard[j, i].Chessman.Name) + blackSquare + "\t");
                }
                else // иначе добавляем без знака
                {
                    if (Game.Board.ChessBoard[j, i].Chessman.Name != ChessmanName.Nun && !Game.Board.ChessBoard[j, i].Chessman.IsWhite)
                        board.Append(blackChessman((char)(Game.Board.ChessBoard[j, i].Chessman.Name)) + "\t");
                    else
                        board.Append((char)(Game.Board.ChessBoard[j, i].Chessman.Name) + "\t");
                }
            }
            board.Append('|');
            board.Append('\n');
            string line = (i % 2 == 0) ? blackLine : whiteLine;
            board.AppendLine(line);
            board.AppendLine(separatorLine + (1 + i));
        }

        board.Append('A' + "\t" + 'B' + "\t" + 'C' + "\t" + 'D' + "\t" + 'E' + "\t" + 'F' + "\t" + 'G' + "\t" + 'H');
        board.AppendLine();
        board.AppendLine();
        board.AppendLine();
        Console.Write(board.ToString());
    }
}
