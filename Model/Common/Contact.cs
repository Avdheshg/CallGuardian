using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallGuardian.Common
{
    public class Contact
    {
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string phone)
        {
            Phone = phone;
        }

        public Contact(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }

        public Contact(string countryCode, string phone, string email)
        {
            CountryCode = countryCode;
            Phone = phone;
            Email = email;
        }
    }
}
