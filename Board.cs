using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ClassBoard
    {
        private Chessman Figure { get; set; }
        private bool IsWhite { get; set; }

        public ClassBoard(Chessman chessman, bool white)
        {
            Figure = chessman;
            IsWhite = white;
        }

        public static ClassBoard[,] Board = new ClassBoard[8, 8];
        public static void MakeBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Board[i, j].IsWhite = Convert.ToBoolean((i + j) % 2);
        }

        public static void AddToBoard(Point position, Chessman chessman)
        {
            Board[position.GetX -1, position.GetY -1].Figure = chessman;
            PrintBoard();
        }

        public static void PrintBoard()
        {
            Console.Clear(); // TODO: переместить это в отдельный метод
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write((string)(Board[j, i].Figure.Name + "\t")); //TODO: у меня доска перевернута, такчто скорее всего логику, где x y нужно будет писать учитывая это
                Console.WriteLine();
            }
        }
    }
}
