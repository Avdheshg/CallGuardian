using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CallGuardian.Model;
using CallGuardian.Model.Common;

namespace CallGuardian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

/*
    1. All the member variable are not working with security => What is the way to make them secure 
*/
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StartCallGaurdianApplication();
        }

        public void StartCallGaurdianApplication()
        {

            // Test Case 1 : Create and Register the User
            Account avdheshAccount = new User();
            /*
                Each user is having a 
                    ContactTrie which is having
                        TrieNode which has
                            childrens[]

            Whenever a new user is created then in the ContactTrie's TrieNode will contains the 4 children
                u for u1
                6 for 6826999256
                9 for 9140107431
                m for mahadev

            And each TrieNode itself contains a TrieNode[] for their own childrens so all above 4 childrens will behave as a starting point for the rest of the word
            */
            avdheshAccount.Register(UserCategoryType.FREE, "u1", "pwd", "u1@email.com", "6826999256", "91", "u1");

            // Test Case 2 : Add contacts to the user
            /*
            AddContact:
                - When a new contact is Added, it will be also be added into the ContactTrie and in GlobalContact's Trie
            */
            avdheshAccount.AddContact(new User("9140107431", "aaaaa"));
            avdheshAccount.AddContact(new User("8558101117", "govind"));
            avdheshAccount.AddContact(new User("8723937942", "gopala"));
            avdheshAccount.AddContact(new User("7070063864", "mahesha"));
            avdheshAccount.AddContact(new User("6610448270", "parvathi"));
            avdheshAccount.AddContact(new User("7336175457", "parameshwari"));
            avdheshAccount.AddContact(new User("7202250272", "narayan"));
            avdheshAccount.AddContact(new User("7859999997", "lakshmi"));
            avdheshAccount.AddContact(new User("9653498522", "ganesh", "kumar"));
            avdheshAccount.AddContact(new User("7277115893", "ganapathy"));
            avdheshAccount.AddContact(new User("9495010564", "Bhrama"));
            avdheshAccount.AddContact(new User("9844296241", "Saraswathi"));
            avdheshAccount.AddContact(new User("7917949575", "a.Veena"));

            // Test Case 3 : Check added contacts count
            Console.WriteLine($"{avdheshAccount.UserName} has {avdheshAccount.Contacts.Count} contacts");

            // Test Case 4 : search for contacts by name
            Console.WriteLine($"**** Getting name with prefix ma ****");
            List<string> names = avdheshAccount.ContactTrie.AllWordsWithPrefix("ma");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // Test Case 5 : search for contacts by Name
            Console.WriteLine("** Getting name with prefix go **");
            names = avdheshAccount.ContactTrie.AllWordsWithPrefix("go");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // Test Case 6a : search for contacts by phone
            Console.WriteLine("Getting numbers with prefix 72");
            names = avdheshAccount.ContactTrie.AllWordsWithPrefix("72");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            // Test Case 6b : Seach for contacts by phone
            Console.WriteLine("Getting numbers with prefix 6610448270");
            names = avdheshAccount.ContactTrie.AllWordsWithPrefix("6610448270");






        }
    }
}
