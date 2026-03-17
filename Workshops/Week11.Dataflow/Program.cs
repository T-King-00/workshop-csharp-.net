// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Text;

public class Hangman
{
    private int numberOfGuesses;
    public int remainingGuesses;
    public StringBuilder guessedWord;
    private HashSet<char> guessedChars;
    private string randomWord;
    public char lastInputChar;
    
    //overloading constructor
    public Hangman(int numberOfGuesses)
    {
        this.numberOfGuesses = numberOfGuesses;
        this.remainingGuesses = numberOfGuesses;
        this.guessedWord = new StringBuilder();
        guessedChars = new HashSet<char>();
        this.randomWord=this.FetchRandomWord();
    }
    public Hangman(string randomWord,int numberOfGuesses)
    {
        this.numberOfGuesses = numberOfGuesses;
        this.remainingGuesses = numberOfGuesses;
        this.guessedWord = new StringBuilder();
        guessedChars = new HashSet<char>();
        this.randomWord = randomWord;
        Console.WriteLine("Computer is thinking of a new random word. Please wait..");
        this.guessedWord.Append(new string('-',this.randomWord.Length));
        Console.WriteLine("Random word is chosen");

    }
    

    public static void Main(string[] args)
    {
        Hangman game = new Hangman(10);
        
        game.StartGame();
        
        bool solved = true;
        while (true)
        {
            if(game.checkSolved())
                break;
            game.GetUserInputCharFromConsole();
          
            
            game.TryAGuess();
            if (game.remainingGuesses == 0)
            {
                solved = false;
                break;
            }

        }
        game.Result(solved);
        
    }

    private bool checkSolved()
    {
        if (guessedWord.ToString() == randomWord.ToString())
        {
            Console.WriteLine("You won the game :) ");
            Result(true);
            return true;
        }
        return false;
    }

    public bool CheckPreviousInputs(char inputChar)
    {
        if (this.guessedChars.Contains(inputChar))
        {
            Console.WriteLine("\nYou have already guessed this letter");
            return true;
        }
        else
        {
            this.guessedChars.Add(inputChar);
            return false;
        }
        
    }

    public int UpdateCountRemainingGuesses(bool resGuess)
    {
        if (!resGuess)
        {
            remainingGuesses--;
        }

      
        return remainingGuesses;
    }
    
    public void Result(bool solved)
    {
        Console.WriteLine("Entered chars are "+ string.Join(",",this.guessedChars));
        if (!solved)
        {
            Console.WriteLine("You lost the game :( ");
            Console.WriteLine("The word was: "+ this.randomWord);
        }
        else
        {
            Console.WriteLine("You won the game :) ");
        }
        
    }
    
    public bool TryAGuess( )
    {
        if (guessedWord.ToString() != randomWord.ToString() && checkRemaingingGuessesCount() == "lost")
        {
            return false;
        }
        
        Console.WriteLine("\nPrevious guesses: "+ string.Join(",",guessedChars));
        Console.WriteLine($"* You have {remainingGuesses} guesses left ;; Guess a new letter");
        
        //GetUserInputCharFromConsole();
  
        if(CheckPreviousInputs(lastInputChar))
            return false;
        
        
        
        int index = this.randomWord.IndexOf(lastInputChar);
        
        if (index == -1)
        {
            Console.WriteLine("\nYou guessed wrong");
            UpdateCountRemainingGuesses(false);
            Console.WriteLine("################################");

            return false;
        }
        else
        {
            Console.WriteLine("\nYou guessed right");
            guessedWord[index] = (char) lastInputChar;
            Console.WriteLine(guessedWord); 
            Console.WriteLine("################################");
            return true;
        }

    }

    private string checkRemaingingGuessesCount()
    {
        if (remainingGuesses == 0)
        {
            Console.WriteLine("You lost the game :( ");
            Console.WriteLine("The word was: "+ this.randomWord);
            return "lost";
        }

        return "";
    }

    //for testing purpose , separation of concerns
    public void SetInputChar(char inputChar)
    {
        lastInputChar = inputChar;
        
    }
    public void GetUserInputCharFromConsole()
    {
        Console.WriteLine("Previous guesses: "+ string.Join(",",guessedChars));
        Console.WriteLine("Guess a letter:");
        char inputChar = Console.ReadKey().KeyChar;
        SetInputChar(inputChar);
    }

    private string FetchRandomWord()
    {
        Console.WriteLine("Computer is thinking of a new random word. Please wait..");

        guessedWord=new StringBuilder();
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
        
        Console.WriteLine("Random word is chosen");
        return randomWord;
    }
    
    private void StartGame()
    {
        Console.WriteLine("  \t\t Welcome To Hangman Game ");
        Console.WriteLine("--------------------------------");

    }
 

    
   
}