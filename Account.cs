using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallGuardian.Common;
using CallGuardian.Model;
using CallGuardian.Model.Common;
using CallGuardian.Model.Tries;

namespace CallGuardian
{
    public abstract class Account
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastAccessed { get; set; }
        public TagType Tag { get; set; }
        public Contact Contact { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public SocialInfo SocialInfo { get; set; }
        public Business Business { get; set; }
        public UserCategoryType UserCategoryType { get; set; }

        public Dictionary<String, User> Contacts = new Dictionary<string, User>();

        public List<string> BlockedContacts;

        public HashSet<string> BlockedSet;
        public ContactTrie ContactTrie { get; set; }

        public Account() { }

        public Account(string phoneNumber, string firstName)
        {
            PhoneNumber = phoneNumber;
            PersonalInfo = new PersonalInfo(firstName);
        }

        public Account(string phoneNumber, string firstName, string lastName)
               : this(phoneNumber, firstName)
        {
            PersonalInfo.LastName = lastName;
        }

        public abstract void Register(UserCategoryType userCategoryType, string userName, string password, string emial, string phoneNumber, string countryCode, string firstName);

        public abstract void AddContact(User user);
        public abstract void RemoveContact(string number);
        public abstract void BlockNumber(string number);
        public abstract void UnblockNumber(string number);
        public abstract void ReportSpam(string number, string reason);
        public abstract void Upgrade(UserCategoryType userCategoryType);
        public abstract Boolean IsBlocked(string number);
        public abstract Boolean CanReceive(string number);
        public abstract Boolean ImportContacts(List<User> users);


    }
}
