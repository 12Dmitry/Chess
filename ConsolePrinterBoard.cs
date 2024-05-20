using System.Text;

namespace Chess;

public class ConsolePrinterBoard
{
    public static void GPrint()
    {
        Console.Clear(); // QUIZ: переместить это в отдельный метод?

        Console.WindowWidth = 120;
        Console.WindowHeight = 39;
        Console.BufferWidth = 120;
        Console.BufferHeight = 220; // Установка высоты буфера консоли

        const string separator = "-------";
        const string blackSpace = "#######";
        const string blackLine = "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace +
                                 "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|";
        const string whiteLine = "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" +
                                 blackSpace + "|" + "\t" + "|" + blackSpace + "|";
        const string separatorLine = "|" + separator + "|" + separator + "|" + separator + "|" + separator + "|" +
                                     separator + "|" + separator + "|" + separator + "|" + separator + "| ";
        const string blackSquare = " ###";
        Func<char, char> blackChessman = Char.ToLower;
        var board = new StringBuilder();
        board.AppendLine("\n" + separatorLine);
        for (int i = Board.Size - 1;
             i >= 0;
             i--) // HACK !доска должна быть перевернута, иначе будут перевернуты координаты! + условие для чкрных фигур контринтуитивно!!
        {
            for (int j = 0; j < Board.Size; j++)
            {
                board.Append('|');
                var chessman = Game.Board.ChessBoard[j, i].Chessman;
                if (chessman.Name != ChessmanName.Nun)
                {
                    if (!chessman.IsWhite) // Черные фигуры
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        board.Append(blackChessman((char)chessman.Name) + blackSquare + "\t");
                        Console.ResetColor();
                    }
                    else // Белые фигуры
                    {
                        board.Append((char)chessman.Name + "\t");
                    }
                }
                else
                {
                    board.Append(" \t");
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

    public static void Print()
    {
        Console.Clear(); // QUIZ: переместить это в отдельный метод?

        Console.WindowWidth = 120;
        Console.WindowHeight = 39;
        Console.BufferWidth = 120;
        Console.BufferHeight = 220; // Установка высоты буфера консоли

        const string separator = "-------";
        const string blackSpace = "#######";
        const string blackLine = "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace +
                                 "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|";
        const string whiteLine = "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" + blackSpace + "|" + "\t" + "|" +
                                 blackSpace + "|" + "\t" + "|" + blackSpace + "|";
        const string separatorLine = "|" + separator + "|" + separator + "|" + separator + "|" + separator + "|" +
                                     separator + "|" + separator + "|" + separator + "|" + separator + "| ";
        const string blackSquare = " ###";
        Func<char, char> blackChessman = Char.ToLower;

        Console.WriteLine("\n" + separatorLine);
        for (int i = Board.Size - 1;
             i >= 0;
             i--) // HACK !доска должна быть перевернута, иначе будут перевернуты координаты! + условие для черных фигур контринтуитивно!!
        {
            for (int j = 0; j < Board.Size; j++)
            {
                Console.Write('|');
                var chessman = Game.Board.ChessBoard[j, i].Chessman;
                if (chessman.Name != ChessmanName.Nun)
                {
                    if (!chessman.IsWhite) // Черные фигуры
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(blackChessman((char)chessman.Name));
                        Console.ResetColor();
                        Console.Write(blackSquare + "\t");
                    }
                    else // Белые фигуры
                    {
                        Console.Write((char)chessman.Name + "\t");
                    }
                }
                else
                {
                    Console.Write(" \t");
                }
            }

            Console.Write('|');
            Console.Write('\n');
            string line = (i % 2 == 0) ? blackLine : whiteLine;
            Console.WriteLine(line);
            Console.WriteLine(separatorLine + (1 + i));
        }

        Console.WriteLine(
            'A' + "\t" + 'B' + "\t" + 'C' + "\t" + 'D' + "\t" + 'E' + "\t" + 'F' + "\t" + 'G' + "\t" + 'H');
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
}
