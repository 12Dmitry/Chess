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
    public static Stack<(Point initial, Point final, IChessman chessman)> MoveHistory { get; private set; }

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
        MoveHistory = new();
    }

    public void Start()
    {
        Console.WriteLine("Checkmate!");
        while (true)
        {
            MoveCount++;
            CurrentPlayerIsWhite = MoveCount % 2 != 0;

// Если текущая ширина окна больше 120, измените её перед установкой размера буфера
            Console.WindowWidth = 120;
// Теперь безопасно установить размер буфера
            Console.WindowHeight = 39;
            Console.BufferWidth = 120;

// Установка высоты буфера консоли
            Console.BufferHeight = 500; // например, 500 строк в высоту

            Console.SetCursorPosition(0, 29);
            Console.WriteLine(((CurrentPlayerIsWhite) ? "White" : "Black") + " player move - " + MoveCount + '\n'); // Выводим информацию о ходе
            // _______ todo relocate to conole message or printer!
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
    }

    public void Restart() // Метод для перезапуска игры
    {
        // TODO: реализовать логику перезапуска игры
    }

    private void FinishGame()
    {
        IsCheckmate = true;
    }

    public void PrintInfo() // Метод для вывода информации об игре
    {
        // TODO: реализовать логику вывода информации об игре
    }

    private void MakeMove((Point initial, Point final) coordinates)
    {
        Move move = new(coordinates);
        move.VerifyMove();
        move.ExecuteMove();
        IsCheck = CheckForCheck();
        if (!IsCheck) return;
        ConsolePrinterBoard.Print();
        move.UndoMove();
        ConsolePrinterBoard.Print();
        IsCheckmate = CheckForCheckmate();
        if (IsCheckmate)
        {
            FinishGame();
        }
        else
        {
            throw new InvalidOperationException("Check!");
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
                chessman.IsWhite != CurrentPlayerIsWhite && chessman.VerifyMove((chessman.Position, kingPosition))) // todo PAWN VERIFY is BROKE
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
                        move.ExecuteMove(false);
                        if (!CheckForCheck())
                        {
                            ConsolePrinterBoard.Print();
                            move.UndoMove();
                            ConsolePrinterBoard.Print();
                            return false;
                        }
                        ConsolePrinterBoard.Print();
                        move.UndoMove();
                        ConsolePrinterBoard.Print();
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
