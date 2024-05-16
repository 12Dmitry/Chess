using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Move
{
    private (Point initial, Point final) Coordinates { get; }

    public Move((Point initial, Point final) coordinates)
    {
        this.Coordinates = coordinates;
    }

    public void VerifyMove()
    {
        IChessman chessman = Game.Board.DeterminateChessman(Coordinates.initial);
        if (Game.Board.DeterminateChessman(Coordinates.initial).IsWhite != Game.CurrentPlayerIsWhite)
            throw new InvalidOperationException("You can't move this chessman");
        if (chessman.Name == ChessmanName.Nun)
            throw new InvalidOperationException("No chessman in this coordinate");
        if (!chessman.VerifyMove(Coordinates))
            throw new InvalidOperationException("Impossible move");
        if (!Cut(chessman, Game.Board.DeterminateChessman(Coordinates.final)))
            throw new InvalidOperationException("Impossible cut");
    }

    public void ExecuteMove(bool promotePawn = true)
    {
        Game.MoveHistory.Push((Coordinates.initial, Coordinates.final, Game.Board.DeterminateChessman(Coordinates.final)));
        Game.Board.MoveChessman(Coordinates, promotePawn); // QUIZ ??
    }

    public void UndoMove() =>
        Game.Board.MoveBackChessman((Game.MoveHistory.Peek().final, Game.MoveHistory.Peek().initial), Game.MoveHistory.Pop().chessman);

    public static bool Cut(IChessman initial, IChessman final)
    {
        if (final.Name != ChessmanName.Nun && final.IsWhite != initial.IsWhite || final.Name == ChessmanName.Nun)
            return true;
        return false;
    }

    public bool CheckDiagonalMove()
    {
        if (Math.Abs(Coordinates.final.X - Coordinates.initial.X) == Math.Abs(Coordinates.final.Y - Coordinates.initial.Y))
        {
            int dx = Coordinates.final.X > Coordinates.initial.X ? 1 : -1; // 1 вправо, -1 влево
            int dy = Coordinates.final.Y > Coordinates.initial.Y ? 1 : -1; // 1 вверх, -1 вниз

            int x = Coordinates.initial.X + dx;
            int y = Coordinates.initial.Y + dy;

            while (x != Coordinates.final.X && y != Coordinates.final.Y)
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
        if (Coordinates.initial.X == Coordinates.final.X && Coordinates.initial.Y != Coordinates.final.Y)
        {
            int minY = Math.Min(Coordinates.initial.Y, Coordinates.final.Y);
            int maxY = Math.Max(Coordinates.initial.Y, Coordinates.final.Y);

            for (int y = minY + 1; y < maxY; y++)
                if (Game.Board.DeterminateChessman(new Point(Coordinates.final.X, y)).Name != ChessmanName.Nun)
                    return false;

            return true;
        }
        return false;
    }

    public bool CheckHorizontalMove()
    {
        if (Coordinates.initial.Y == Coordinates.final.Y && Coordinates.initial.X != Coordinates.final.X)
        {
            int minX = Math.Min(Coordinates.initial.X, Coordinates.final.X);
            int maxX = Math.Max(Coordinates.initial.X, Coordinates.final.X);

            for (int x = minX + 1; x < maxX; x++)
                if (Game.Board.DeterminateChessman(new Point(x, Coordinates.final.Y)).Name != ChessmanName.Nun)
                    return false;
            return true;
        }
        return false;
    }
}
