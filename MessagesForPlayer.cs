using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess;
public class MessagesForPlayer
{
    public static Point GetCoordinates(string messages)
    {
        Console.WriteLine(messages);
        return Point.ArringeCoordinates(Console.ReadLine()!);
    }

    public void Error(string errorDescription)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 3);
        Console.WriteLine(errorDescription + "           ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
        Move.VerifyMove();
    }
}
