using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Move
{
    public (Point initial, Point final) Сoordinates { get; private set; }

    public Move((Point initial, Point final) coordinates)
    {
        Сoordinates = coordinates;
    }

    public void VerifyMove()
    {
        IChessman chessman = Game.Board.DeterminateChessman(Сoordinates.initial);
        if (Game.Board.DeterminateChessman(Сoordinates.initial).IsWhite != Game.CurrentPlayerIsWhite)
            throw new InvalidOperationException("You can't move this chessman");
        if (chessman.Name == ChessmanName.Nun)
            throw new InvalidOperationException("No chessman in this coordinate");
        if (!chessman.VerifyMove(Сoordinates))
            throw new InvalidOperationException("Impossible move");
        if (!Cut(chessman, Game.Board.DeterminateChessman(Сoordinates.final)))
            throw new InvalidOperationException("Impossible cut");
    }

    public void ExecuteMove() => Game.Board.MoveChessman(Сoordinates); // QUIZ ??

    public void UndoMove() { } // TODO перенести и сделать

    public static bool Cut(IChessman initial, IChessman final)
    {
        if (final.Name != ChessmanName.Nun && final.IsWhite != initial.IsWhite || final.Name == ChessmanName.Nun)
            return true;
        return false;
    }

    public bool CheckDiagonalMove()
    {
        if (Math.Abs(Сoordinates.final.X - Сoordinates.initial.X) == Math.Abs(Сoordinates.final.Y - Сoordinates.initial.Y))
        {
            int dx = Сoordinates.final.X > Сoordinates.initial.X ? 1 : -1; // 1 вправо, -1 влево
            int dy = Сoordinates.final.Y > Сoordinates.initial.Y ? 1 : -1; // 1 вверх, -1 вниз

            int x = Сoordinates.initial.X + dx;
            int y = Сoordinates.initial.Y + dy;

            while (x != Сoordinates.final.X && y != Сoordinates.final.Y)
            {
                if (Game.Board.DeterminateChessman(new Point(x, y)).Name != ChessmanName.Nun)
                    return false;
                x += dx;
                y += dy;
            }
            return true;
        }
        return false;
    }

    public bool CheckVerticalMove()
    {
        if (Сoordinates.initial.X == Сoordinates.final.X && Сoordinates.initial.Y != Сoordinates.final.Y)
        {
            int minY = Math.Min(Сoordinates.initial.Y, Сoordinates.final.Y);
            int maxY = Math.Max(Сoordinates.initial.Y, Сoordinates.final.Y);

            for (int y = minY + 1; y < maxY; y++)
                if (Game.Board.DeterminateChessman(new Point(Сoordinates.final.X, y)).Name != ChessmanName.Nun)
                    return false;

            return true;
        }
        return false;
    }

    public bool CheckHorizontalMove()
    {
        if (Сoordinates.initial.Y == Сoordinates.final.Y && Сoordinates.initial.X != Сoordinates.final.X)
        {
            int minX = Math.Min(Сoordinates.initial.X, Сoordinates.final.X);
            int maxX = Math.Max(Сoordinates.initial.X, Сoordinates.final.X);

            for (int x = minX + 1; x < maxX; x++)
                if (Game.Board.DeterminateChessman(new Point(x, Сoordinates.final.Y)).Name != ChessmanName.Nun)
                    return false;
            return true;
        }
        return false;
    }
}
