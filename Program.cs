﻿using Chess;

ClassBoard.MakeBoard();
ClassBoard.PrintBoard();

DictionaryChessman white = new DictionaryChessman();
white.AddChessman(new Point(1, 2), new Pawn(true));
white.AddChessman(new Point(1, 1), new Rook(true));
white.AddChessman(new Point(8, 1), new Rook(true));


