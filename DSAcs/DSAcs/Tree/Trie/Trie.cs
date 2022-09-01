using System;
using DSAcs.Nodes;
using System.Collections.Generic;

namespace DSAcs.Tree.Trie
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
                    curr = curr.Children[word[i]]; // go to current's next letter
                }
                else
                {
                    TrieNode next = new();
                    if (i == word.Length - 1) next.EndOfWord = true; // if last letter, next trienode eow true

                    curr.Children.Add(word[i], next); // add letter to this trienode 
                    curr = next;
                }
            }
        }

        // abc, b
        // curr = new3T
        // root = {<a, new1>}, F
        // new1 = {<b, new2>}, F
        // new2 = {<c, new3T}, F
        // new3T = { }, T
    }
}