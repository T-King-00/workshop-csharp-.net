using System.Text;

namespace Week11.Dataflow;


//This class is dedicated for UI logic . (Console messages, etc.)

public partial class HangMan
{
    public void StartGame()
    {
        Console.WriteLine("  \t Welcome To Hangman Game ");
        Console.WriteLine("------------------------------------------");
    }
    
    public void EndGame()
    {
        Console.WriteLine("------------------------------------------");
    }


    public void CFetchRandomWord()
    {
        Console.WriteLine("Fetching a random word please wait   ...");
        Thread.Sleep(1000);
        Console.WriteLine("Random word is chosen");
    }

    public char GetUserInputAsOneChar()
    {
        Console.WriteLine("Guess a new Letter");
        char inputNewGuessChar = Console.ReadKey().KeyChar;
        return inputNewGuessChar;
    }
    public string GetUserInputAsFullWord()
    {
        Console.WriteLine("Guess the whole word");
        string inputNewGuessFullWord = Console.ReadLine();
        return inputNewGuessFullWord;
    }
    public void CHandleUserGuess()
    {   
        char userChoice=CGuessFullWordOrGuessLetter();
      
        char inputNewGuessChar='0';
        
        //full word or single letter
        if (userChoice == 'f')
        {
            string inputNewGuessFullWord=GetUserInputAsFullWord();
            //check if the user entered the right word or not
            _guessedWordSoFar = new StringBuilder();
            _guessedWordSoFar.Append(inputNewGuessFullWord);
            bool isRightGuess=CheckSolved();
            if (!isRightGuess)
            {
                LooseFlag=true;
            }
            CprintCheckGuessMessages(isRightGuess);
           
            return;
        }
        
        // single letter scenario
        if (userChoice == 's')
        {
            inputNewGuessChar = GetUserInputAsOneChar();

            SetGuessChar(inputNewGuessChar.ToString().ToLower()[0]);
            //entered previously or not
            if (CheckPreviousInputs(inputNewGuessChar))
            {
                Console.WriteLine("You already guessed this letter before , Try another Letter.");
            }
            else
            {    //right guess or wrong guess
                bool correctGuess = IsCorrectGuess();
                CprintCheckGuessMessages(correctGuess);
            }
            
        }
        
    }

    private void CprintCheckGuessMessages(bool isRightGuess)
    {
        if (isRightGuess)
        {
            Console.WriteLine("\nCorrect guess. "+_guessedWordSoFar );
        }
        else
        {
            Console.WriteLine("\n Wrong guess. " );
        }
    }

    private char CGuessFullWordOrGuessLetter()
    {
        Console.WriteLine("Do you want to guess fulllword or letter? \n" +
                          "Please enter the number of your choice ? \n" +
                          "1-full word , 2-single letter ");
        try
        {
            char x = Console.ReadKey().KeyChar;
            int userChoice;
            if (char.IsDigit(x))
            {
                userChoice= Int32.Parse(x.ToString());
            }
            else userChoice= '0';
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("\nYou chose to guess full word");
                    return 'f';
                    break;
                case 2:
                    Console.WriteLine("\nYou chose to guess single letter");
                    Console.WriteLine("Previously used letters are :" + string.Join(",",_userInputChars) );
                    return 's';
                    break;
                default:
                    Console.WriteLine("\nWrong choice , please try again");
                    CGuessFullWordOrGuessLetter();
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return '0';
    }

    public void CPrintResults(bool solved)
    {
        Console.WriteLine("------------------------------------------");
       
       
        if (!solved && RemainingGuesses==0)
        {
            Console.WriteLine("You lost the game :( ");
            Console.WriteLine("The word was: "+ this._randomWord);
        }

        if (!solved && LooseFlag == true)
        {
            Console.WriteLine("You lost the game :( ");
            Console.WriteLine("The word was: "+ this._randomWord);
        }
        else if (solved )
        {
            Console.WriteLine("You won the game :) ");
        }
        
    }


    
    

}