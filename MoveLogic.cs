using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MoveLogic
    //TODO: у меня доска перевернута, такчто скорее всего логику, где x y нужно будет писать учитывая это
    {
        //TODO: проверить что в initial, проверить как это может дваигаться на board,
        //проверить можно ли это поставить в final
        public static bool MakeMoveLogic(Point initial, Point final)
        {
            Chessman chessman = DeterminateChessman(initial); //TODO: Chessman figure = GetFigure(x1, y1); // получаем фигуру по координатам
            //bool valid = figure.VerifyMove(x1, y1, x2, y2); // проверяем ход для этой фигуры
            if (chessman.Name == ChessmanName.Nun)
                throw new ArgumentException("No chessman in this coordinate");
            if (!chessman.VerifyMove(initial, final) || !Cut(chessman, DeterminateChessman(final)))
                throw new ArgumentException("Impossible move");
            return true;
        }

        public static Chessman DeterminateChessman(Point coordinate)
        {
            return ClassBoard.Board[coordinate.GetX, coordinate.GetY].GetChessman();
        }

        private static bool Cut(Chessman initial, Chessman final)
        {
            if (final.Name != ChessmanName.Nun || final.IsWhite != initial.IsWhite)
                return true;
            return false;
        }
    }
}
