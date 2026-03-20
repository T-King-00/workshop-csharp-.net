// See https://aka.ms/new-console-template for more information

using System.Text;


// This class is dedicated for application logic
namespace Week11.Dataflow;

public partial class HangMan
{
    private int numberOfGuesses;
    public int RemainingGuesses { get; set; }
    
    private StringBuilder GuessedWordSoFar;
    private HashSet<char> UserInputChars;
    private string RandomWord;
    private char lastInputChar;
    public bool LooseFlag;
    
    //overloading constructor
    
    private HangMan(int numberOfGuesses)
    {
        this.numberOfGuesses = numberOfGuesses;
        this.RemainingGuesses = numberOfGuesses;
        this.GuessedWordSoFar = new StringBuilder();
        UserInputChars = new HashSet<char>();
        this.RandomWord=this.FetchRandomWord();
        LooseFlag=false;
    }
   
    private HangMan(string randomWord,int numberOfGuesses)
    {
        this.numberOfGuesses = numberOfGuesses;
        this.RemainingGuesses = numberOfGuesses;
        this.GuessedWordSoFar = new StringBuilder();
        UserInputChars = new HashSet<char>();
        this.RandomWord = randomWord;
        this.GuessedWordSoFar.Append(new string('-',this.RandomWord.Length));
        LooseFlag=false;

    }
    
    //named factory method
    public static HangMan CreateWithRandomWord( int numberOfGuesses)
    {
        return new HangMan(numberOfGuesses);

    }

    public static HangMan CreateWithWordGiven(string randomWord,int numberOfGuesses)
    {
        return new HangMan(randomWord,numberOfGuesses);
    }
    

    public bool CheckSolved()
    {
        if (string.Equals(this.GuessedWordSoFar.ToString(),this.RandomWord,StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }
    public bool CheckFullWordSolved(string fullWord)
    {
        if (string.Equals(fullWord,this.RandomWord,StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }

    
    private string CheckRemaingingGuessesCount()
    {
        if (RemainingGuesses == 0)
        {
            Console.WriteLine("You lost the game :( ");
            Console.WriteLine("The word was: "+ this.RandomWord);
            return "lost";
        }

        return "";
    }
    
    public int UpdateCountRemainingGuesses(bool resGuess)
    {
        if (resGuess)
        {
            RemainingGuesses--;
        }
        
        return RemainingGuesses;
    }

    public List<int> GetAllOccurencesInTargetWod(char lastInputChar)
    {
        List<int> CharAllOccurrences=new ();
        RandomWord=RandomWord.ToLower();
        for (int i = 0;i<RandomWord.Length;i++)
        {
            if (RandomWord[i]==lastInputChar)
            {
                CharAllOccurrences.Add(i);
            }
        }
        return CharAllOccurrences;
    }

    public bool IsCorrectGuess( )
    {
        List<int> indexesOfCharInTargetWord = GetAllOccurencesInTargetWod(lastInputChar);

        if (indexesOfCharInTargetWord.Count<= 0)
        {
            //wrong guess, no letter matches the last user guess.
            //therefore update the remaining guesses count.
            UpdateCountRemainingGuesses(true);
            return false;
        }


        foreach (int elementIndex in indexesOfCharInTargetWord)
        {
            //right guess doesn't update the remaining guesses count.
            UpdateCountRemainingGuesses(false);
            GuessedWordSoFar[elementIndex] = lastInputChar;
            
        }
        return true;
    }
    public bool CheckPreviousInputs(char userChar)
    {
        if (this.UserInputChars.Add(userChar))
        {
            return false;
        }
        return true;
    }

    public void SetGuessChar(char inputGuessChar)
    {
        inputGuessChar = char.ToLower(inputGuessChar);
        lastInputChar = inputGuessChar;
    }

    

    private string FetchRandomWord()
    {
        GuessedWordSoFar=new StringBuilder();
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
        string targetWord = secretWords[new Random().Next(secretWords.Length)];
        this.GuessedWordSoFar.Append(new string('-',targetWord.Length));
        
        
        return targetWord;
    }
    
}