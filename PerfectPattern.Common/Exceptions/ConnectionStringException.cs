using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPattern.Common.Exceptions
{
    public class ConnectionStringException : Exception
    {
        public ConnectionStringException() :
            base() { }

        public ConnectionStringException(string msg) :
            base(msg) { }
    }
}
