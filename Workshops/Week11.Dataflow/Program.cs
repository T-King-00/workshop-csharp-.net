// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Text;

public class Hangman
{
    int numberOfGuesses;
    public int remainingGuesses;
    public StringBuilder guessedWord;

    public Hangman(int numberOfGuesses)
    {
        this.numberOfGuesses = numberOfGuesses;
        this.remainingGuesses = numberOfGuesses;
        this.guessedWord = new StringBuilder();
    }
    

    public static void Main(string[] args)
    {
        Hangman game = new Hangman(10);
        
        game.startGame();
        
        Console.WriteLine("Computer is thinking of a new random word. Please wait..");
        string random_word= game.fetchRandomWord();
        Console.WriteLine("Random word is chosen");
        
        Console.WriteLine("You have 10 guesses");

        
        StringBuilder inputChars= new StringBuilder();

        
        bool solved = true;
        while (true)
        {
            char inputChar=game.getInputChar();
            inputChars.Append(inputChar);

            bool resGuess=game.TryAGuess(random_word,inputChar);
            game.UpdateCountRemainingGuesses(resGuess);
            
            
            if (game.remainingGuesses == 0)
            {
                solved = false;
                break;
            }


        }
        game.result(solved);

       







    }

    public int UpdateCountRemainingGuesses(bool resGuess)
    {
        if (!resGuess)
        {
            remainingGuesses--;
        }
        
        return remainingGuesses;
    }

  

    public void result(bool solved)
    {
        if (!solved)
        {
            Console.WriteLine("You lost the game :( ");
        }
        else
        {
            Console.WriteLine("You won the game :) ");
        }
        
    }

    public char getInputChar()
    {
        Console.WriteLine("Guess a letter:");
        char inputChar = Console.ReadKey().KeyChar;
        return inputChar;
    }

  

    public bool TryAGuess(string randomWord,char inputChar)
    {
        
        int index = randomWord.IndexOf(inputChar);
            
            if (index == -1)
            {
                Console.WriteLine("\nYou guessed wrong");
                return false;
            }
            else
            {
                Console.WriteLine("\nYou guessed right");
                guessedWord[index] = inputChar;
                Console.WriteLine(guessedWord);
                return true;
            }
    }
   private string fetchRandomWord()
    {
        Thread.Sleep(1000);
        string[] secretWords = {
            "computer",
            "programming",
            "keyboard",
            "internet",
            "variable",
            "function",
            "compiler",
            "algorithm",
            "database",
            "developer"
        };
        string randomWord = secretWords[new Random().Next(secretWords.Length)];
        this.guessedWord.Append(new string('-',randomWord.Length));
        return randomWord;
    }
    private void startGame()
    {
        Console.WriteLine("  \t\t Welcome To Hangman Game ");
        Console.WriteLine("--------------------------------");
    }
 

    
   
}