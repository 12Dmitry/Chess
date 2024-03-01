using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Move // TODO : подумать над тем где это должно быть
{
    public static bool IsCheckmate { get; private set; }

    public static bool IsCheck() // QUIZ: где должен храниться kingPosition?
    {
        var board = Board.board;
        bool playerIsWhite = Player.Player.CurrentPlayerIsWhite;
        // Найти позицию короля текущего игрока - вынести кудато?
        Point kingPosition = null;
        foreach (var square in board)
        {
            var chessman = square.Chessman;
            if (chessman != null && chessman.IsWhite == playerIsWhite && chessman is King)
            {
                kingPosition = chessman.Position;
                break;
            }
        }

        foreach (var square in board)
        {
            var chessman = square.Chessman;
            if (chessman.Name != ChessmanName.Nun && chessman.Name != ChessmanName.King && chessman.IsWhite != playerIsWhite && chessman.VerifyMove(chessman.Position, kingPosition))
                return true; // Король находится под шахом
        }
        if (kingPosition == null) throw new ArgumentException("Hasn't King!?");
        return false; // Король не находится под шахом
    }

    public static void VerifyMove((Point initial, Point final) coordinates)
    {
        //Console.WriteLine("If you wont exit write: IL"); сейчас этого нет
        if (Board.DeterminateChessman(coordinates.initial).IsWhite != Player.Player.CurrentPlayerIsWhite)
            throw new InvalidOperationException("You can't move this chessman");
        if (MoveLogic.VerifyMoveLogic(coordinates))
            if (!IsCheck()) Board.MoveChessman(coordinates);
            else throw new InvalidOperationException("Check!");
    }

    private static void ToLose()
    {
        IsCheckmate = true;
    }
}
