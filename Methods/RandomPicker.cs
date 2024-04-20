namespace AusGame.Methods;

public class RandomPicker
{
    // Selects a random word from an array of words and returns it as a string 
    public string SelectRandomWord(string[] words, string gameMode)
    {
        Random random = new Random();
        int maxLength = int.MaxValue;
        // return words[random.Next(0, words.Length)].ToLower();
        // Set maximum word length based on game mode
        if (gameMode == "easy")
        {
            maxLength = 6;
        }
        else if (gameMode == "medium")
        {
            maxLength = 10;
        }
        else if (gameMode == "hard")
        {
            maxLength = 20;
        }
        else
        {
            Console.WriteLine("Oops!");
        }

        // Filter words based on the specified length
        var filteredWords = words.Where(word => word.Length <= maxLength).ToList();
        // Select a random word from the filtered list
        if (filteredWords.Any())
        {
            return filteredWords[random.Next(0, filteredWords.Count)].ToLower();
        }
        else
        {
            // Handle case when no words match the length criteria
            Console.WriteLine("No word found within the specified game mode.");
            return "You can't play this game.";
        }
    }
}
