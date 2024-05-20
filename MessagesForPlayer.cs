namespace Chess;
public static class MessagesForPlayer
{
    public static void DisplayMoveInfo(bool currentPlayerIsWhite, int moveCount)
    {
        Console.SetCursorPosition(0, 29);
        Console.WriteLine(((currentPlayerIsWhite) ? "White" : "Black") + " player move - " + moveCount + '\n');
    }
    
    public static (Point, Point) GetCoordinates()
    {
        Point initial = GetCoordinate("First coordinates: ");
        Point final = GetCoordinate("Second coordinates: ");
        return (initial, final);
    }

    private static Point GetCoordinate(string messages)
    {
        Console.WriteLine(messages);
        return Point.ArringeCoordinates(Console.ReadLine()!);
    }

    public static bool Restart()
    {
        Console.WriteLine("Do you want restart game?: [Y] yes [N] no");
        var answer = Console.ReadLine();
        if (string.IsNullOrEmpty(answer)) return Restart();
        return (answer[0] == 'y' || answer[0] == 'Y') ? true :
            (answer[0] == 'n' || answer[0] == 'N') ? false : Restart();
    }

    public static void Error(string errorDescription)
    {
        Console.SetCursorPosition(0, 30);
        Console.WriteLine(errorDescription + "                              ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
    }

    public static char GetChessman()
    {
        Console.Write("Choose chessman: ");
        char chessman = Char.ToUpper((char)Console.Read());
        if (chessman == 'Q' || chessman == 'R' || chessman == 'B' || chessman == 'N')
            return chessman;
        else
        {
            Console.Write("'\n'Q/R/B/N");
            return GetChessman();
        }
    }
}
