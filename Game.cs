using System.Diagnostics;
using Chess.Factory.Factory.Chessmans;
using Chess.Player;

namespace Chess;
public class Game
{
    public static bool CurrentPlayerIsWhite { get; private set; }
    public static Board Board { get; private set; }
    public static WhitePlayer WhitePlayer { get; private set; }
    public static BlackPlayer BlackPlayer { get; private set; }
    public static Stack<(Point initial, Point final, IChessman chessman)> MoveHistory { get; private set; }
    private static bool IsCheckmate { get; set; }
    private static bool IsCheck { get; set; }
    private static int MoveCount { get; set; }

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
        while (true)
        {
            MoveCount++;
            CurrentPlayerIsWhite = MoveCount % 2 != 0;
 
            MessagesForPlayer.DisplayMoveInfo(CurrentPlayerIsWhite, MoveCount);
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
        Restart();
    }

    public void Restart() // Метод для перезапуска игры
    {
        if(!MessagesForPlayer.Restart()) return;
        var game = new Game();
        game.Start(); // todo: somnitelnoo
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
        IsCheckmate = OldCheckForCheckmate();
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
    
    private bool OldCheckForCheckmate()
    {
        // Console.SetCursorPosition(0, 49);
        Stopwatch ts = new();
        ts.Start();
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
                        // Console.WriteLine("_" + ts.Elapsed);
                        // move.VerifyMove();
                        // Console.WriteLine("VerifyMove " + ts.Elapsed);
                        // move.ExecuteMove(false);
                        // Console.WriteLine("ExecuteMove " + ts.Elapsed);
                        if (!CheckForCheck())
                        {
                            // ConsolePrinterBoard.Print();
                            move.UndoMove();
                            ts.Stop();
                            Console.WriteLine("__LAST CheckForCheck " + ts.Elapsed);
                            // ConsolePrinterBoard.Print();
                            return false;
                        }
                        // ConsolePrinterBoard.Print();
                        move.UndoMove();
                        // Console.WriteLine("CheckForCheck " + ts.Elapsed);
                        // ConsolePrinterBoard.Print();
                    }
                    catch (InvalidOperationException)
                    {
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
        ts.Stop();
        Console.WriteLine("__LAST CheckForCheck " + ts.Elapsed);
        return true; // Мат
    }

    private bool CheckForCheckmate()
    {
        // Оптимизация: Предварительно получить список всех возможных ходов для текущего игрока // прошлая версия которая просто считала все ходи работала 7 сек.
        var possibleMoves = GetAllPossibleMoves(CurrentPlayerIsWhite);
        foreach (var move in possibleMoves)
        {
            try
            {
                move.ExecuteMove(false);
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        return true; // Мат
    }

// Дополнительный метод для получения всех возможных ходов
    private List<Move> GetAllPossibleMoves(bool isWhite)
    {
        var moves = new List<Move>();
        // Заполните список 'moves' всеми допустимыми ходами для 'isWhite'
        return moves;
    }
}
