using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallGuardian.Model.Common;

namespace CallGuardian.Model.Common
{
    public class GlobalSpam
    {
        private Dictionary<string, int?> globalSpam = new Dictionary<string, int?>(Constants.MAX_GLOBAL_SPAM_COUNT);

        private List<string> globalBlocked = new List<string>(Constants.MAX_GLOBAL_SPAM_COUNT);

        private GlobalSpam() { }

        public static GlobalSpam INSTANCE = new GlobalSpam();

        public void ReportSpam(string spamNumber, string reportingNumber, string reason)
        {
            Console.WriteLine($"Send metrics here for spam Number {spamNumber} reported {reportingNumber} for reason {reason}");

            globalSpam.TryGetValue(spamNumber, out int? markedAsSpamCount);
            if (markedAsSpamCount == null)
            {
                globalSpam[spamNumber] = 1;
            }

            if (globalSpam[spamNumber] >= Constants.MAX_COUNT_TO_MARK_GLOBAL_BLOCKED)
            {
                globalBlocked.Add(spamNumber);
            } 
            else
            {
                globalSpam[spamNumber] += 1;
            }

        }

    }
}
