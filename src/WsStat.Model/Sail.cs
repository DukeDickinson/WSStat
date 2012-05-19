using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSStat.Model
{
    public class Sail
    {
        public Sail()
        {

        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public double Size { get; set; }

        public virtual SailModel Model { get; set; }
    }
}
