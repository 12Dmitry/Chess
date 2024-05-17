namespace Chess;

public class Point // TODO: Сделать это структурой
{
    public int X { get; private set; }
    public int Y { get; private set; } 

    public Point (int x , int y)
    {
        if (x is < 1 or > 8)
            throw new ArgumentException("x must be between 1 and 8: " + x);
        else
            X = x;
        if (y is < 1 or > 8)
            throw new ArgumentException("y must be between 1 and 8: " + y);
        else
            Y = y;
    }

    public static Point ArringeCoordinates(string coordinates) 
    {
        if (coordinates.Length == 2)
            if (Characters.CharToInt.ContainsKey(coordinates[0]) && int.TryParse(coordinates[1].ToString(), out int y))
                return new Point(Characters.CharToInt[coordinates[0]], y);
        throw new InvalidOperationException("That not convert to int or has the wrong entry");
    }
}
