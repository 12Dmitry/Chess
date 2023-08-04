using Chess;

ClassBoard.MakeBoard();
ClassBoard.PrintBoard();


ListChessmen.AddChessman(new Pawn(true, new Point(1, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(2, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(3, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(4, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(5, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(6, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(7, 2)));
ListChessmen.AddChessman(new Pawn(true, new Point(8, 2)));
ListChessmen.AddChessman(new Rook(true, new Point(8, 1)));
ListChessmen.AddChessman(new Rook(true, new Point(1, 1)));
ListChessmen.AddChessman(new Queen(false, new Point(5, 8)));
ListChessmen.AddChessman(new King(true, new Point(4, 1)));



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
