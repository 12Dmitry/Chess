using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum Chessman { Pawn = 1, Horse = 3, Bishop = 3, Rook = 5, Queen = 9, King = 7 }; //TODO: на юлеарн показывали как и где его ставить.

    public abstract class ClassChessman
    {
        public bool IsWhite { get; set; }
        //public Imagine imagine { get; set; }

        public abstract bool CheckMove(Point initial, Point final);
    }

    public class Pawn : ClassChessman
    {
        public override bool CheckMove(Point initial, Point final)
        {
            if (initial.GetX == final.GetX && initial.GetY + 1 == final.GetY)
                return true;
            else return false;
        }
    }
}
