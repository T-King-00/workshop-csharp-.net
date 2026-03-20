using Week11.Dataflow;

namespace testWeek11;
using NUnit.Framework;


public class Tests
{
    private HangMan Game;
    [SetUp]
    public void Setup()
    {
         Game = HangMan.CreateWithWordGiven("Development",3);
    }

    // this test should test 2 functions , giving wrong char (guess) and the update remainin guesses counter.
    [Test]
    public void TestAGuess_whenCharIsWrong_updatesRemainingGuesses()
    {
        //arrange
        char testChar = 'x';
        int? remainingGuessesCount =null;
        bool guessedBefore=false;
        //act
        Game.SetGuessChar(testChar);
        guessedBefore = Game.CheckPreviousInputs(testChar);
        Game.IsCorrectGuess();
        remainingGuessesCount = Game.RemainingGuesses;
        //Assert
        Assert.That(remainingGuessesCount,Is.EqualTo(2));
        Assert.That(guessedBefore,Is.False);
       
    }
    // this test should test 2 features , giving 2 wrong char (guess) in order and the updating remaining guesses counter .
    [Test]
    public void TestAnotherGuess_whenCharIsWrong_updatesRemainingGuesses()
    {
        //arrange
        char testChar = 'y';
        int? remainingGuessesCount =null;
        bool guessedBefore=false;
        
        //act 1
        Game.SetGuessChar(testChar);
        guessedBefore = Game.CheckPreviousInputs(testChar);
        Game.IsCorrectGuess();
        remainingGuessesCount = Game.RemainingGuesses;
        
        //arrange 2
        testChar = 'z';
        //act2
        
        Game.SetGuessChar(testChar);
        guessedBefore = Game.CheckPreviousInputs(testChar);
        Game.IsCorrectGuess();
        remainingGuessesCount = Game.RemainingGuesses;

        
        //Assert
        Assert.That(remainingGuessesCount,Is.EqualTo(1));
        Assert.That(guessedBefore,Is.False);
       
    }





}