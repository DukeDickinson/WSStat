using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSStat.Model
{
    public class Board
    {
        public Board()
        {

        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Volume { get; set; }

        public virtual BoardModel Model { get; set; }
    }
}
