/*
 * Jesse Hauck
 * March 24, 2020
 * 
 * This program gets two words
 * from the user and tells them
 * if the words are anagrams
 */

using System;
using static System.Console;
using System.Text.RegularExpressions;

namespace Anagram_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            // four strings, two for input and two
            // to hold the normalized strings
            string word1, word2, normWord1, norWord2;

            // getting two words from the user
            WriteLine("Give me two words, and I will tell you if they are anagrams.");
            Write("What is your first word? ");
            word1 = ReadLine();
            Write("What is your second word? ");
            word2 = ReadLine();

            // normalizing the words
            normWord1 = RemoveSpecialChar(word1);
            norWord2 = RemoveSpecialChar(word2);

            // displaying the results
            if (IsAnagram(normWord1, norWord2))
            {
                WriteLine("The words {0} and {1} are anagrams.", word1, word2);
            }
            else
                WriteLine("The words {0} and {1} are not anagrams.", word1, word2);

        }

        // method to remove special characters, spaces, 
        // and make all the letters lowercase
        public static string RemoveSpecialChar(string str)
        {
            str = Regex.Replace(str, "[^a-zA-Z0-9_]+", "");
            return str.ToLower();
        }

        // this method compares the letters in each word
        // to see if they all match
        public static bool IsAnagram(string w1, string w2)
        {
            // integers for the word lengths and matched letters
            int w1Length, w2Length, matched = 0;

            w1Length = w1.Length;
            w2Length = w2.Length;

            if (w1Length != w2Length)
            {
                return false;
            }

            foreach (char item in w1)
            {
                foreach (char item2 in w2)
                {
                    if (item == item2)
                    {
                        ++matched;
                    }
                }
            }

            if (w1Length == matched && w2Length == matched)
            {
                return true;
            }
            else
                return false;
        }
    }
}
