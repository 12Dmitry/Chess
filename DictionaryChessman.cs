using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ListChessman
    {
        private List<Chessman> CoordinatesOfChessman;
            
        public ListChessman()
        {
            CoordinatesOfChessman = new List<Chessman>(); //HACK нужно узнать как сделать так чтобы публичное поле можно было проверить на повторы или при возможности просто их убрать
        }

        public void AddChessman(Chessman chessman)
        {
                //throw new ArgumentException("There is already a piece at this position");
                CoordinatesOfChessman.Add(chessman);
                ClassBoard.AddToBoard(chessman); //TODO: реализовать по другому, это нада сделать так чтобы сначало заполнять list, а потом добавлять на доску
        }


    }
}
