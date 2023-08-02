using Chess;

ClassBoard.MakeBoard();
ClassBoard.PrintBoard();

DictionaryChessman white = new DictionaryChessman();
white.AddChessman(new Point(1, 2), new Pawn(true));
white.AddChessman(new Point(8, 1), new Rook(true));


while (true)
{
    Console.WriteLine("Plauer1 move");
    Move.MakeMove();
    if (Move.GetIsCheckmate)
        break;
    Console.WriteLine("Plauer2 move");
    if (Move.GetIsCheckmate)
        break;
    Move.MakeMove();

}

Console.WriteLine("Checkmate!");
