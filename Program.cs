using Chess;
using Chess.Player;

Board.MakeBoard();
ConsolePrinterBoard.Print();

var wPlayer = new WhitePlayer("name");
var bPlayer = new BlackPlayer("bob");

ReaderTxt.Encoding(wPlayer, bPlayer);

Board.AddChessmansToBoard(bPlayer.PlayerChessmans);
Board.AddChessmansToBoard(wPlayer.PlayerChessmans);

while (true) // TODO : переделать?
{
    Console.SetCursorPosition(0, 30);
    Console.WriteLine("Plauer1 move");
    Move.VerifyMove();
    if (Move.IsCheckmate)
        break;
    Console.SetCursorPosition(0, 30);
    Console.WriteLine("Plauer2 move");
    if (Move.IsCheckmate)
        break;
    Move.VerifyMove();
}

Console.WriteLine("Checkmate!");
