using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Move
    {
        public void MakeMove() //TODO: рАазвести вывод и ввод и логику про это было гдето в ulearn
        {
            Console.WriteLine("Plauer1 move");
            Console.WriteLine("First coordinates: ");
            Point initial = ArringeCoordinates(Console.ReadLine());
            Console.WriteLine("Second coordinates: ");
            Point final = ArringeCoordinates(Console.ReadLine());
            if (MoveLogic.MakeMoveLogic(initial, final));
                
        }

        public Point ArringeCoordinates(string coordinates)
        {
            if (coordinates.Length == 2)
                if (Characters.CharToInt.ContainsKey(coordinates[0]) && int.TryParse(coordinates[1].ToString(), out int y))
                    return new Point( Characters.CharToInt[coordinates[0]], y );
            throw new ArgumentException("That not convert to int or has the wrong entry");
        }
    }
}
