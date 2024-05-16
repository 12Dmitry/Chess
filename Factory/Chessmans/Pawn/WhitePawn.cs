using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;
internal class WhitePawn : Pawn
{
    protected sealed override int CoordinateForTransformation { get; set; }

    public WhitePawn(ChessmanName name, Point position) : base(name, position)
    {
        CoordinateForTransformation = 8;
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
        return valid;
    }

    public override void TryTransformToAnotherChessman(Point finalPosition)
    { 
        if (finalPosition.Y != CoordinateForTransformation) return;
        
        var wFactory = new WhiteChessmanFactory();
        Game.Board.RemoveChessman(this.Position);
        wFactory.CreateChessman(ReaderTxt.ConvertCharToChessmanName(MessagesForPlayer.GetChessman()), finalPosition);
        //TODO МБ Board.ReplaceChessman(this, newChessman, position);
    }
}
