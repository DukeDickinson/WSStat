using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using WSStat.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WSStat.Repository
{
    public class WSStatContext : DbContext, IWSStatContext
    {
        public IDbSet<Board> Boards { get; set; }
        public IDbSet<BoardModel> BoardModels { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Sail> Sails { get; set; }
        public IDbSet<SailModel> SailModels { get; set; }
        public IDbSet<Sailor> Sailors { get; set; }
        public IDbSet<SailingSession> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<SailingSession>()
                .HasMany(s => s.Sails).WithMany()
                .Map(map => map.ToTable("SessionSails")
                    .MapRightKey("SailId")
                    .MapLeftKey("SessionId"));

            modelBuilder.Entity<SailingSession>()
                .HasMany(s => s.Boards).WithMany()
                .Map(map => map.ToTable("SessionBoards")
                    .MapRightKey("BoardId")
                    .MapLeftKey("SessionId"));

            // Many to many resolver
            // Map the Sails and Sail Sizes navigation property using the SailSailSizes Many-to-Many table.
            //modelBuilder.Entity<Sail>()
            //    .HasMany(s => s.SailSizes)
            //    .WithMany(ss => ss.Sails)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("SailId");
            //        m.MapRightKey("SailSizeId");
            //        m.ToTable("SailSailSize");
            //    });

        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
