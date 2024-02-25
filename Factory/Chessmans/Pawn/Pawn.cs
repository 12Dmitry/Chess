using Chess.Factory.Factory.Chessmans;

namespace Chess.Factory.Chessmans.Pawn;

public abstract class Pawn : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; }
    public Point Position { get; set; }
    public bool HasMove { get; internal set; }
    public Pawn(ChessmanName name, Point position)
    {
        Name = name;
        IsWhite = this is WhitePawn;
        Position = position;
        HasMove = false;
    }

    public abstract bool Cut(Point initial, Point final); // отдельно нужен чтобы проверить шах

    internal abstract void TransformToAnotherChessman(Point finalPosition); // TODO : Это точно должно быть тут, а то вдруг потом возникнут какие-то проблемы
//// предположим, что у вас есть метод Board.ChooseChessman, который возвращает выбранную фигуру
//        var wFactory = new WhiteChessmanFactory();
//        var reader = new ReaderTxt();
//        Board.RemoveChessman(this.Position);
//        IChessman newChessman = wFactory.CreateChessman(ReaderTxt.ConvertCharToChessmanName(MessagesForPlayer.TransformationPawn()), finalPosition);
//        //Board.ReplaceChessman(this, newChessman, position);
//    }    // ход незасчитает, а я уже фигуру поставил...
    public abstract bool VerifyMove(Point initial, Point final);
}
