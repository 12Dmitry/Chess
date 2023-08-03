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
        private static bool Cut(Chessman initial, Chessman final)
        {
            if (final.Name != ChessmanName.Nun || final.IsWhite != initial.IsWhite)
                return true;
            return false;
        }

        public static bool MakeMoveLogic(Point initial, Point final)
        {
            Chessman chessman = DeterminateChessman(initial); 
            if (chessman.Name == ChessmanName.Nun)
                throw new ArgumentException("No chessman in this coordinate");
            if (!chessman.VerifyMove(initial, final) && !Cut(chessman, DeterminateChessman(final)))
                throw new ArgumentException("Impossible move"); // it is't argument exep
            if (chessman.Bighop)
            return true;
        }

        public static Chessman DeterminateChessman(Point coordinate)
        {
            return ClassBoard.Board[coordinate.GetX -1, coordinate.GetY -1].GetChessman; //TODO: обработать искл System.IndexOutOfRangeException:  
        }

        public bool DeclareCheck(Chessman chessman, Point final) 
        {
            if (chessman.VerifyMove(final, ListChessmen.FindChessmanToName(ChessmanName.King, !chessman.IsWhite).Position))
                return true;
            return false;
        }


        protected bool IsDiagonalMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            return Math.Abs(destColumn - sourceColumn) == Math.Abs(destRow - sourceRow);
        }

        protected bool IsVerticalMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            return sourceColumn == destColumn && sourceRow != destRow;
        }

        protected bool IsHorizontalMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            return sourceRow == destRow && sourceColumn != destColumn;
        }

    }
}
