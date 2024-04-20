namespace AusGame.Methods;
using System.Text;
public class Messages
{
    public void DisplayGameInfo(StringBuilder guessedWord, int attemptsLeft)
    {
        Console.WriteLine($"Guess the word: {guessedWord}");
        Console.WriteLine($"Attempts left: {attemptsLeft}");
    }
    
    public void DisplayGameWon(int attemptsLeft, StringBuilder guessedWord)
    {
        Console.WriteLine("\n\n=============== Word Guess World ===============\n");
        Console.WriteLine($"Correct! \nYou guessed the word! {guessedWord}");
        if (attemptsLeft == 10)
        {
            Console.WriteLine("Your score: 100% \nExcellent Performance\n");
        }
        
        else if (attemptsLeft >= 8)
        {
            Console.WriteLine("Your score: 90% \nExcellent Performance\n");
        }
        
        else if(attemptsLeft>=7)
        {
            Console.WriteLine("Your score : 70% \nVery Good Performance\n");
        }
        else if(attemptsLeft>=6)
        {
            Console.WriteLine("Your Score:60% \nGood Performance\n");
        }
        else if(attemptsLeft>=5)
        {
            Console.WriteLine("Your Score: 45% \nSatisfactory Performance\n");
        }
        else if(attemptsLeft>=4)
        {
            Console.WriteLine("Your Score: 30% \nUnsatisfactory Performance\n");
        }
        else
        {
            Console.WriteLine("Your Score: 10% \nPoor Performance\n");
        }
    }
}