using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallGuardian.Common;
using CallGuardian.Model.Common;
using CallGuardian.Exceptions;
using CallGuardian.Model.Tries;

namespace CallGuardian.Model
{
    public class User : Account
    {
        public User()
        {
            ContactTrie = new ContactTrie();
        }

        public User(string phoneNumber, string firstName)
               : base(phoneNumber, firstName) { }

        public User(string phoneNumber, string firstName, string lastName)
               : base(phoneNumber, firstName, lastName) { }

        public override void Register(UserCategoryType userCategoryType, string userName, string password, string email, string phoneNumber, string countryCode, string firstName)
        {
            Id = Guid.NewGuid().ToString();
            UserCategoryType = userCategoryType;
            UserName = userName;
            Password = password;
            Contact = new Contact(phoneNumber, email, countryCode);
            PersonalInfo = new PersonalInfo(firstName);

            Init(userCategoryType);
            InsertToTries(phoneNumber, firstName);
        }

        public void Init(UserCategoryType userCategoryType)
        {
            switch (userCategoryType)
            {
                case UserCategoryType.FREE:
                    Contacts = new Dictionary<string, User>(Constants.MAX_FREE_USER_CONTACTS);
                    BlockedContacts = new List<string>(Constants.MAX_FREE_USER_BLOCKED_CONTATCS);
                    BlockedSet = new HashSet<string>(Constants.MAX_FREE_USER_BLOCKED_CONTATCS);
                    break;
                case UserCategoryType.GOLD:
                    Contacts = new Dictionary<string, User>(Constants.MAX_GOLD_USER_CONTACTS);
                    BlockedContacts = new List<string>(Constants.MAX_GOLD_USER_BLOCKED_CONTACTS);
                    BlockedSet = new HashSet<string>(Constants.MAX_GOLD_USER_BLOCKED_CONTACTS);
                    break;
                case UserCategoryType.PLATINUM:
                    Contacts = new Dictionary<string, User>(Constants.MAX_PLATINUM_USER_CONTACTS);
                    BlockedContacts = new List<string>(Constants.MAX_PLATINUM_USER_BLOCKED_CONTACTS);
                    BlockedSet = new HashSet<string>(Constants.MAX_PLATINUM_USER_BLOCKED_CONTACTS);
                    break;
            }
        }

        public override void AddContact(User user)
        {
            CheckAddUser();
            if (Contacts.ContainsKey(user.PhoneNumber) == false)
            {
                Contacts.Add(user.PhoneNumber, user);
            }
            InsertToTries(user.PhoneNumber, user.PersonalInfo.FirstName);
        }

        private void CheckAddUser()
        {
            switch (UserCategoryType)
            {
                case UserCategoryType.FREE:
                    if (Contacts.Count >= Constants.MAX_FREE_USER_CONTACTS)
                    {
                        throw new ContactsExceededException("Default contact size increases");
                    }
                    break;
                case UserCategoryType.GOLD:
                    if (Contacts.Count >= Constants.MAX_GOLD_USER_CONTACTS)
                    {
                        throw new ContactsExceededException("Default contact size increases");
                    }
                    break;
                case UserCategoryType.PLATINUM:
                    if (Contacts.Count >= Constants.MAX_PLATINUM_USER_CONTACTS)
                    {
                        throw new ContactsExceededException("Default contact size increases");
                    }
                    break;
            }
        }

        private void InsertToTries(string phoneNumber, string firstName)
        {
            ContactTrie.Insert(phoneNumber);
            ContactTrie.Insert(firstName);
            GlobalContacts.INSTANCE.ContactTrie.Insert(firstName);
        }

        public override void RemoveContact(string phoneNumber)
        {
            Contacts.TryGetValue(phoneNumber, out User contact);
            if (contact == null)
            {
                throw new ContactDoesNotExistsException("Contact doesn't exists");
            }
            Contacts.Remove(phoneNumber);
            //ContactTrie.Delete(phoneNumber);
            //ContactTrie.Delete(contact.PersonalInfo.FirstName);
        }

        public override void BlockNumber(string phoneNumber)
        {
            CheckBlockUser();
            BlockedContacts.Add(phoneNumber);
        }

        private void CheckBlockUser()
        {
            switch (UserCategoryType)
            {
                case UserCategoryType.FREE:
                    if (Contacts.Count >= Constants.MAX_FREE_USER_BLOCKED_CONTATCS)
                    // Here V R using "Contacts" list instead of "BlockedContacts" list. V can only thow the limit exceeded exception only when the number is > blocked contacts and for this V will be using "BlockedContacts" instead of "Contacts" list
                    {
                        throw new BlockLimitExceededException("Exceeded max contacts to be blocked");
                    }
                    break;
                case UserCategoryType.GOLD:
                    if (Contacts.Count >= Constants.MAX_GOLD_USER_BLOCKED_CONTACTS)
                    {
                        throw new BlockLimitExceededException("Exceeded max contacts to be blocked");
                    }
                    break;
                case UserCategoryType.PLATINUM:
                    if (Contacts.Count >= Constants.MAX_PLATINUM_USER_BLOCKED_CONTACTS)
                    {
                        throw new BlockLimitExceededException("Exceeded max contacts to be blocked");
                    }
                    break;
            }
        }

        public override void UnblockNumber(string phoneNumber)
        {
            BlockedContacts.Remove(phoneNumber);
        }

        public override void ReportSpam(string number, string reason)
        {
            
        }

        public override void Upgrade(UserCategoryType userCategoryType)
        {
            throw new NotImplementedException();
        }

        public override bool IsBlocked(string number)
        {
            throw new NotImplementedException();
        }

        public override bool CanReceive(string number)
        {
            throw new NotImplementedException();
        }

        public override bool ImportContacts(List<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
