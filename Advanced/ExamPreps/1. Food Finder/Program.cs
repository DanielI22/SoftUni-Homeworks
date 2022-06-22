using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input1 = Console.ReadLine().Replace(" ","").ToCharArray();
            char[] input2 = Console.ReadLine().Replace(" ", "").ToCharArray();
            Queue<char> vowels = new Queue<char>(input1);
            Stack<char> consonants = new Stack<char>(input2);

            List<string> foundWords = new List<string>();
            HashSet<char> currentChars = new HashSet<char>();

            bool pearAdded = false;
            bool flourAdded = false;
            bool porkAdded = false;
            bool oliveAdded = false;

            while(consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                currentChars.Add(currentVowel);
                currentChars.Add(currentConsonant);

                if (currentChars.Contains('p') && currentChars.Contains('e') && currentChars.Contains('a') && currentChars.Contains('r') && !pearAdded)
                {
                   
                    pearAdded = true;
                }
                if (currentChars.Contains('f') && currentChars.Contains('l') && currentChars.Contains('o') && currentChars.Contains('u') && currentChars.Contains('r') && !flourAdded)
                {
                    
                    flourAdded = true;
                }
                if (currentChars.Contains('p') && currentChars.Contains('o') && currentChars.Contains('r') && currentChars.Contains('k') && !porkAdded)
                {
                   
                    porkAdded=true;
                }
                if (currentChars.Contains('o') && currentChars.Contains('l') && currentChars.Contains('i') && currentChars.Contains('v') && currentChars.Contains('e') && !oliveAdded)
                {
           
                    oliveAdded = true;
                }

                vowels.Enqueue(currentVowel);
            }


            if(pearAdded)
            {
                foundWords.Add("pear");
            }
            if (flourAdded)
            {
                foundWords.Add("flour");
            }
            if (porkAdded)
            {
                foundWords.Add("pork");
            }
            if (oliveAdded)
            {
                foundWords.Add("olive");
            }

            Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
