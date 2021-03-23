using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitMVVM
{
    class InternalException : Exception
    {
        public InternalException(string message) : base(message)
        { }
    }
}
