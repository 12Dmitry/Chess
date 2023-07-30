using Chess;

ClassBoard.MakeBoard();
ClassBoard.PrintBoard();

DictionaryChessman white = new DictionaryChessman();
white.AddChessman(new Point(1,2), Chessman.Pawn);
white.AddChessman(new Point(1,1), Chessman.Rook);


