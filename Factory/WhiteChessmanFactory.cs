using Chess.Factory.Chessmans.Pawn;
using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory;

public class WhiteChessmanFactory : IChessmanFactory
{
    public IChessman CreateChessman(ChessmanName name, Point position)
    {
        if (name == ChessmanName.Bishop)
            return new Bishop(name, true, position);
        if (name == ChessmanName.Horse)
            return new Horse(name, true, position);
        if (name == ChessmanName.King)
            return new King(name, true, position);
        if (name == ChessmanName.Pawn)
            return new WhitePawn(name, position);
        if (name == ChessmanName.Queen)
            return new Queen(name, true, position);
        if (name == ChessmanName.Rook)
            return new Rook(name, true, position);
        if (name == ChessmanName.Nun)
            return new Nun(name, true, position);
        else
            throw new ArgumentException("Invalid chessman name");

    }
}
