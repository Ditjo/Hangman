// See https://aka.ms/new-console-template for more information

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word, guess, AllLetters = "";
            //char letter;
            //char letter;

            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("");

            word = Tools.Word();
            word = word.ToUpper();

            List<string> guessedWords = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string filler = "_ ";
                guessedWords.Add(filler);
            }

            bool win = false, lose = false;
            int count = 0;

            do
            {
                Console.WriteLine("");
                Console.Write("Indtast bogstav: ");

                ConsoleKeyInfo letter;
                letter = Console.ReadKey(true);
                guess = Convert.ToString(letter.Key);
                //guess = Console.ReadLine();
                guess = guess.ToUpper();
                Console.WriteLine("");
                AllLetters = AllLetters + guess + " ";
                Console.WriteLine(AllLetters);

                //bool win = false,lose = false;

                if (word.Contains(guess))
                {
                    win = Tools.Correct(word, guess, guessedWords);
                }
                else
                {
                    count++;
                    lose = Tools.Mistake(count);
                }

                foreach (var item in guessedWords)
                {
                    Console.Write(item);
                }
                

            } while (win == false && lose == false);

            if (win == true)
            {
                Console.WriteLine("Winner");
            }
            else if(lose == true)
            {
                Console.WriteLine("Loser");
            }
            else
            {
                Console.WriteLine("Game Broke");
            }
            
            //ConsoleKeyInfo letter;
            //letter = Console.ReadKey(true);
            //if(word.Contains(letter.Key))
            //if (Cho.Key == ConsoleKey.P);
        }
    }
}