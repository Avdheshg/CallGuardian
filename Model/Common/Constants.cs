using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallGuardian.Model.Common
{
    public class Constants
    {
        public static readonly int MAX_FREE_USER_CONTACTS = 10000;
        public static readonly int MAX_FREE_USER_BLOCKED_CONTATCS = 100;

        public static readonly int MAX_GOLD_USER_CONTACTS = 10000;
        public static readonly int MAX_GOLD_USER_BLOCKED_CONTACTS = 1000;

        public static readonly int MAX_PLATINUM_USER_CONTACTS = int.MaxValue;
        public static readonly int MAX_PLATINUM_USER_BLOCKED_CONTACTS = 100000;

        public static readonly int MAX_COUNT_TO_MARK_GLOBAL_BLOCKED = 1;
        public static readonly int MAX_GLOBAL_SPAM_COUNT = 100000000;

    }
}
