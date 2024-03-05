using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;
internal class WhitePawn : Pawn
{
    private const int CoordinateForTransformation = 8; // должно ли это быть в Pawn
    public WhitePawn(ChessmanName name, Point position) : base(name, position)
    {
    }

    public override bool Cut((Point initial, Point final) coordinates)
    {
        IChessman chessmanForCut = Game.Board.DeterminateChessman(coordinates.final);
        bool hasChessman = chessmanForCut.Name != ChessmanName.Nun && chessmanForCut.IsWhite == false;
        return hasChessman && coordinates.initial.Y + 1 == coordinates.final.Y 
            && (coordinates.initial.X == coordinates.final.X - 1 
            || coordinates.initial.X == coordinates.final.X + 1);
    }

    public override bool VerifyMove((Point initial, Point final)coordinates)
    {
        var move = new Move(coordinates);
        bool valid = coordinates.initial.X == coordinates.final.X
                     && coordinates.initial.Y + 1 == coordinates.final.Y
                     && Game.Board.DeterminateChessman(coordinates.final).Name == ChessmanName.Nun
                     || Cut(coordinates)
                     || move.CheckVerticalMove()
                     && coordinates.final.Y == coordinates.initial.Y + 2
                     && !HasMove
                     && Game.Board.DeterminateChessman(coordinates.final).Name == ChessmanName.Nun;
        if (valid)
            HasMove = true;
        if (coordinates.final.Y == CoordinateForTransformation && valid)
            TransformToAnotherChessman(coordinates.final);
        return valid;
    }

    internal override void TransformToAnotherChessman(Point finalPosition)
    { 
        var wFactory = new WhiteChessmanFactory();
        Game.Board.RemoveChessman(this.Position);
        wFactory.CreateChessman(ReaderTxt.ConvertCharToChessmanName(MessagesForPlayer.GetChessman()), finalPosition);
        //TODO МБ Board.ReplaceChessman(this, newChessman, position);
    }    
}
