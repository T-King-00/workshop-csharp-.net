using Week11.Dataflow;
using static System.DateTime;

Console.WriteLine(Now);


HangMan game = HangMan.CreateWithWordGiven("development",10);

game.StartGame();

game.CFetchRandomWord();

while (true)
{
    game.CHandleUserGuess();
    
    bool solved=game.CheckSolved();
    game.CPrintResults(solved);
    if (game.RemainingGuesses ==0 || game.LooseFlag )
    {
        break;
    }
    
    if (solved )
    {
        break;
    }
    if (!solved)
    {
        game.CPrintResults(solved);
    }
    
}



