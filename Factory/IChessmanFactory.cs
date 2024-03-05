using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory;

public interface IChessmanFactory
{
    IChessman CreateChessman(ChessmanName name, Point position);
}
