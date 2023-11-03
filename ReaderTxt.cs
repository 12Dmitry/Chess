using Chess.Factory;
using Chess.Player;

namespace Chess;

public class ReaderTxt
{
    // длина строки в файле должна быть 17,т.к. чтобы понять какого цвета фигура
    // он должен увидеть в след символе после фигуры пробел - белая или точку - черная.   - это ваабще можно где-то указать? 
    private static string _path = Path.Combine(Environment.CurrentDirectory, "ChessBoard.txt"); //HACK : мне обязательно нужно чтобы здесь лежал путь до ChessBoard.txt! QUIZ :как мне ужнать путь до жтого места
    private static readonly string[] lines = File.ReadAllLines(_path);   //@"C:\\Users\\Dmitry\\Source\\Repos\\12Dmitry\\Chess\\ChessBoard.txt"

    public ChessmanName ConvertCharToChessmanName(char ch) // TODO : помоему это не здесь должно быть или норм, оставить и сделатьь статическим как ваабще определять это?
    {
        string name = Enum.GetName(typeof(ChessmanName), (int)ch)!;
        if (name != null)
            return (ChessmanName)Enum.Parse(typeof(ChessmanName), name);
        throw new ArgumentException("ChessmanName dos't exsist " + "'" + ch + "'");
    }

    public static void Encoding(WhitePlayer white, BlackPlayer black)
    {
        IsRightFormatTxt();

        var wFactory = new WhiteChessmanFactory();
        var bFactory = new BlackChessmanFactory();
        var reader = new ReaderTxt();
        for (int i = 0; i < lines.Length; i++)
        {
            int x = 1; // QUIZ : на сколько этоо норм, что переменная объявляется в цикле?
            for (int j = 0; j < lines[i].Length; j += 2)
            {
                if (ChekIsWhite(lines[i][j + 1]) && lines[i][j] != ' ')
                    white.AddChessman(wFactory.CreateChessman(reader.ConvertCharToChessmanName(lines[i][j]), new Point(x, i + 1)));
                if (lines[i][j] != ' ')
                    black.AddChessman(bFactory.CreateChessman(reader.ConvertCharToChessmanName(lines[i][j]), new Point(x, i + 1)));
                x++;
            }
        }
    }

    private static void IsRightFormatTxt()
    {
        if (lines.Length != 8)
            throw new ArgumentException("txt документ должен иметь 8 строк");
        foreach (string line in lines)
            if (line.Length != 16)
                throw new ArgumentException("В строке txt документа должено быть 17 символов");
    }
    
    private static bool ChekIsWhite(char ch)
    {
        if (ch == ' ')
            return true;
        if (ch == '.')
            return false;
        else
            throw new ArgumentException("The argument may be only whitespace - is white or point - is black"); // QUIZ : как лучше писать на английском или на русском?
    }

}
