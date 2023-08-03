using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ListChessmen
    {
        public static  List<Chessman> Chessmen = new List<Chessman>();

        public static void AddChessman(Chessman chessman)
        {
                //throw new ArgumentException("There is already a piece at this position");
                Chessmen.Add(chessman);
                ClassBoard.AddToBoard(chessman); //TODO: реализовать по другому, это нада сделать так чтобы сначало заполнять list, а потом добавлять на доску
        }

        public static Chessman FindChessmanToName(ChessmanName name, bool isWhite)
        {
            return Chessmen.Find(c => c.Name == name && c.IsWhite == isWhite);
        }

        public static Chessman FindChessmanToPosition(Point position)
        {
            return Chessmen.Find(c => c.Position == position);
        }

        public static void UpdateChessmen(Point initial, Point final)
        {
            Chessman finalChessman = FindChessmanToPosition(final);
            if (finalChessman != null)
                Chessmen.Remove(finalChessman);
            FindChessmanToPosition(initial).Position = final;
        }


    }
}
