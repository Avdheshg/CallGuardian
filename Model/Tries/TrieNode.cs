using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallGuardian.Model.Tries
{
    public class TrieNode
    {
        public static readonly int ALPHABET_SIZE = 256;

        private string character;
        private TrieNode[] children;
        private Boolean leaf;
        private Boolean visited;

        public TrieNode(string _character)
        {
            character = _character;
            children = new TrieNode[ALPHABET_SIZE];
        }

        public void SetChild(int index, TrieNode trieNode)
        {
            children[index] = trieNode;
        }

        public string GetCharacter()
        {
            return character;
        }

        public void SetCharacter(string _character)
        {
            character = _character;
        }

        public TrieNode[] GetChildren()
        {
            return children;
        }

        public void SetChildren(TrieNode[] _children)
        {
            children = _children;
        }

        public Boolean IsLeaf()
        {
            return leaf;
        }

        public void SetLeaf(Boolean _leaf)
        {
            leaf = _leaf;
        }

        public Boolean IsVisited()
        {
            return visited;
        }

        public void SetVisited(Boolean _visited)
        {
            visited = _visited;
        }

        public TrieNode GetChild(int index)
        {
            return children[index];
        }
    }
}
