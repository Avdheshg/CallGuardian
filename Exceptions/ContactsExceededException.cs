using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallGuardian.Exceptions
{
    public class ContactsExceededException : Exception
    {
        public ContactsExceededException(string exceptionMessage)
               : base(exceptionMessage) { }

    }
}
