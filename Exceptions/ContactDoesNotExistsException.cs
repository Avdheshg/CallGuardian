using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallGuardian.Exceptions
{
    public class ContactDoesNotExistsException : Exception
    {
        public ContactDoesNotExistsException(string exceptionMessage)
               : base(exceptionMessage) { }
    }
}
