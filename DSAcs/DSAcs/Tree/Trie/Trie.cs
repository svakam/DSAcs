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
            curr.EndOfWord = true; // end of word when moving to last char's next must be marked as true
        }

        public void InsertRecur(string word)
        {
            InsertRecursive(Root, word, 0);
        }
        public void InsertRecursive(TrieNode curr, string word, int charIndex)
        {
            // base case: end of word
            if (charIndex == word.Length)
            {
                curr.EndOfWord = true;
            }

            // recursion
            char c = word[charIndex];
            TrieNode node = curr.Children[c];
            if (node == null)
            {
                curr.Children.Add(c, node);
            }

            InsertRecursive(curr, word, charIndex + 1);
        }

        public bool Search(string word)
        {
            TrieNode curr = Root;
            int n = word.Length;
            for (int i = 0; i < n; i++)
            {
                char c = word[i];
                TrieNode node = curr.Children[c];
                if (node == null) return false;
                curr = node;
            }
            return curr.EndOfWord; // ensures end of word after iterated through word
        }

        public bool SearchRecursive(string word)
        {
            return SearchRecursive(Root, word, 0);
        }
        public bool SearchRecursive(TrieNode curr, string word, int charIndex)
        {
            if (charIndex == word.Length) return curr.EndOfWord;

            char c = word[i];
            TrieNode node = curr.Children[c];
            if (node == null)
            {
                return false;
            }
            return SearchRecursive(curr, word, charIndex + 1);
        }
    }
}
