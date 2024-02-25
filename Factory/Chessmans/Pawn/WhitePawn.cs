using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;
internal class WhitePawn : Pawn
{
    private readonly int _coordinateForTransformation = 8;
    public WhitePawn(ChessmanName name, Point position) : base(name, position)
    {
    }

    public override bool Cut(Point initial, Point final)
    {
        IChessman chessmanForCut = Board.DeterminateChessman(final);
        bool hasChessman = chessmanForCut.Name != ChessmanName.Nun && chessmanForCut.IsWhite == false;
        return hasChessman && initial.Y + 1 == final.Y && (initial.X == final.X - 1 || initial.X == final.X + 1);
    }

    public override bool VerifyMove(Point initial, Point final)
    {
        bool valid;
        valid = initial.X == final.X && initial.Y + 1 == final.Y && Board.DeterminateChessman(final).Name == ChessmanName.Nun 
            || Cut(initial, final) ||
        MoveLogic.CheckVerticalMove(initial, final) && final.Y == initial.Y + 2 && !HasMove && Board.DeterminateChessman(final).Name == ChessmanName.Nun;
        if (valid)
            HasMove = true;
        if (final.Y == _coordinateForTransformation && valid)
            TransformToAnotherChessman(final);
        return valid;
    }

    internal override void TransformToAnotherChessman(Point finalPosition)
    { // TODO : Это точно должно быть тут, а то вдруг потом возникнут какие-то проблемы
      // предположим, что у вас есть метод Board.ChooseChessman, который возвращает выбранную фигуру
        var wFactory = new WhiteChessmanFactory();
        Board.RemoveChessman(this.Position);
        wFactory.CreateChessman(ReaderTxt.ConvertCharToChessmanName(MessagesForPlayer.TransformationPawn()), finalPosition);
        //Board.ReplaceChessman(this, newChessman, position);
    }    // ход незасчитает, а я уже фигуру поставил...
}
