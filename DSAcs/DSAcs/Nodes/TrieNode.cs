using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Nodes
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool EndOfWord { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            EndOfWord = false;
        }

        public TrieNode(Dictionary<char, TrieNode> children, bool endOfWord)        
        {
            Children = children;
            EndOfWord = endOfWord;
        }

    }
}
