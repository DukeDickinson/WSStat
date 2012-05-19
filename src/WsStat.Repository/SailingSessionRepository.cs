using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSStat.Common.Logging;
using WSStat.Model;

namespace WSStat.Repository
{
    public class SailingSessionRepository : RepositoryBase, ISailingSessionsRepository
    {
        private IWSStatContext _context;

        public SailingSessionRepository(IWSStatContext context, ILogger log)
            : base (log)
        {
            _context = context;
        }

        public SailingSession AddSailingSession(SailingSession session)
        {
            return _context.Sessions.Add(session);
        }


        public ICollection<SailingSession> GetSailingSessions(int sailorId)
        {
            return GetList(_context.Sessions, s => s.SailorId == sailorId).ToList();
        }
    }
}
