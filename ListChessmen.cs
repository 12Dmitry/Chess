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
                ClassBoard.AddToBoard(FindChessmanToPosition(chessman.Position)); //TODO: реализовать по другому, это нада сделать так чтобы сначало заполнять list, а потом добавлять на доску
        }

        public static Chessman FindOneCopyChessmanToName(ChessmanName name, bool isWhite) //этотработать будет только для фигур в одном экз(
        {
            return Chessmen.Find(c => c.Name == name && c.IsWhite == isWhite);
        }

        public static Chessman FindChessmanToPosition(Point position) // это работать не будет тк здесь тупа ссылки.
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
