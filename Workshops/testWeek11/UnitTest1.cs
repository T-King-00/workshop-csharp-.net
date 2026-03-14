namespace testWeek11;
using NUnit.Framework;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        int numberOfGuesses = 3;
        Hangman Game = new Hangman(numberOfGuesses);
        Game.guessedWord.Append(new string('-',"air".Length));
        bool res=Game.TryAGuess("air",'a');
        Assert.That(res);
        Game.UpdateCountRemainingGuesses(res);
        Console.WriteLine("remaining guesses:"+Game.remainingGuesses);
        
        
        res=Game.TryAGuess("air",'i');
        Assert.That(res==true);
        Game.UpdateCountRemainingGuesses(res);
        Console.WriteLine("remaining guesses:"+Game.remainingGuesses);

        res=Game.TryAGuess("air",'f');
        Assert.That(res==true);
        Game.UpdateCountRemainingGuesses(res);
        Console.WriteLine("remaining guesses:"+Game.remainingGuesses);

        
     

    }
    
    
}