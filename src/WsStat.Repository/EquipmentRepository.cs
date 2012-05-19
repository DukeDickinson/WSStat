using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using WSStat.Model;
using System.Linq.Expressions;
using WSStat.Common.Logging;

namespace WSStat.Repository
{
    public class EquipmentRepository : RepositoryBase, IEquipmentRepository
    {
        private IWSStatContext _context;

        public EquipmentRepository(IWSStatContext context, ILogger log)
            : base(log)
        {
            _context = context;
        }

        public Manufacturer AddManufacturer(Manufacturer manufacturer)
        {
            return Add(_context.Manufacturers, manufacturer, m => String.Compare(m.Name, manufacturer.Name, true) == 0);
        }

        public Board AddBoard(Board board)
        {
            return Add(_context.Boards, board, b => String.Compare(b.Model.Name, board.Model.Name, true) == 0 && b.Volume == board.Volume);
        }

        public Sail AddSail(Sail sail)
        {
            return Add(_context.Sails, sail, s => String.Compare(s.Model.Name, sail.Model.Name, true) == 0 && s.Size == sail.Size);
        }

        public Manufacturer GetManufacturer(string name)
        {
            return Get(_context.Manufacturers, m => String.Compare(m.Name, name, true) == 0);
        }

        public ICollection<Manufacturer> Manufacturers
        {
            get { return _context.Manufacturers.ToList(); }
        }

        public Board GetBoard(string name, int volume)
        {
            return Get(_context.Boards, b => String.Compare(b.Model.Name, name, true) == 0 && b.Volume == volume);
        }

        public BoardModel GetBoardModel(string name)
        {
            return Get(_context.BoardModels, m => String.Compare(m.Name, name, true) == 0);
        }

        public ICollection<BoardModel> BoardModels
        {
            get { return _context.BoardModels.ToList(); }
        }

        public Sail GetSail(string name, double size)
        {
            return Get(_context.Sails, s => String.Compare(s.Model.Name, name, true) == 0 && s.Size == size);
        }

        public SailModel GetSailModel(string name)
        {
            return Get(_context.SailModels, m => String.Compare(m.Name, name, true) == 0);
        }

        public ICollection<SailModel> SailModels
        {
            get { return _context.SailModels.ToList(); }
        }
    }
}
