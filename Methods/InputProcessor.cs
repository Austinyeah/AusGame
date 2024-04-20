using System.Text;

namespace AusGame.Methods;

public class InputProcessor
{
    public void ProcessInput(string userInput, ref int attemptsLeft, ref StringBuilder guessedWord, string secretWord)
    {
        if (userInput.Length != 1 || !char.IsLetter(userInput[0]))
        {
            Console.WriteLine("Invalid input. Please enter a single letter.");
            return;
        }
    
        char guessedLetter = char.ToLower(userInput[0]);
        bool found = false;
    
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == guessedLetter && guessedWord[i] == '_')
            {
                guessedWord[i] = guessedLetter;
                found = true;
            }
        }
    
        if (!found)
        {
            Console.WriteLine("Incorrect guess!");
            attemptsLeft--;
        }
    }
}