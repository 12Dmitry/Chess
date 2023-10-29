using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Chessmans
{
    public class ReaderTxt
    {
        private static string[] lines = File.ReadAllLines("ChessBoard.txt");

        public Chessman ConvertCharToChessman(char ch)
        {
            string s = ch.ToString();
            ChessmanName cn;
            if (Enum.TryParse<ChessmanName>(s, out cn))
                return cn;
            throw new ArgumentException("ChessmanName dos't exsist " + ch);
        }

        public bool ChekIsWhite(char ch)
        {
            if (ch == ' ')
                return true;
            if (ch == '.')
                return false;
            else
                throw new ArgumentException("The argument may be only whitespace - is white or point - is black");
        }

        public static void Encoding()
        {
            var Chessmans = new List<Chessman>();
            var reader = new ReaderTxt();
            for (int i = 0; i < lines.Length; i++)
                for (int j = 0; j < lines[i].Length; j += 2)
                {
                    Chessman cs = new Chessman(reader.ConvertCharToChessmanName(lines[i][j]), reader.ChekIsWhite(lines[i][j++]), new Point(j, i));
                    Chessmans.Add(cs);
                }

        }
    }
}
