using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallGuardian.Model.Tries
{
    public class ContactTrie
    {
        private TrieNode root;
        private int indexOfSingleChild;

        public ContactTrie()
        {
            root = new TrieNode("");
        }

        public void Insert(string key)
        {
            TrieNode tempParentTrieNode = root;     // The "" will be considered as a parent TrieNode for each number or name's character
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                int asciiIndex = c;
                if (tempParentTrieNode.GetChild(asciiIndex) == null)
                {
                    TrieNode childTrieNode = new TrieNode(c.ToString());     // each digit of a number or name will be considered as a TrieNode
                    tempParentTrieNode.SetChild(asciiIndex, childTrieNode);
                    tempParentTrieNode = childTrieNode;
                }
                else
                {
                    tempParentTrieNode = tempParentTrieNode.GetChild(asciiIndex);
                }
            }
            tempParentTrieNode.SetLeaf(true);      // last character of a number/name will be set as Leaf => which can show end point in a tree
        }

        public Boolean Search(string key)
        {
            TrieNode trieNode = root;
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                int asciiIndex = c;
                if (trieNode.GetChild(asciiIndex) == null)
                {
                    return false;
                }
                else
                {
                    trieNode = trieNode.GetChild(asciiIndex);
                }
            }
            return true;
        }

        public List<string> AllWordsWithPrefix(string prefix)
        {
            TrieNode trieNode = root;
            List<string> allWords = new List<string>();
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                int asciiIndex = c;
                trieNode = trieNode.GetChild(asciiIndex);
            }
            GetSuffixes(trieNode, prefix, allWords);
            return allWords;
        }

        private void GetSuffixes(TrieNode trieNode, string prefix, List<string> allWords)
        {
            if (trieNode == null)
            {
                return;
            }
            if (trieNode.IsLeaf())
            {
                allWords.Add(prefix);
            }

            foreach (TrieNode childTrieNode in trieNode.GetChildren())
            {
                if (childTrieNode == null)
                {
                    continue;
                }
                if (childTrieNode != null)
                {

                }
                string childCharacter = childTrieNode.GetCharacter();
                GetSuffixes(childTrieNode, prefix + childCharacter, allWords);
            }
        }

    }
}
