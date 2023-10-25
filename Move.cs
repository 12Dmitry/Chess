using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess;

public class Move
{
    public static bool IsCheckmate { get; private set; }

    public static void KingHasCheck (Point kingCoordinates)
    {

    }
    public static void VerifyMove() 
    {
        //Console.WriteLine("If you wont exit write: IL"); сейчас этого нет
        MessagesForPlayer error = new MessagesForPlayer();
        Point initial = MessagesForPlayer.GetCoordinates("First coordinates: ");
        Point final = MessagesForPlayer.GetCoordinates("Second coordinates: ");
        if (MoveLogic.VerifyMoveLogic(initial, final))
            Board.AddMoveToBoard(initial, final);
        else
           error.Error("Wrong move");
    }    

    private static void GiveUp()
    {
        IsCheckmate = true;
    }
}
