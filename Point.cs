using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess;

public class Point
{
    public int X { get; private set; }
    public int Y { get; private set; } 

    public Point (int x , int y)
    {
        if (x < 1 || x > 8)
            throw new ArgumentException("x must be between 1 and 8");
        else
            X = x;
        if (y < 1 || y > 8)
            throw new ArgumentException("y must be between 1 and 8");
        else
            Y = y;
    }

    public static Point ArringeCoordinates(string coordinates) // TODO наверное есть смысл вынести это в класс Caracters и переименновать его
    {
        MessagesForPlayer error = new MessagesForPlayer();
        if (coordinates.Length == 2)
            if (Characters.CharToInt.ContainsKey(coordinates[0]) && int.TryParse(coordinates[1].ToString(), out int y))
                return new Point(Characters.CharToInt[coordinates[0]], y);
        error.Error("That not convert to int or has the wrong entry");
        return new Point(1, 1);
    }
}
