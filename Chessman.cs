using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum Chessman { Nun = 0, Pawn = 1, Horse = 3, Bishop = 3, Rook = 5, Queen = 9, King = 7 }; //TODO: на юлеарн показывали как и где его ставить.

    public abstract class ClassChessman
    {
        public Chessman Chessman { get; set; }
        public bool IsWhite { get; set; }
        //public Imagine imagine { get; set; }

        public abstract bool CheckMove(Point initial, Point final);
    }

    public class Pawn : ClassChessman
    {
        Chessman chesman = Chessman.Pawn;
        public override bool CheckMove(Point initial, Point final)
        {
            if (initial.GetX != final.GetX || initial.GetY + 1 != final.GetY)
                return false;
            else return true;
        }
    }

    public class Horse : ClassChessman
    {
        Chessman chesman = Chessman.Horse;
        public override bool CheckMove(Point initial, Point final)
        {
            if ((Math.Abs(initial.GetX - final.GetX) != 1 || Math.Abs(initial.GetY - final.GetY) != 2)
            && (Math.Abs(initial.GetX - final.GetX) != 2 || Math.Abs(initial.GetY - final.GetY) != 1))
                return false;
            if
            else return true;
        }
    }

    public class Bishop : ClassChessman
    {
        public override bool CheckMove(Point initial, Point final)
        {
            if (Math.Abs(initial.GetX - final.GetX) != Math.Abs(initial.GetY - final.GetY))
                return false;
            else return true;
        }
    }

    public class Rook : ClassChessman
    {
        public override bool CheckMove(Point initial, Point final)
        {
            if (initial.GetX != final.GetX && initial.GetY != final.GetY)
                return false;
            else return true;
        }
    }

    public class Queen : ClassChessman
    {
        public override bool CheckMove(Point initial, Point final)
        {
            if (initial.GetX != final.GetX && initial.GetY != final.GetY
                && Math.Abs(initial.GetX - final.GetX) != Math.Abs(initial.GetY - final.GetY))
                return false;
            else return true;
        }
    }

    public class King : ClassChessman
    {
        public override bool CheckMove(Point initial, Point final)
        {
            if (Math.Abs(final.GetX - initial.GetX) > 1 || Math.Abs(final.GetY - initial.GetY) > 1)
            {
                return false;
            }
            return true;
        }
    }
}
