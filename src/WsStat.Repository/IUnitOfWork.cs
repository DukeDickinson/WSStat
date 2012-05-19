using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSStat.Repository
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
