using Chess;
using Chess.Chessmans;

Board.MakeBoard();
ConsolePrinterBoard.Print();


Board.AddChessman(new Pawn(true, new Point(1, 2)));
Board.AddChessman(new Pawn(true, new Point(2, 2)));
Board.AddChessman(new Pawn(true, new Point(3, 2)));
Board.AddChessman(new Pawn(true, new Point(4, 2)));
Board.AddChessman(new Pawn(true, new Point(5, 2)));
Board.AddChessman(new Pawn(true, new Point(6, 2)));
Board.AddChessman(new Pawn(true, new Point(7, 2)));
Board.AddChessman(new Pawn(true, new Point(8, 2)));
Board.AddChessman(new Rook(true, new Point(8, 1)));
Board.AddChessman(new Rook(true, new Point(1, 1)));
Board.AddChessman(new Queen(false, new Point(5, 8)));
Board.AddChessman(new King(true, new Point(4, 1)));



while (true)
{
    Console.WriteLine("Plauer1 move");
    Move.VerifyMove();
    if (Move.IsCheckmate)
        break;
    Console.WriteLine("Plauer2 move");
    if (Move.IsCheckmate)
        break;
    Move.VerifyMove();

}

Console.WriteLine("Checkmate!");
