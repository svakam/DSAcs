using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Tree.Trie
{

    // a better (?) implementation via TrieNode array:
    // https://leetcode.com/problems/implement-trie-prefix-tree/discuss/58943/C-implementation
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
                TrieNode node;
                if (curr.Children.ContainsKey(c))
                {
                    node = curr.Children[c];
                }
                else
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
            TrieNode node;
            if (curr.Children.ContainsKey(c))
            {
                node = curr.Children[c];
            }
            else
            {
                node = new TrieNode();
                node.Children.Add(c, node);
            }
            curr = node;

            InsertRecursive(curr, word, charIndex + 1);
        }

        public bool Search(string word)
        {
            TrieNode curr = Root;
            int n = word.Length;
            for (int i = 0; i < n; i++)
            {
                char c = word[i];
                if (!curr.Children.ContainsKey(c))
                {
                    return false;
                }
                TrieNode node = curr.Children[c];
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
            if (!curr.Children.ContainsKey(c))
            {
                return false;
            }
            TrieNode node = curr.Children[c];
            curr = node;
            return SearchRecursive(curr, word, charIndex + 1);
        }

        public void Delete(string word)
        {
            Delete(Root, word, 0);
        }
        public bool Delete(TrieNode curr, string word, int charIndex)
        {
            if (charIndex == word.Length)
            {
                // only delete node if end of word is reached
                if (curr.EndOfWord)
                {
                    return false;
                }

                // since word should be deleted, set end of word to false and return whether map is empty
                // to avoid deleting downstream mappings
                curr.EndOfWord = false;
                return curr.Children.Count == 0;
            }

            char c = word[charIndex];
            if (!curr.Children.ContainsKey(c))
            {
                return false;
            }
            TrieNode node = curr.Children[c];
            bool shouldDeleteCurrNode = Delete(node, word, charIndex + 1);

            if (shouldDeleteCurrNode)
            {
                curr.Children.Remove(c); // remove mapping and also check if no mappings exist
                return curr.Children.Count == 0;
            }

            return false;
        }
    }
}
