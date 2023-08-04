﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MoveLogic
    //TODO: у меня доска перевернута, такчто скорее всего логику, где y y нужно будет писать учитывая это
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
            Chessman chessman = ClassBoard.DeterminateChessman(initial); 
            if (chessman.Name == ChessmanName.Nun)
                throw new ArgumentException("No chessman in this coordinate");
            if (!chessman.VerifyMove(initial, final)) //&& !Cut(chessman, ListChessmen.FindChessmanToPosition(final)))
                throw new ArgumentException("Impossible move"); // it is't argument exep
            
            return true;
        }

        public bool DeclareCheck(Chessman chessman, Point final) 
        {
            if (chessman.VerifyMove(final, ListChessmen.FindOneCopyChessmanToName(ChessmanName.King, !chessman.IsWhite).Position))
                return true;
            return false;
        }


        public static bool IsDiagonalMove(Point initial, Point final)
        {
            if (Math.Abs(final.GetX - initial.GetX) == Math.Abs(final.GetY - initial.GetY))
            {
                int dx = final.GetX > initial.GetX ? 1 : -1; // 1 вправо, -1 влево
                int dy = final.GetY > initial.GetY ? 1 : -1; // 1 вверх, -1 вниз

                int x = initial.GetX + dx;
                int y = initial.GetY + dy;

                while (x != final.GetX && y != final.GetY)
                {
                    if (ClassBoard.DeterminateChessman(new Point(x, y)) != null)
                        return false;
                    x+= dx;
                    y+= dy;
                }
            }
            return true;
        }

        public static bool IsVerticalMove(Point initial, Point final)
        {
            if (initial.GetX == final.GetX && initial.GetY != final.GetY)
            {
                int minY = Math.Min(initial.GetY, final.GetY);
                int maxY = Math.Max(initial.GetY, final.GetY);

                for (int y = minY + 1; y < maxY; y++)
                    if (ListChessmen.FindChessmanToPosition(new Point(final.GetX, y)) != null)
                        return false;
            }
            return true;
        }

        public static bool IsHorizontalMove(Point initial, Point final)
        {
            if (initial.GetY == final.GetY && initial.GetX != final.GetX)
            {
                int minX = Math.Min(initial.GetX, final.GetX);
                int maxX = Math.Max(initial.GetX, final.GetX);

                for (int x = minX + 1; x < maxX; x++)
                    if (ListChessmen.FindChessmanToPosition(new Point(x, final.GetY)) != null)
                        return false;
            }
            return true;
        }

    }
}
