using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Chessmans;

namespace Chess;

public class MoveLogic
{
    public static bool VerifyMoveLogic(Point initial, Point final)
    {
        MessagesForPlayer error = new MessagesForPlayer();
        Chessman chessman = Board.DeterminateChessman(initial);
        if (chessman.Name == ChessmanName.Nun)
        {
            error.Error("No chessman in this coordinate");
            return false;
        }
        if (!chessman.VerifyMove(initial, final)) 
        {
            error.Error("Impossible move");
            return false;
        }
        if (!Cut(chessman, Board.DeterminateChessman(final)))
        {
            error.Error("Impossible cut");
            return false;
        }
        return true;
    }

    //public bool DeclareCheck(Chessman chessman, Point final) // TODO наверное это должно быть как состояние.. чтобы это не значило
    //{
    //    if (chessman.VerifyMove(final, Board.FindOneCopyChessmanToName(ChessmanName.King, !chessman.IsWhite).Position))
    //        return true;
    //    return false;
    //}


    public static bool CheckDiagonalMove(Point initial, Point final)
    {
        if (Math.Abs(final.X - initial.X) == Math.Abs(final.Y - initial.Y))
        {
            int dx = final.X > initial.X ? 1 : -1; // 1 вправо, -1 влево
            int dy = final.Y > initial.Y ? 1 : -1; // 1 вверх, -1 вниз

            int x = initial.X + dx;
            int y = initial.Y + dy;

            while (x != final.X && y != final.Y)
            {
                if (Board.DeterminateChessman(new Point(x, y)).Name != ChessmanName.Nun)
                    return false;
                x += dx;
                y += dy;
            }
            return true;
        }
        return false;
    }

    public static bool CheckVerticalMove(Point initial, Point final)
    {
        if (initial.X == final.X && initial.Y != final.Y)
        {
            int minY = Math.Min(initial.Y, final.Y);
            int maxY = Math.Max(initial.Y, final.Y);

            for (int y = minY + 1; y < maxY; y++)
                if (Board.DeterminateChessman(new Point(final.X, y)).Name != ChessmanName.Nun)
                    return false;

            return true;
        }
        return false;
    }

    public static bool CheckHorizontalMove(Point initial, Point final)
    {
        if (initial.Y == final.Y && initial.X != final.X)
        {
            int minX = Math.Min(initial.X, final.X);
            int maxX = Math.Max(initial.X, final.X);

            for (int x = minX + 1; x < maxX; x++)
                if (Board.DeterminateChessman(new Point(x, final.Y)).Name != ChessmanName.Nun)
                    return false;
            return true;
        }
        return false;
    }

    private static bool Cut(Chessman initial, Chessman final)
    {
        if (final.Name != ChessmanName.Nun && final.IsWhite != initial.IsWhite || final.Name == ChessmanName.Nun)
            return true;
        return false;
    }
}
