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

    public static void Error(string errorDescription) // TODO^ иожно засунуть Action action вместо метода
    {
        Console.SetCursorPosition(0, 31);
        Console.WriteLine(errorDescription + "                              ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
        Console.WriteLine("                              ");
        Console.SetCursorPosition(0, 32); 
        Move.VerifyMove(MessagesForPlayer.GetCoordinates());
    }

    public static char GetChessman()
    {
        Console.Write("Choose chessman: ");
        char chessman = Char.ToUpper((char)Console.Read());
        if (chessman == 'Q' || chessman == 'R' || chessman == 'B' || chessman == 'N')
            return chessman;
        else return GetChessman();
    }
}
