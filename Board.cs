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
                    Board[i, j] = new ClassBoard(new Nun(new Point (i+1, j+1)), Convert.ToBoolean((i + j) % 2));
        }

        public static Chessman DeterminateChessman(Point position)
        {
            return Board[position.GetX - 1, position.GetY - 1].GetChessman; 
        }

        public static void AddMoveToBoard(Point initial, Point final)
        {
            Board[final.GetX - 1, final.GetY - 1].Chessman = Board[initial.GetX - 1, initial.GetY - 1].Chessman;
            Board[initial.GetX - 1, initial.GetY - 1].Chessman = new Nun(initial);

            ListChessmen.UpdateChessmen(initial, final);
            PrintBoard();
        }


        public static void AddToBoard(Chessman chessman)
        {
            Board[chessman.Position.GetX -1, chessman.Position.GetY -1].Chessman = chessman;

            PrintBoard();
        }

        public static void PrintBoard() 
        {
            Console.Clear(); // TODO: переместить это в отдельный метод
            string black = "'";
            StringBuilder sb = new StringBuilder(); // создаем объект StringBuilder
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {  // TODO: Будет удачнее черные раскрасить в красный и оставить опострофы только для клеток
                    // если фигура или клетка черная, то добавляем знак " ' "
                    if (!Board[j, i].IsWhite)
                    {
                        if (Board[j, i].GetChessman.Name != ChessmanName.Nun && Board[j, i].GetChessman.IsWhite)
                            sb.Append((int)(Board[j, i].Chessman.Name) + "\t");
                        else
                            sb.Append((int)(Board[j, i].Chessman.Name) + black + "\t");
                    }
                    else // иначе добавляем без знака
                    {
                        if (Board[j, i].GetChessman.Name != ChessmanName.Nun && !Board[j, i].GetChessman.IsWhite)
                            sb.Append((int)(Board[j, i].Chessman.Name) + black + "\t");
                        else
                            sb.Append((int)(Board[j, i].Chessman.Name) + "\t");
                    }
                }
                sb.AppendLine(); 
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.Append('A' + "\t" + 'B' + "\t" + 'C' + "\t" + 'D' + "\t" + 'E' + "\t" + 'F' + "\t" + 'G' + "\t" + 'H');
            sb.AppendLine();
            sb.AppendLine();
            Console.Write(sb.ToString()); 
        }
    }
}
