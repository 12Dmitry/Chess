namespace Chess;
public class MessagesForPlayer
{
    public static Point GetCoordinates(string messages)
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
        Move.VerifyMove();
    }

    public static char TransformationPawn()
    {
        Console.Write("Choose chessman: ");
        char chessman = (char)Console.Read();
        if (chessman == 'Q' || chessman == 'q' || chessman == 'R' || chessman == 'r'
            || chessman == 'B' || chessman == 'b' || chessman == 'H' || chessman == 'h')
            return chessman;
        else return TransformationPawn();
    }
}
