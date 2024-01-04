using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallGuardian.Model.Common;

namespace CallGuardian.Common
{
    public class PersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Initials { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public GenderType GenderType { get; set; }
        public Address Address { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }

        public PersonalInfo(string firstName)
        {
            FirstName = firstName;
        }

    }
}
