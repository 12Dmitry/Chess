using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ClassBoard
    {
        public static double[,] Board = new double[8, 8];
        public static void MakeBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Board[i, j] = (double)((i + j) % 2) / 10.0;
        }

        public static void AddToBoard(Point position, Chessman chessman)
        {
            Board[position.GetX -1, position.GetY -1] += (int)chessman;
            PrintBoard();
        }

        public static void PrintBoard()
        {
            Console.Clear(); // TODO: переместить это в отдельный метод
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(Board[j, i] + "\t"); //TODO: у меня доска перевернута, такчто скорее всего логику, где x y нужно будет писать учитывая это
                Console.WriteLine();
            }
        }
    }
}
