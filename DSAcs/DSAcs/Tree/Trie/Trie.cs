using System;
using DSAcs.Nodes;
using System.Collections.Generic;

namespace DSAcs.Tree.Trie
{
    public class Trie
    {
        //private TrieNode Root { get; set; }
        private TrieNodeArr RootA { get; set; }
        public Trie()
        {
            //Root = new TrieNode();
            RootA = new TrieNodeArr('\0');
        }


        //public void Insert(string word)
        //{
        //    TrieNode curr = Root;

        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        if (curr.Children.ContainsKey(word[i]))
        //        {
        //            curr = curr.Children[word[i]]; // go to current's next letter
        //        }
        //        else
        //        {
        //            TrieNode next = new();
        //            if (i == word.Length - 1) next.EndOfWord = true; // if last letter, next trienode eow true

        //            curr.Children.Add(word[i], next); // add letter to this trienode 
        //            curr = next;
        //        }
        //    }
        //}

        //public bool Search(string wordOrPrefix, bool fullWordReqd)
        //{
        //    TrieNode curr = Root;

        //    int i = 0;
        //    while (i < wordOrPrefix.Length)
        //    {
        //        if (curr.Children.ContainsKey(wordOrPrefix[i]))
        //        {
        //            curr = curr.Children[wordOrPrefix[i]];
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    return fullWordReqd && curr.EndOfWord;
        //}

        // children as array
        /// <summary>
        /// Uses the current node to check if letter exists. If not, inserts new node here. Moves onto next character, and if end of word, marks last node as such. 
        /// </summary>
        /// <param name="word"></param>
        public void Insert(string word)
        {
            TrieNodeArr curr = RootA;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (curr.Children[c - 'a'] == null)
                {
                    curr.Children[c - 'a'] = new TrieNodeArr(c);
                }
                curr = curr.Children[c - 'a'];
            }
            curr.IsWord = true;
        }

        /// <summary>
        /// Returns whether entire word exists in trie (last node exists and is a word at this node).
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Search(string word)
        {
            TrieNodeArr node = GetNode(word);
            return node != null && node.IsWord;
        }

        /// <summary>
        /// Returns whether this prefix exists in trie (doesn't matter if end of word).
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool StartsWith(string prefix)
        {
            return GetNode(prefix) != null;
        }

        private TrieNodeArr GetNode(string word)
        {
            TrieNodeArr curr = RootA;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (curr.Children[c - 'a'] == null) return null;
                curr = curr.Children[c - 'a'];
            }
            return curr;
        }
    }
}