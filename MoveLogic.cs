using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MoveLogic
    {
        //TODO: проверить что в initial, проверить как это может дваигаться на board,
        //проверить можно ли это поставить в final
        public void MakeMoveLogic(Point initial, Point final)
        {
            Chessman chessman = DeterminateChessman(initial);


        }

        public Chessman DeterminateChessman(Point coordinate)
        {
            int chessman = (int)ClassBoard.Board[coordinate.GetX, coordinate.GetY];
            if (chessman < 1 || chessman > 8)
                throw new ArgumentException("No chessman in this coordinate");
            return (Chessman)chessman;
        }
        public bool PownCheckMuve(Point initial, Point final)
        

        public bool HorseCheckMoov(Point initial, Point final)
        {
            if ((Math.Abs(initial.GetX - final.GetX) == 1 && Math.Abs(initial.GetY - final.GetY) == 2) 
            || (Math.Abs(initial.GetX - final.GetX) == 2 && Math.Abs(initial.GetY - final.GetY) == 1))
                return true;
            else return false;
        }

        public bool BishopCheckMoov(Point initial, Point final)
        {
            if (Math.Abs(initial.GetX - final.GetX) == Math.Abs(initial.GetY - final.GetY))
                return true;
            else return false;
        }

        public bool RookCheckMoov(Point initial, Point final)
        {
            if (initial.GetX == final.GetX || initial.GetY == final.GetY)
                return true;
            else return false;
        }

        public bool QueenCheckMoove(Point initial, Point final)
        {
            if (initial.GetX == final.GetX || initial.GetY == final.GetY 
                || Math.Abs(initial.GetX - final.GetX) == Math.Abs(initial.GetY - final.GetY))
                return true;
            else return false;
        }

        public bool KingCheckMoove(Point initial, Point final)
        {
            if ((initial.GetX == final.GetX || initial.GetY == final.GetY 
                || Math.Abs(initial.GetX - final.GetX) == Math.Abs(initial.GetY - final.GetY))
                && (initial.GetX + 1 == final.GetX || initial.GetY + 1 == final.GetY))
                return true;
            else return false;
        }

    }
}
