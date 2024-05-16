using Chess.Factory.Chessmans.Pawn;
using Chess.Factory.Factory.Chessmans;

namespace Chess;

public class Board
{
    public const int Size = 8; 
    public Square[,] ChessBoard { get; private set; } = new Square[Size, Size];

    public Board()
    {
        for (int y = 0; y < Size; y++)
            for (int x = 0; x < Size; x++)
                ChessBoard[y, x] = new Square(new Nun(new Point(x + 1, y + 1)), Convert.ToBoolean((y + x) % 2));
    }

    public IChessman DeterminateChessman(Point position) // QUIZ ?
    {
        return ChessBoard[position.X - 1, position.Y - 1].Chessman;
    }

    public void MoveChessman((Point initial, Point final) coordinates, bool promotePawn = true)
    {
        IChessman initialChessman = ChessBoard[coordinates.initial.X - 1, coordinates.initial.Y - 1].Chessman;
        if (initialChessman is Pawn pawn && promotePawn) pawn.TryTransformToAnotherChessman(coordinates.final);
        ChessBoard[coordinates.final.X - 1, coordinates.final.Y - 1].Chessman = initialChessman;
        ChessBoard[coordinates.final.X - 1, coordinates.final.Y - 1].Chessman.Position = coordinates.final;
        RemoveChessman(coordinates.initial);
    }

    public void RemoveChessman(Point position)
    {
        ChessBoard[position.X - 1, position.Y - 1].Chessman = new Nun(position);
    }
    
    public void MoveBackChessman((Point initial, Point final) coordinates, IChessman chessman)
    {
        IChessman initialChessman = ChessBoard[coordinates.initial.X - 1, coordinates.initial.Y - 1].Chessman;
        // if (initialChessman is Pawn pawn) pawn.TryTransformToAnotherChessman(coordinates.final);
        ChessBoard[coordinates.final.X - 1, coordinates.final.Y - 1].Chessman = initialChessman;
        ChessBoard[coordinates.final.X - 1, coordinates.final.Y - 1].Chessman.Position = coordinates.final;
        ChessBoard[coordinates.initial.X - 1, coordinates.initial.Y - 1].Chessman = chessman;
    }

    public void AddChessmansToBoard(List<IChessman> chessmans)
    {
        foreach (var chessman in chessmans)
            ChessBoard[chessman.Position.X - 1, chessman.Position.Y - 1].Chessman = chessman;

        ConsolePrinterBoard.Print(); // HACK: после снова вызываем этот метод, он тут лишний, но при выводе фигур это смотрится прикольно
    }
}
