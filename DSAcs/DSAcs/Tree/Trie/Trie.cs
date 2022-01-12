using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Tree.Trie
{
    public class Trie
    {
        public TrieNode Root { get; set; }
        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode curr = Root;
            int n = word.Length;
            for (int i = 0; i < n; i++)
            {
                char c = word[i];

                // check if curr char exists at given iteration through trie
                // if not, add it as new k-v in map with a new pointer
                // curr moves to new pointer if creating new,
                // or moves to next char's TrieNode if that char existed in Trie already
                TrieNode node = curr.Children[c];
                if (node == null)
                {
                    node = new TrieNode();
                    curr.Children.Add(c, node);
                }
                curr = node;
            }
        }


    }
}
