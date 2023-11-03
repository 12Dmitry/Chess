namespace Chess.Factory.Factory.Chessmans;

public class Pawn : IChessman
{
    public ChessmanName Name { get; set; }
    public bool IsWhite { get; set; }
    public Point Position { get; set; }
    public bool HasMove { get; private set; }
    public Pawn(ChessmanName name, bool isWhite, Point position)
    {
        Name = name;
        IsWhite = isWhite;
        Position = position;
        HasMove = false;
    }

    public bool Cut(Point initial, Point final) // отдельно нужен чтобы проверить шах
    {
        IChessman chessman = Board.DeterminateChessman(final);
        bool hasChessman = chessman.Name != ChessmanName.Nun && chessman.IsWhite != this.IsWhite;
        if (this.IsWhite)
            return hasChessman && initial.Y + 1 == final.Y && (initial.X == final.X - 1 || initial.X == final.X + 1);
        else
            return hasChessman && initial.Y - 1 == final.Y && (initial.X == final.X - 1 || initial.X == final.X + 1);
    }

    private void BecomeAnotherChessman(Point position) // TODO : Это точно должно быть тут, а то вдруг потом возникнут какие-то проблемы
        // ход незасчитает, а я уже фигуру поставил...
    {
        // думю здесь будем делать через лист фигур
        if (this.IsWhite) ; // то есть мне тут обновить и доску и лист фигур?
            
    }
    public bool VerifyMove(Point initial, Point final)
    {
        bool valid;
        if (this.IsWhite) // HACK: в зависимости от того белая пешка или черная мы задаем ей направление
            valid = initial.X == final.X && initial.Y + 1 == final.Y || Cut(initial, final) ||
            MoveLogic.CheckVerticalMove(initial, final) && final.Y == initial.Y + 2 && !HasMove;
        else
            valid = initial.X == final.X && initial.Y - 1 == final.Y || Cut(initial, final) ||
            MoveLogic.CheckVerticalMove(initial, final) && final.Y == initial.Y - 2 && !HasMove;
        if (valid)
            HasMove = true;
        if (final.Y == Board.Size && valid) 
            BecomeAnotherChessman(final);
        return valid;
    }
}
