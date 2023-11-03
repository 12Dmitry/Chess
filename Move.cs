namespace Chess;

public class Move // TODO : мб VerifyMove в Player, а класс переименовать
{
    public static bool IsCheckmate { get; private set; }

    public static bool HasCheck (Point kingCoordinates) // где должен храниться kingCoordinates? навернок в Black \ White
    {
        // TODO :
        // находим короля с помощью листа или пробегая по всей доске
        // проверяем каждую фигуру соперника, если она может сходить на короля, то это шах
        // игрок будет ходить до тех пор пока не выйдет из под шаха.
        return false;
    }
    public static void VerifyMove() 
    {
        //Console.WriteLine("If you wont exit write: IL"); сейчас этого нет
        Point initial = MessagesForPlayer.GetCoordinates("First coordinates: ");
        Point final = MessagesForPlayer.GetCoordinates("Second coordinates: ");
        if (MoveLogic.VerifyMoveLogic(initial, final))
        {
            if (!HasCheck(new Point(1,1)))
                Board.AddMoveToBoard(initial, final);
            else
                MessagesForPlayer.Error("Check!");
        }
    }    

    private static void ToLose()
    {
        IsCheckmate = true;
    }
}
