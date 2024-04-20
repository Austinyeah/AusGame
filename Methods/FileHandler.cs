namespace AusGame.Methods;

public class FileHandler
{
    private const string WordsFilePath = "/Users/austin/Desktop/Coursework/AusGame/AusGame/words.txt";

    public string[] LoadWordsFromFile()
    {
        try
        {
            // Load words from a file and return them as an array of strings 
            return File.ReadAllLines(WordsFilePath);
        }
        catch (FileNotFoundException)
        {
            // if the file is not found I exit the program
            Console.WriteLine("Error: Words file not found.");
            Environment.Exit(1);
        }
        catch (IOException e)        
        {
            Console.WriteLine($"Error reading words file: {e.Message}");
            Environment.Exit(1);
        }
        return null;
    }
}