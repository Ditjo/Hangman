﻿// See https://aka.ms/new-console-template for more information

namespace Hangman
{
    internal class Program
    {
        static int left = 3;

        static void Main(string[] args)
        {
            //Instantiating different objects 
            string word, guess, AllLetters = "";
            bool win = false, lose = false;
            int count = 0;

            //Title of game 
            Console.SetCursorPosition(left, 2);
            Console.WriteLine("Welcome to Hangman");

            //Calls the main background graphic
            Tools.graphics();

            //calls for a random word
            word = Tools.Word();
            
            //Creats a list and fills it with _ maching the words length
            List<string> guessedWords = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string filler = "_ ";
                guessedWords.Add(filler);
            }

            do
            {
                //input graphic
                Console.SetCursorPosition(left, 11);
                Console.Write("Indtast bogstav: ");

                do
                {
                    //you press a key and it makes it your guess
                    ConsoleKeyInfo letter;
                    letter = Console.ReadKey(true);
                    guess = Convert.ToString(letter.Key);
                    guess = guess.ToUpper();

                }while(guess.Length != 1);

                AllLetters = AllLetters + guess + " ";

                Console.SetCursorPosition(left, 9);
                Console.WriteLine(AllLetters);

                if (word.Contains(guess))
                {
                    win = Tools.Correct(word, guess, guessedWords);
                }
                else
                {
                    count++;
                    lose = Tools.Mistake(count);
                }

                Console.SetCursorPosition(left, 5);
                foreach (var item in guessedWords)
                {
                    Console.Write(item);
                }


            } while (win == false && lose == false);

            Console.SetCursorPosition(left, 13);
            if (win == true)
            {
                Console.WriteLine("You Win");
            }
            else if (lose == true)
            {
                Console.WriteLine("You Lose");
                Console.SetCursorPosition(left, 15);
                Console.WriteLine($"The word was {word}");
            }
            else
            {
                Console.WriteLine("Game Broke");
            }

        }
    }
}