using Chess;
using Chess.Player;

Board.MakeBoard();
ConsolePrinterBoard.Print();

var wPlayer = new WhitePlayer("Plauer1");
var bPlayer = new BlackPlayer("Plauer2");

ReaderTxt.Encoding(wPlayer, bPlayer);

Board.AddChessmansToBoard(bPlayer.PlayerChessmans);
Board.AddChessmansToBoard(wPlayer.PlayerChessmans);

int moveCount;
for (moveCount = 1; true; moveCount++) // TODO : переделать неработает((?
{
    Player.CurrentPlayerIsWhite = moveCount % 2 != 0;
    Console.SetCursorPosition(0, 29);
    Console.WriteLine(((Player.CurrentPlayerIsWhite) ? "White" : "Black") + " player move - " + moveCount + '\n');
    try
    {
        Move.VerifyMove(MessagesForPlayer.GetCoordinates());
        if (Move.IsCheckmate) break;
    }
    catch (InvalidOperationException ex)
    {
        // Вывести сообщение об ошибке и продолжить цикл
        MessagesForPlayer.Error(ex.Message);
        moveCount--;
        continue;
    }
}

Console.WriteLine("Checkmate!");