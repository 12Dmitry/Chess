using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ClassBoard
    {
        private Chessman Chessman { get; set; }
        private bool IsWhite { get; set; }

        public ClassBoard(Chessman chessman, bool white)
        {
            Chessman = chessman;
            IsWhite = white;
        }

        public Chessman GetChessman
        {
            get { return Chessman; }
        }

        public static ClassBoard[,] Board = new ClassBoard[8, 8]; // HACK : !!! координаты смещены на -1 !!! и в коде это выглядит ужасно, как ДОПОЛНИТЕЛЬНАЯ ИНСТРУКЦИЯ ИЗВНЕ!!
        public static void MakeBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Board[i, j] = new ClassBoard(new Nun(), Convert.ToBoolean((i + j) % 2));
        }

        public static void AddToBoard(Point initial, Point final)
        {
            Board[final.GetX - 1, final.GetY - 1].Chessman = Board[initial.GetX - 1, initial.GetY - 1].Chessman;
            Board[initial.GetX - 1, initial.GetY - 1].Chessman = new Nun();
            PrintBoard();
        }


        public static void AddToBoard(Point position, Chessman chessman)
        {
            Board[position.GetX -1, position.GetY -1].Chessman = chessman;
            PrintBoard();
        }

        public static void PrintBoard() // переделать в stringbulder!!!
        {
            Console.Clear(); // TODO: переместить это в отдельный метод
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write((int)(Board[j, i].Chessman.Name) + "\t"); //TODO: у меня доска перевернута, такчто скорее всего логику, где x y нужно будет писать учитывая это хотя хз
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
