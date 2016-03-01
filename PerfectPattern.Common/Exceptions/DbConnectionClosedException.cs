using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPattern.Common.Exceptions
{
    public class DbConnectionClosedException : Exception
    {
        public DbConnectionClosedException() :
            base() { }

        public DbConnectionClosedException(string msg) :
            base(msg) { }
    }
}
