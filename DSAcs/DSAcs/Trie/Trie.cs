using System;
using DSAcs.Nodes;
using System.Collections.Generic;

namespace DSAcs.Trie
{
    public class Trie
    {
        private TrieNode Root { get; set; }
        public Trie() { }
        public Trie(TrieNode root)
        {
            Root = root;
        }

        public void Insert(char letter)
        {
            if (Root == null)
            {
                Root = new TrieNode();
                Root.Children.Add(letter, new TrieNode());
            }
            else
            {

            }
        }
    }
}