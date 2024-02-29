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
for (moveCount = 1; true; moveCount++) // TODO : переделать?
{
    Player.CurrentPlayerIsWhite = moveCount % 2 != 0;
    Console.SetCursorPosition(0, 30);
    Console.WriteLine((Player.CurrentPlayerIsWhite)? "White" : "Black" + " player move - " + moveCount);
    Move.VerifyMove(MessagesForPlayer.GetCoordinates());
    if (Move.IsCheckmate) break;
}

Console.WriteLine("Checkmate!");