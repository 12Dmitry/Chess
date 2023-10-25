using Chess.Chessmans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess;

public class Player
{
    public bool IsWhite { get; private set; }

    private List<Chessman> PlayerChessmans; // хранит все доступные фигуры игрока
}
