using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Chessmans;

namespace Chess;

public class Square 
{
    public Chessman Chessman { get; set; }
    public bool IsWhite { get; private set; }

    public Square(Chessman chessman, bool white)
    {
        Chessman = chessman;
        IsWhite = white;
    }
}
