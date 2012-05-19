using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSStat.Model;

namespace WSStat.Repository
{
    public interface ISailingSessionsRepository
    {
        SailingSession AddSailingSession(SailingSession session);

        ICollection<SailingSession> GetSailingSessions(int sailorId);

    }
}
