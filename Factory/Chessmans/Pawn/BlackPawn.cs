using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;
internal class BlackPawn : Pawn
{
    private readonly int _coordinateForTransformation = 1;
    public BlackPawn(ChessmanName name, Point position) : base(name, position)
    {
    }

    public override bool Cut(Point initial, Point final)
    {
        IChessman chessmanForCut = Board.DeterminateChessman(final);
        bool hasChessman = chessmanForCut.Name != ChessmanName.Nun && chessmanForCut.IsWhite;
        return hasChessman && initial.Y - 1 == final.Y && (initial.X == final.X - 1 || initial.X == final.X + 1);
    }

    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid = initial.X == final.X && initial.Y - 1 == final.Y && Board.DeterminateChessman(final).Name == ChessmanName.Nun 
       || Cut(initial, final) ||
       MoveLogic.CheckVerticalMove(initial, final) && final.Y == initial.Y - 2 && !HasMove && Board.DeterminateChessman(final).Name == ChessmanName.Nun;
        if (valid)
            HasMove = true;
        if (final.Y == _coordinateForTransformation && valid)
            TransformToAnotherChessman(final);
        return valid;
    }

    internal override void TransformToAnotherChessman(Point finalPosition)
    {
        var bFactory = new BlackChessmanFactory();
        Board.RemoveChessman(this.Position);
        bFactory.CreateChessman(ReaderTxt.ConvertCharToChessmanName(MessagesForPlayer.GetChessman()), finalPosition);
    }
}
