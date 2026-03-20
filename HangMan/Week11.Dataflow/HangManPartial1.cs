// See https://aka.ms/new-console-template for more information

using System.Text;


// This class is dedicated for application logic
namespace Week11.Dataflow;

public partial class HangMan
{
    private int _numberOfGuesses;
    public int RemainingGuesses { get; set; }
    
    private StringBuilder _guessedWordSoFar;
    private HashSet<char> _userInputChars;
    private string _randomWord;
    private char _lastInputChar;
    public bool LooseFlag;
    
    //overloading constructor
    
    private HangMan(int numberOfGuesses)
    {
        this._numberOfGuesses = numberOfGuesses;
        this.RemainingGuesses = numberOfGuesses;
        this._guessedWordSoFar = new StringBuilder();
        _userInputChars = new HashSet<char>();
        this._randomWord=this.FetchRandomWord();
        LooseFlag=false;
    }
   
    private HangMan(string randomWord,int numberOfGuesses)
    {
        this._numberOfGuesses = numberOfGuesses;
        this.RemainingGuesses = numberOfGuesses;
        this._guessedWordSoFar = new StringBuilder();
        _userInputChars = new HashSet<char>();
        this._randomWord = randomWord;
        this._guessedWordSoFar.Append(new string('-',this._randomWord.Length));
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
        if (string.Equals(this._guessedWordSoFar.ToString(),this._randomWord,StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }
    public bool CheckFullWordSolved(string fullWord)
    {
        if (string.Equals(fullWord,this._randomWord,StringComparison.OrdinalIgnoreCase))
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
            Console.WriteLine("The word was: "+ this._randomWord);
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
        List<int> charAllOccurrences=new ();
        _randomWord=_randomWord.ToLower();
        for (int i = 0;i<_randomWord.Length;i++)
        {
            if (_randomWord[i]==lastInputChar)
            {
                charAllOccurrences.Add(i);
            }
        }
        return charAllOccurrences;
    }

    public bool IsCorrectGuess( )
    {
        List<int> indexesOfCharInTargetWord = GetAllOccurencesInTargetWod(_lastInputChar);

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
            _guessedWordSoFar[elementIndex] = _lastInputChar;
            
        }
        return true;
    }
    public bool CheckPreviousInputs(char userChar)
    {
        if (this._userInputChars.Add(userChar))
        {
            return false;
        }
        return true;
    }

    public void SetGuessChar(char inputGuessChar)
    {
        inputGuessChar = char.ToLower(inputGuessChar);
        _lastInputChar = inputGuessChar;
    }

    

    private string FetchRandomWord()
    {
        _guessedWordSoFar=new StringBuilder();
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
        this._guessedWordSoFar.Append(new string('-',targetWord.Length));
        
        
        return targetWord;
    }
    
}