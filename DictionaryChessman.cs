using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class DictionaryChessman
    {
        private Dictionary<Point, Chessman> CoordinatesOfChessman;
            
        public DictionaryChessman()
        {
            CoordinatesOfChessman = new Dictionary<Point, Chessman>(); //HACK если добавлять в него одинаковые значения, то он их не отлавливает (21стр.), они просто проходят как новые :(
        }

        public void AddChessman(Point position, Chessman chessman)
        {
            if (CoordinatesOfChessman.Keys.Contains(position))
                throw new ArgumentException("There is already a piece at this position");
            else
            {
                CoordinatesOfChessman.Add(position, chessman);
                ClassBoard.AddToBoard(position, chessman); //TODO: реализовать по другому, это нада сделать так чтобы сначало заполнять словарь, а потом добавлять на доску

            }
        }


    }
}
