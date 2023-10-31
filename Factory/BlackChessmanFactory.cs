using Chess.Factory.Factory.Chessmans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Factory
{
    public class BlackChessmanFactory : IChessmanFactory
    {
        public IChessman CreateChessman(ChessmanName name, Point position)
        {
            if (name == ChessmanName.Bishop)
                return new Bishop(name, false, position);
            if (name == ChessmanName.Horse)
                return new Horse(name, false, position);
            if (name == ChessmanName.King)
                return new King(name, false, position);
            if (name == ChessmanName.Pawn)
                return new Pawn(name, false, position);
            if (name == ChessmanName.Queen)
                return new Queen(name, false, position);
            if (name == ChessmanName.Rook)
                return new Rook(name, false, position);
            if (name == ChessmanName.Nun)
                return new Nun(name, false, position);
            else
                throw new ArgumentException("Invalid chessman name");
        }
    }
}
