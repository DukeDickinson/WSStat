using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSStat.Model
{
    public class SailModel
    {
        public SailModel()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
