using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using WSStat.Model;

namespace WSStat.Repository
{
    public interface IWSStatContext : IUnitOfWork
    {
        IDbSet<Board> Boards { get; set; }
        IDbSet<BoardModel> BoardModels { get; set; }
        IDbSet<Location> Locations { get; set; }
        IDbSet<Manufacturer> Manufacturers { get; set; }
        IDbSet<Sail> Sails { get; set; }
        IDbSet<SailModel> SailModels { get; set; }
        IDbSet<Sailor> Sailors { get; set; }
        IDbSet<SailingSession> Sessions { get; set; }
    }
}
