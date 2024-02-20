using Chess.Factory;
using Chess.Player;

namespace Chess;

public class ReaderTxt
{
    // длина строки в файле должна быть 17,т.к. чтобы понять какого цвета фигура НЕТ черные - строчные, белые - заглавные. Доска всегда повернута за белых.
    private static string _path = Path.Combine(Environment.CurrentDirectory, "ChessBoard.txt"); //HACK : мне обязательно нужно чтобы здесь лежал путь до ChessBoard.txt! QUIZ :как мне ужнать путь до жтого места
    private static readonly string[] lines = File.ReadAllLines(_path);   //@"C:\\Users\\Dmitry\\Source\\Repos\\12Dmitry\\Chess\\ChessBoard.txt"

    public ChessmanName ConvertCharToChessmanName(char ch) // TODO : помоему это не здесь должно быть или норм, оставить и сделатьь статическим как ваабще определять это?
    {
        string name = Enum.GetName(typeof(ChessmanName), (int)Char.ToUpper(ch))!;
        if (name != null)
            return (ChessmanName)Enum.Parse(typeof(ChessmanName), name);
        throw new ArgumentException("ChessmanName dos't exsist - " + "'" + ch + "'.");
    }

    public static void Encoding(WhitePlayer white, BlackPlayer black)
    {
        IsRightFormatTxt();

        var wFactory = new WhiteChessmanFactory();
        var bFactory = new BlackChessmanFactory();
        var reader = new ReaderTxt();
        for (int i = 0; i < lines.Length; i++)
        {
            int x = 1; // QUIZ : на сколько это норм, что переменная объявляется в цикле? Думаю норм
            for (int j = 0; j < lines[i].Length; j ++)
            {
                if (ChekIsWhite(lines[i][j]))
                    white.AddChessman(wFactory.CreateChessman(reader.ConvertCharToChessmanName(lines[i][j]), new Point(x, i + 1)));
                else
                    black.AddChessman(bFactory.CreateChessman(reader.ConvertCharToChessmanName(lines[i][j]), new Point(x, i + 1)));
                x++;
            }
        }
    }

    private static void IsRightFormatTxt()
    {
        if (lines.Length != 8) // HACK: magic number
            throw new ArgumentException("The txt document must have 8 lines!");
        foreach (string line in lines)
            if (line.Length != 8)// HACK: magic number
                throw new ArgumentException("There should be 8 characters in the txt document line!");
    }
    
    private static bool ChekIsWhite(char ch)
    {
        if (Char.IsUpper(ch))
            return true;
        if (Char.IsLower(ch))
            return false;
        else
            throw new ArgumentException("The argument may be only UPPERCASE - is white or lowercase - is black."); // QUIZ : как лучше писать на английском или на русском? In english
    }

}
