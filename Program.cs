using Chess;

ClassBoard.MakeBoard();
ClassBoard.PrintBoard();


ListChessmen.AddChessman(new Pawn(true, new Point(1, 2)));
ListChessmen.AddChessman(new Rook(true, new Point(8, 1)));


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
