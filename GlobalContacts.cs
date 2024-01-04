using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallGuardian.Model.Tries;

namespace CallGuardian
{
    // What is the benifit of classes which provide a global static object and V can't create a new object for them

    public class GlobalContacts
    {
        private GlobalContacts() { }

        public static GlobalContacts INSTANCE = new GlobalContacts();

        public ContactTrie ContactTrie = new ContactTrie();

    }
}
