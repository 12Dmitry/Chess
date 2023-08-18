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
        public Point Position { get; set; }

        //public Imagine imagine { get; set; }

        public Chessman(ChessmanName name, bool isWhite, Point position)
        {
            Name = name;
            IsWhite = isWhite;
            Position = position;
            Valid = true;
        }

        public abstract bool VerifyMove(Point initial, Point final);

        // Переопределение метода ToString
        /*public override string ToString()
        {
            return $"Chessmen: Name = {Name}, IsWhite = {IsWhite}, Valid = {Valid}";
        }*/
    }

    public class Nun : Chessman
    {
        public Nun(Point position) : base(ChessmanName.Nun, false, position) { }

        public override bool VerifyMove(Point initial, Point final)
        {
            return false;
        }
    }

    public class Pawn : Chessman
    {
        public bool HasMove { get; set; }
        public Pawn (bool isWhite, Point position) : base (ChessmanName.Pawn, isWhite, position)
        {
            HasMove = false;
        }

        public override bool VerifyMove(Point initial, Point final)
        {
            if (initial.GetX == final.GetX && (initial.GetY + 1 == final.GetY)) ;
            else if (MoveLogic.CheckVerticalMove(initial, final) && !HasMove) ;
            else
                Valid = false;
            if (Valid)
                HasMove = true;
            if (final.GetY == 8 && Valid) ;
                //MoveLogic.BecomesAnotherChessman();
            return Valid;
        }
    }

    public class Horse : Chessman
    {
        public Horse(bool isWhite, Point position) : base(ChessmanName.Horse, isWhite, position) { }
        
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
        public Bishop(bool isWhite, Point position) : base(ChessmanName.Bishop, isWhite, position) {}
        public override bool VerifyMove(Point initial, Point final)
        {
            if (MoveLogic.CheckDiagonalMove(initial, final))
                Valid = true;
            return Valid;
        }
    }

    public class Rook : Chessman
    {
        public bool HasMove { get; set; }
        public bool VerticalMove { get; set; }
        public bool GorizontalMove { get; set; }
        public Rook(bool isWhite, Point position) : base(ChessmanName.Rook, isWhite, position)
        {
            HasMove = false;
        }
        public override bool VerifyMove(Point initial, Point final)
        {
            if (MoveLogic.CheckVerticalMove(initial, final))
                 Valid = true;
            else if (MoveLogic.CheckHorizontalMove(initial, final))
                Valid = true;
            else 
                Valid = false;
            if (Valid)
                HasMove = true;
            return Valid;
        }
    }

    public class Queen : Chessman
    {
        public Queen(bool isWhite, Point position) : base(ChessmanName.Queen, isWhite, position) {}

        public override bool VerifyMove(Point initial, Point final)
        {
            if (MoveLogic.CheckDiagonalMove(initial, final))
                 Valid = true;
            else if (MoveLogic.CheckVerticalMove(initial, final))
                 Valid = true;
            else if (MoveLogic.CheckHorizontalMove(initial, final))
                Valid = true;
            else Valid = false;
            return Valid;
        }
    }

    public class King : Chessman 
    {
        public bool HasMove { get; set; }
        public bool HasCastling { get; set; }
        public King(bool isWhite, Point position) : base(ChessmanName.King, isWhite, position)
        {
            HasMove = false;
            HasCastling = false;
        }

        // public bool Castling() {}
        // public bool DeclareCheck(Point final) {}

        public override bool VerifyMove(Point initial, Point final)
        {
            if (Math.Abs(final.GetX - initial.GetX) > 1 || Math.Abs(final.GetY - initial.GetY) > 1) 
                Valid = false;
            //else Castling()
            if (Valid)
                HasMove = true;
            return Valid;
        }
    }
}
