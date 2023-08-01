using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum ChessmanName { Nun = 0, Pawn = 1, Horse = 3, Bishop = 3, Rook = 5, Queen = 9, King = 111 }; //TODO: на юлеарн показывали как и где его ставить.

    public abstract class Chessman
    {
        public ChessmanName Name { get; set; }
        public bool IsWhite { get; set; }
        public bool Valid { get; set; }
        //public Imagine imagine { get; set; }

        public Chessman(ChessmanName name, bool isWhite)
        {
            Name = name;
            IsWhite = isWhite;
            Valid = true;
        }

        public abstract bool VerifyMove(Point initial, Point final);

        // Переопределение метода ToString
        /*public override string ToString()
        {
            return $"Chessman: Name = {Name}, IsWhite = {IsWhite}, Valid = {Valid}";
        }*/
    }

    public class Nun : Chessman
    {
        public Nun() : base(ChessmanName.Nun, false) { }

        public override bool VerifyMove(Point initial, Point final)
        {
            return false;
        }
    }

    public class Pawn : Chessman
    {
        public bool HasMove { get; set; }
        public Pawn (bool isWhite) : base (ChessmanName.Pawn, isWhite)
        {
            HasMove = false;
        }

        public override bool VerifyMove(Point initial, Point final)
        {
            if (initial.GetX == final.GetX && (initial.GetY + 1 == final.GetY ||
               (initial.GetY + 2 == final.GetY && HasMove)) || (Math.Abs(initial.GetX - final.GetX) == 1 && final.GetY - initial.GetY == 1)) ;
            else
                Valid = false;
            if (Valid)
                HasMove = true;
            return Valid;
        }
    }

    public class Horse : Chessman
    {
        public Horse(bool isWhite) : base(ChessmanName.Horse, isWhite) { }
        
        public override bool VerifyMove(Point initial, Point final)
        {
            if ((Math.Abs(initial.GetX - final.GetX) == 1 || Math.Abs(initial.GetY - final.GetY) == 2)
            && (Math.Abs(initial.GetX - final.GetX) == 2 || Math.Abs(initial.GetY - final.GetY) == 1)) ;
            else
                Valid = false;

            return Valid;
        }
    }

    public class Bishop : Chessman
    {
        public Bishop(bool isWhite) : base(ChessmanName.Bishop, isWhite)
        {
        }
        public override bool VerifyMove(Point initial, Point final)
        {
            if (Math.Abs(initial.GetX - final.GetX) != Math.Abs(initial.GetY - final.GetY))
                return false;
            else return true;
        }
    }

    public class Rook : Chessman
    {
        public bool HasMove { get; set; }
        public Rook(bool isWhite) : base(ChessmanName.Rook, isWhite)
        {
            HasMove = false;
        }
        public override bool VerifyMove(Point initial, Point final)
        {
            if (initial.GetX != final.GetX || initial.GetY != final.GetY)
                Valid = false;
            if (Valid)
                HasMove = true;
            return Valid;
        }
    }

    public class Queen : Chessman
    {
        public Queen(bool isWhite) : base(ChessmanName.Queen, isWhite) { }

        public override bool VerifyMove(Point initial, Point final)
        {
            if (initial.GetX != final.GetX || initial.GetY != final.GetY
                && Math.Abs(initial.GetX - final.GetX) != Math.Abs(initial.GetY - final.GetY))
                return false;
            else return true;
        }
    }

    public class King : Chessman
    {
        public bool HasMove { get; set; }
        public King(bool isWhite) : base(ChessmanName.King, isWhite)
        {
            HasMove = false;
        }

        // public bool Castling() {}
        // public bool Check(Point final) {}

        public override bool VerifyMove(Point initial, Point final)
        {
            if (Math.Abs(final.GetX - initial.GetX) > 1 || Math.Abs(final.GetY - initial.GetY) > 1)
                Valid = false;
            if (Valid)
                HasMove = true;
            return Valid;
        }
    }
}
