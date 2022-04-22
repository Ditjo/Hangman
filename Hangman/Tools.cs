using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Tools
    {
        static internal string Word()
        {
            //string as a return
            string word;

            //A list is created
            //The items from a string-array is inserted into the list.
            List<string> words = new List<string>();
            string[] wordsArray = { "Cat", "Dog", "Bird", "Hamster", "Horse" };
            words.AddRange(wordsArray);

            //A randomiser is created. It is as large as the number of items in the list.
            Random num = new Random();
            word = words[num.Next(words.Count)];
            //It picks a random item(word) from the list and return it.

            for (int i = 0; i < word.Length; i++)
            {
                Console.Write("_ ");
            }
            return word;
        }
        
        static internal bool Correct(string word, string guess, List<string> guessedWords)
        {

            char[] charWord = word.ToCharArray();
            char charGuess = Convert.ToChar(guess);

            for (int i = 0; i < word.Length; i++)
            {
                if (charWord[i] == charGuess)
                {
                    guessedWords.RemoveAt(i);
                    guessedWords.Insert(i, guess + " ");
                }
            }
            if (guessedWords.Contains("_ "))
            {
                return false;
            }
            else
            {
                return true;
            }
            
            //foreach (var item in guessedWords)
            //{
            //    Console.Write(item);
            //}

        }
        static internal bool Mistake(int count)
        {
            
            

            Console.WriteLine(count);

            if(count == 1)
            {
                Console.WriteLine("X");
                return false;
            }
            else if (count == 2)
            {
                Console.WriteLine("XX");
                return false;
            }
            else if (count == 3)
            {
                Console.WriteLine("XXX");
                return false;
            }
            else if (count == 4)
            {
                Console.WriteLine("XXXX");
                return false;
            }
            else if (count == 5)
            {
                Console.WriteLine("XXXXX");
                return false;
            }
            else if (count == 6)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Game Broke");
                return true;
            }
            
        }
    }
}
