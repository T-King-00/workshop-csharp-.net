namespace testWeek11;
using NUnit.Framework;


public class Tests
{
    private Hangman game;
    [SetUp]
    public void Setup()
    {
         game = new Hangman("development",3);
    }


    [Test]
    public void TryDifferentLetters_whenLetttersareright_returnsTrue()
    {
        game.SetInputChar('d');
        bool res = game.TryAGuess();
        Assert.That(res);


        game.SetInputChar('f');
        res = game.TryAGuess();
        Assert.That(res.Equals(false));

        game.SetInputChar('g');
        res = game.TryAGuess();
        Assert.That(res.Equals(false));
        
        game.SetInputChar('x');
        res = game.TryAGuess();
        Assert.That(res.Equals(false));
        
        game.SetInputChar('z');
        res = game.TryAGuess();
        Assert.That(res.Equals(false));
    }



}