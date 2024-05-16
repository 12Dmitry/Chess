using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;
internal class BlackPawn : Pawn
{
    protected sealed override int CoordinateForTransformation { get; set; }

    public BlackPawn(ChessmanName name, Point position) : base(name, position)
    {
        CoordinateForTransformation = 1;
    }

    public override bool Cut((Point initial, Point final)coordinates)
    {
        IChessman chessmanForCut = Game.Board.DeterminateChessman(coordinates.final);
        bool hasChessman = chessmanForCut.Name != ChessmanName.Nun && chessmanForCut.IsWhite;
        return hasChessman && coordinates.initial.Y - 1 == coordinates.final.Y 
            && (coordinates.initial.X == coordinates.final.X - 1 
            || coordinates.initial.X == coordinates.final.X + 1);
    }

    public override bool VerifyMove((Point initial, Point final) coordinates)
    {
    var move = new Move(coordinates);
        bool valid = coordinates.initial.X == coordinates.final.X
                     && coordinates.initial.Y - 1 == coordinates.final.Y
                     && Game.Board.DeterminateChessman(coordinates.final).Name == ChessmanName.Nun
                     || Cut(coordinates)
                     || move.CheckVerticalMove()
                     && coordinates.final.Y == coordinates.initial.Y - 2
                     && !HasMove
                     && Game.Board.DeterminateChessman(coordinates.final).Name == ChessmanName.Nun;
        if (valid)
            HasMove = true;
        return valid;
    }

    public override void TryTransformToAnotherChessman(Point finalPosition)
    {
        var bFactory = new BlackChessmanFactory();
        Game.Board.RemoveChessman(this.Position);
        bFactory.CreateChessman(ReaderTxt.ConvertCharToChessmanName(MessagesForPlayer.GetChessman()), finalPosition);
    }
}
