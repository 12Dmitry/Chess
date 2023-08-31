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
            ClassBoard.AddToBoard(FindChessmanToPosition(chessman.Position)); //TODO: сначало заполнять list, а потом добавлять на доску в принципе без разницы
        }

        public static Chessman FindOneCopyChessmanToName(ChessmanName name, bool isWhite) //этотработать будет только для фигур в одном экз(но по идее этот метод нужен только для короля) 
        {
            return Chessmen.Find(c => c.Name == name && c.IsWhite == isWhite);
        }

        public static Chessman FindChessmanToPosition(Point position) // это работать не будет тк здесь тупа ссылки, а может и будет, но это очень долго, нужне алгоритм, наверное/ 
            // Я понял что мне это не нудно потомучто алгоритмцы можно писать и на доске, а тут по факту они ток и нужны, мдээ...
        {
            return Chessmen.Find(c => c.Position == position);
        }

        public static void UpdateChessmen(Point initial, Point final)
        {
            Chessman finalChessman = FindChessmanToPosition(final);
            if (finalChessman?.Name != null) // обращаемся к свойству Name только если finalChessman не равен null
                Chessmen.Remove(finalChessman);
            Chessmen.Remove(finalChessman);
            FindChessmanToPosition(initial).Position = final;
        }


    }
}
