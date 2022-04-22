using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Tools
    {
        static int left = 3;
        static internal string Word()
        {
            //string as a return
            string word;

            //A list is created
            //The items from a string-array is inserted into the list.
            List<string> words = new List<string>();
            string[] wordsArray = { "Cat","Mars","Sheriff","Hamster","Horse","Titanic",
            "Japan","SpaceX","Zebra","Pizza","York","Carthage","Cree","Whale","Wellington",
            "Painting","Nuuk","Cow","Squid","Attenborough","Pen","Cola","Paper","Locomotive"};
            words.AddRange(wordsArray);

            //A randomiser is created. It is as large as the number of items in the list.
            Random num = new Random();
            word = words[num.Next(words.Count)];
            word = word.ToUpper();
            //It picks a random item(word) from the list and return it.

            //The words length is spelled out using _
            Console.SetCursorPosition(left, 5);
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write("_ ");
            }
            return word;
        }
        
        static internal void graphics()
        {
            //Graphic method. 
            int gpu = 35;
            Console.SetCursorPosition(gpu, 2);
            Console.WriteLine(" _________\n");
            Console.SetCursorPosition(gpu, 3);
            Console.WriteLine(" |/      |\n");
            Console.SetCursorPosition(gpu, 4);
            Console.WriteLine(" |\n");
            Console.SetCursorPosition(gpu, 5);
            Console.WriteLine(" |\n");
            Console.SetCursorPosition(gpu, 6);
            Console.WriteLine(" |\n");
            Console.SetCursorPosition(gpu, 7);
            Console.WriteLine("_|_");
        }
        static internal bool Correct(string word, string guess, List<string> guessedWords)
        {
        //If a letter is correct
            
            //The Word and guess is convertet into char
            char[] charWord = word.ToCharArray();
            char charGuess = Convert.ToChar(guess);

            //looks for an replaces the letter that was correct
            for (int i = 0; i < word.Length; i++)
            {
                if (charWord[i] == charGuess)
                {
                    guessedWords.RemoveAt(i);
                    guessedWords.Insert(i, guess + " ");
                }
            }
            //If there are no more _ the word is done and you win (sets to true).
            if (guessedWords.Contains("_ "))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        static internal bool Mistake(int count)
        {
        //if the letter is wrong 
            //gpu is for use in graphics
            int gpu = 44;

            //it counts and draws the graphics on by one.
            if(count == 1)
            {
                Console.SetCursorPosition(gpu, 4);
                Console.WriteLine("o");
                return false;
            }
            else if (count == 2)
            {
                Console.SetCursorPosition(gpu, 5);
                Console.WriteLine("|");
                return false;
            }
            else if (count == 3)
            {
                Console.SetCursorPosition(gpu-1, 5);
                Console.WriteLine("/");
                return false;
            }
            else if (count == 4)
            {
                Console.SetCursorPosition(gpu+1, 5);
                Console.WriteLine("\\");
                return false;
            }
            else if (count == 5)
            {
                Console.SetCursorPosition(gpu-1, 6);
                Console.WriteLine("/");
                return false;
            }
            else if (count == 6)
            {
                //if it counts to 6 you are dead.
                Console.SetCursorPosition(gpu+1, 6);
                Console.WriteLine("\\");
                return true;
            }
            else
            {
                //incase something happens here.
                Console.WriteLine("Game Broke");
                return true;
            }
            
        }
    }
}
