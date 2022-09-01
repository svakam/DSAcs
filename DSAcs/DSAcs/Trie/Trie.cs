using System;
using DSAcs.Nodes;
using System.Collections.Generic;

namespace DSAcs.Trie
{
    public class Trie
    {
        private TrieNode Root { get; set; }
        public Trie()
        {
            Root = new TrieNode();
        }


        public void Insert(string word)
        {
            TrieNode curr = Root;
            
            for (int i = 0; i < word.Length; i++)
            {
                if (curr.Children.ContainsKey(word[i]))
                {
                    curr = curr.Children[word[i]];
                }
                else
                {
                    curr.Children.Add(word[i], new TrieNode());
                }
            }
        }
    }
}