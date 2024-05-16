namespace Chess;
public class MessagesForPlayer
{
    public static (Point, Point) GetCoordinates()
    {
        Point initial = GetCoordinate("First coordinates: ");
        Point final = GetCoordinate("Second coordinates: ");
        return (initial, final);
    }

    public static Point GetCoordinate(string messages)
    {
        Console.WriteLine(messages);
        return Point.ArringeCoordinates(Console.ReadLine()!);
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
