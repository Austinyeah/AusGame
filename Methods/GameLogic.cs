using System.Text;

namespace AusGame.Methods;

public class GameLogic
{
    
    private const string SaveStateFilePath = "/Users/austin/Desktop/Coursework/AusGame/AusGame/savestate.txt";
    private const int MaxAttempts = 10;
    private string secretWord;
    private int attemptsLeft;
    private StringBuilder guessedWord;

    readonly RandomPicker _randomPicker = new();
    readonly FileHandler _fileHandler = new();
    readonly GameSettings _gameSettings = new();
    readonly Messages _messages = new();
    readonly InputProcessor _inputProcessor = new();

    private void InitializeGame(string gameMode)
    {
        // I am loading the words from a file and then selecting a random word from the list of words 
        string[] words = _fileHandler.LoadWordsFromFile();
        secretWord = _randomPicker.SelectRandomWord(words, gameMode);
        
        // I am initializing the guessed word to be a string of underscores with the same length as the secret word
        guessedWord = new StringBuilder(new string('_', secretWord.Length));
        attemptsLeft = MaxAttempts;
    }
    
    // Save current game state to a file
    private void SaveGameState()
    {
        try
        {
            // I am saving the state of the game into a file for easy retrieval 
            using (StreamWriter writer = new StreamWriter(SaveStateFilePath))
            {
                writer.WriteLine(secretWord);
                writer.WriteLine(attemptsLeft);
                writer.WriteLine(guessedWord);
            }
        }
        catch (IOException e)
        {
            // if there are errors while saving the game state I catch it here but into the console
            Console.WriteLine($"Error saving game state: {e.Message}");
        }
    }
    private void LoadGameState()
    {
        try
        {
            // I am loading the state of the game from a file 
            // I am using the same file I used to save the game state
            string[] savedState = File.ReadAllLines(SaveStateFilePath);
            secretWord = savedState[0];
            attemptsLeft = int.Parse(savedState[1]);
            guessedWord = new StringBuilder(savedState[2]);
        }
        // I am catching the errors that might occur while loading the game state 
        catch (FileNotFoundException)
        {
            Console.WriteLine("No saved game state found.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading saved game state: {e.Message}");
        }
    }
    
    private bool IsGameWon()
    {
        return guessedWord.ToString() == secretWord;
    }
    
    public void RunGame()
    {
        // I am loading the settings from a file if there are any
        // Then I am loading the game state if there is any
        // Then I am initializing the game
        bool validModeSelected = false;
        _gameSettings.LoadSettings();
        LoadGameState();
        _gameSettings.Greeter();
        
        while(!validModeSelected)
        {
            Console.WriteLine("\nSelect game mode: (easy, medium, hard)");
            string selectedMode = Console.ReadLine().ToLower();
            InitializeGame(selectedMode);
            if (selectedMode == "easy" || selectedMode == "medium" || selectedMode == "hard")
            {
                // Pass the selected game mode to InitializeGame method
                InitializeGame(selectedMode);
                validModeSelected = true; // Set flag to exit the loop
            }
            else
            {
                Console.WriteLine("Invalid game mode. Check game modes in the bracket below!.\n");
            }
        }
        
        // I added a while loop to keep the game running until the player wins or loses
        while (attemptsLeft > 0 && !IsGameWon())
        {
            _messages.DisplayGameInfo(guessedWord, attemptsLeft);
            
            Console.Write($"Hint: length of word is {secretWord.Length} \n\nEnter a letter to guess: ");
            string userInput = Console.ReadLine();
            
            // I added a method to process the input from the player and update the game state
            _inputProcessor.ProcessInput(userInput, ref attemptsLeft, ref guessedWord, secretWord);
            SaveGameState();
        }

        if (IsGameWon())
        {
            _messages.DisplayGameWon(attemptsLeft, guessedWord);
            _gameSettings.Goodbye();
        }
        else
        {
            Console.WriteLine($"Sorry, you've run out of attempts. The word was: {secretWord}");
        }
    }
    
}