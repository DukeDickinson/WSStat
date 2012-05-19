using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSStat.Repository
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base (message, innerException)
        {
        }
    }
}

