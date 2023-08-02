using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Move
    {
        private static bool IsCheckmate { get; set; }
        public static void MakeMove() //TODO: рАазвести вывод и ввод и логику про это было гдето в ulearn
        {
            Console.WriteLine("If you wont exit write: ILOOSE");
            Console.WriteLine("First coordinates: ");
            Point initial = ArringeCoordinates(Console.ReadLine());
            Console.WriteLine("Second coordinates: ");
            Point final = ArringeCoordinates(Console.ReadLine());
            if (MoveLogic.MakeMoveLogic(initial, final))
                ClassBoard.AddToBoard(initial, final);
            else
            {
                Console.WriteLine("Wrong move");
                MakeMove();
            }
        }

        public static Point ArringeCoordinates(string coordinates)
        {
            if (coordinates.Length == 2)
            {
                if (Characters.CharToInt.ContainsKey(coordinates[0]) && int.TryParse(coordinates[1].ToString(), out int y))
                    return new Point(Characters.CharToInt[coordinates[0]], y);
            }
            else if (coordinates == "ILOOSE")
            {
                GiveUp();
                return new Point(1, 1);
            }
            throw new ArgumentException("That not convert to int or has the wrong entry");
        }

        private static void GiveUp()
        {
            IsCheckmate = true; 
        }

        public static bool GetIsCheckmate 
        {
            get { return IsCheckmate; }
        }
    }
}
