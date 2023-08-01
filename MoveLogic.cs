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
        public void MakeMoveLogic(Point initial, Point final)
        {
            ChessmanName chessman = DeterminateChessman(initial); //TODO: Chessman figure = GetFigure(x1, y1); // получаем фигуру по координатам
            //bool valid = figure.VerifyMove(x1, y1, x2, y2); // проверяем ход для этой фигуры
            if (chessman == ChessmanName.Nun)
                throw new ArgumentException("No chessman in this coordinate");


        }

        public ChessmanName DeterminateChessman(Point coordinate)
        {
            int chessman = (int)ClassBoard.Board[coordinate.GetX, coordinate.GetY];
            if (chessman < 1 || chessman > 8)
                return ChessmanName.Nun;
            return (ChessmanName)chessman;
        }
        


    }
}
