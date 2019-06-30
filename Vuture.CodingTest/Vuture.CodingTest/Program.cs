using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vuture.CodingTest
{
    class VutureTasks
    {
        // task one
        public int charCounter(char inputLetter, string str)
        {
            int occurances = 0;
            foreach (char letter in str)
            {
                if (inputLetter == letter)
                {
                    occurances++;
                }
            }
            return occurances;
        }

        // task two 
        public Boolean isPalindrome(string str)
        {
            //sanitises input
            str = str.Replace(" ", "").ToLower();
            Regex allowedChars = new Regex("[^a-zA-Z0-9]");
            string stripped = allowedChars.Replace(str, "");

            //reversing the string
            char[] charArray = stripped.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);

            if (stripped == reversed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // task three a
        public string occuranceCount(string[] words, string str)
        {
            string[] split = str.Split(' ');
            Dictionary<string, int> outputDict = new Dictionary<string, int>();
            foreach (string word in words)
            {
                outputDict.Add(word, 0);
                foreach (string comparingWord in split)
                {
                    if (comparingWord.Contains(word))
                    {
                        outputDict[word]++;
                    }
                }
            }

            string output = "";
            int total = 0;
            foreach (KeyValuePair<string, int> item in outputDict)
            {
                output = output + item.Key + ": " + item.Value + ", ";
                total = + item.Value;
            }
            return output + "Total: " + total;
        }
        
        // task three b
        public string censorString(string[] words, string str)
        {
            string[] split = str.Split(' ');
            string outputString = "";
            foreach (string comparingWord in split)
            {

                string outputWord = "";
                foreach (string censor in words)
                {
                    if (comparingWord.ToUpper() == censor.ToUpper())
                    {
                        int length = comparingWord.Count();
                        string censoredWord = comparingWord[0] + new string('$', length - 2) + comparingWord[length - 1];
                        outputWord = censoredWord + ' ';
                        break;
                    }
                    else
                    {
                        outputWord = comparingWord + ' ';
                    }
                }

                outputString = outputString + outputWord;

            }

            return outputString;
        }

        // task three c
        public string censorPali(string str)
        {
            string[] split = str.Split(' ');
            string output = "";
            foreach (string word in split)
            {
                if (isPalindrome(word))
                {
                    int length = word.Count();
                    string censoredWord = word[0] + new string('$', length - 2) + word[length - 1];
                    output = output + censoredWord + ' ';
                    
                }
                else
                {
                    output = output + word + ' ';
                }

            }

            return output;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //all functions are contained with the VutureTasks class
            VutureTasks vt = new VutureTasks();
            
            //task 1 demo
            Console.WriteLine("- - - - - - - - Task one - - - - - - - - ");
            Console.WriteLine(vt.charCounter('e', "I have some cheese"));
            Console.WriteLine(vt.charCounter('a', "I have some cheese"));
            Console.WriteLine(vt.charCounter('s', "I have some cheese"));
            Console.WriteLine();

            //task 2 demo 
            Console.WriteLine("- - - - - - - - Task Two - - - - - - - - ");
            Console.WriteLine(vt.isPalindrome("I have some cheese"));
            Console.WriteLine(vt.isPalindrome("God saved Eva’s dog"));
            Console.WriteLine();

            //task 3 demos
            Console.WriteLine(" - - - - - - - - Task Three A - - - - - - - - ");
            Console.WriteLine(vt.occuranceCount(new string[] { "dog", "cat", "large" }, "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse."));
            Console.WriteLine(vt.occuranceCount(new string[] { "the", "dog", "quick" }, "The quick brown fox jumps over the lazy dog"));
            Console.WriteLine();

            Console.WriteLine(" - - - - - - - - Task Three B - - - - - - - - ");
            Console.WriteLine(vt.censorString(new string[] { "the", "dog", "quick" }, "The quick brown fox jumps over the lazy dog"));
            Console.WriteLine(vt.censorString(new string[] { "dog", "cat", "large" }, "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse."));
            Console.WriteLine();

            Console.WriteLine(" - - - - - - - - Task Three C - - - - - - - - ");
            Console.WriteLine(vt.censorPali("Anna went to vote in the election to fulfil her civic duty"));
            Console.WriteLine(vt.censorPali("Racecar noon level song David"));

            Console.WriteLine();

        }
    }
}
