namespace AusGame.Methods;

public class GameSettings
{
    private const string SettingsFilePath = "/Users/austin/Desktop/Coursework/AusGame/AusGame/settings.txt";
    public string[] LoadSettings()
    {
        try
        {
            // load settings from a file
            string[] settings = File.ReadAllLines(SettingsFilePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Settings file not found.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading settings file: {e.Message}");
        }
        
        return  null;
    }
    
    public void Greeter()
    {
        Console.WriteLine("=============== Word Guess Game ===============");
    }
    
    public void Goodbye()
    {
        Console.WriteLine("======= Thank you for playing our game!! =======");
    }
}