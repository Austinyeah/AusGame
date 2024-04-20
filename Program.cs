using AusGame.Methods;

class WordGuess
{
    // Entry point of the program
    static void Main(string[] args)
    {
        GameLogic mainGameLogic = new();
        mainGameLogic.RunGame();
    }
}