using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace WSStat.Model
{
    public class SailingSession
    {
        private ICollection<Sail> sails;
        private ICollection<Board> boards;

        public SailingSession()
        {
            this.sails = new HashSet<Sail>();
            this.boards = new HashSet<Board>();
        }

        public int Id { get; set; }
        public int SailorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LocationId { get; set; }

        public virtual Sailor Sailor { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Sail> Sails { get { return this.sails; } set { this.sails = value; } }
        public virtual ICollection<Board> Boards { get { return this.boards; } set { this.boards = value; } }
    }
}
