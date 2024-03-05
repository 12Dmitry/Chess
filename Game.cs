using Chess.Factory.Factory.Chessmans;
using Chess.Player;

namespace Chess;
public class Game
{
    public static bool IsCheckmate { get; private set; }
    public static bool IsCheck { get; private set; }
    public static int MoveCount { get; private set; }
    public static bool CurrentPlayerIsWhite { get; private set; }
    public static Board Board { get; private set; }
    public static WhitePlayer WhitePlayer { get; private set; }
    public static BlackPlayer BlackPlayer { get; private set; }
    public static Array[,] MoveHistory { get; private set; }  // TODO доделать MoveHistory

    public Game()
    {
        Board = new Board();
        ConsolePrinterBoard.Print();
        WhitePlayer = new WhitePlayer("White Player");
        BlackPlayer = new BlackPlayer("Black Player");
        ReaderTxt.Encoding(WhitePlayer, BlackPlayer);
        Board.AddChessmansToBoard(BlackPlayer.PlayerChessmans);
        Board.AddChessmansToBoard(WhitePlayer.PlayerChessmans);
        MoveCount = 0;
        CurrentPlayerIsWhite = true;
        IsCheckmate = false;
        IsCheck = false;
        //MoveHistory = new Array;
    }

    public void Start()
    {
        while (true)
        {
            MoveCount++;
            CurrentPlayerIsWhite = MoveCount % 2 != 0;
            Console.SetCursorPosition(0, 29);
            Console.WriteLine(((CurrentPlayerIsWhite) ? "White" : "Black") + " player move - " + MoveCount + '\n'); // Выводим информацию о ходе
            try
            {
                MakeMove(MessagesForPlayer.GetCoordinates());
                if (IsCheckmate) break;
            }
            catch (InvalidOperationException ex)
            {
                MessagesForPlayer.Error(ex.Message);
                MoveCount--;
                continue;
            }
            catch (ArgumentException ex)
            {
                MessagesForPlayer.Error(ex.Message);
                MoveCount--;
                continue;
            }
            ConsolePrinterBoard.Print();
        }
        Console.WriteLine("Checkmate!");
    }

    public void Restart() // Метод для перезапуска игры
    {
        // TODO: реализовать логику перезапуска игры
    }

    public void End()
    {
        IsCheckmate = true;
    }

    public void PrintInfo() // Метод для вывода информации об игре
    {
        // TODO: реализовать логику вывода информации об игре
    }

    public void MakeMove((Point initial, Point final) coordinates)
    {
        Move move = new(coordinates);
        move.VerifyMove();
        move.ExecuteMove();
        IsCheck = CheckForCheck();
        if (IsCheck)
        {
            IsCheckmate = CheckForCheckmate();
            if (IsCheckmate) End();
            else
            {
                move.UndoMove();
                throw new InvalidOperationException("Check!");
            }
        }
    }

    private bool CheckForCheck()
    {
        Point kingPosition = null!;
        foreach (var square in Board.ChessBoard) 
        {
            var chessman = square.Chessman;
            if (chessman.Name != ChessmanName.Nun && chessman.IsWhite == CurrentPlayerIsWhite && chessman is King)
            {
                kingPosition = chessman.Position;
                break;
            }
        }

        foreach (var square in Board.ChessBoard)
        {
            var chessman = square.Chessman;
            if (chessman.Name != ChessmanName.Nun && chessman.Name != ChessmanName.King &&
                chessman.IsWhite != CurrentPlayerIsWhite && chessman.VerifyMove((chessman.Position, kingPosition)))
                return true;
        }
        if (kingPosition == null) throw new ArgumentException("Hasn't King!?");
        return false;
    }

    private bool CheckForCheckmate()
    {
        foreach (var square in Board.ChessBoard) // Перебрать все возможные ходы текущего игрока
        {
            var chessman = square.Chessman;
            if (chessman.Name != ChessmanName.Nun && chessman.IsWhite == CurrentPlayerIsWhite)
            {
                foreach (var target in Board.ChessBoard) // Перебрать все клетки доски
                {
                    Move move = new((chessman.Position, target.Chessman.Position));
                    try
                    {
                        move.VerifyMove();
                        move.ExecuteMove();
                        if (!CheckForCheck())
                        {
                            move.UndoMove();
                            return false;
                        }
                        move.UndoMove();
                    }
                    catch (InvalidOperationException)
                    {
                        continue;
                    }
                }
            }
        }
        return true; // Мат
    }
}
