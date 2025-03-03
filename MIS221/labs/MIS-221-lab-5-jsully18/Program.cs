// See https://aka.ms/new-console-template for more information
// Snowman_Starter
//***********Start main ***********

int gamesWon = 0;
int gamesLost = 0;

string userInput = GetMenuChoice();
while (userInput != "3")
{
    Route(userInput, ref gamesWon, ref gamesLost);
    userInput = GetMenuChoice();
}

Goodbye(gamesWon, gamesLost);

//************End main*************

static string GetMenuChoice()
{
    DisplayMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoice(userInput))
    {
        Console.WriteLine("Invalid menu choice. Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        DisplayMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("1:   Play Snowman");
    Console.WriteLine("2:   See Scoreboard");
    Console.WriteLine("3:   Exit Game");
}

static bool ValidMenuChoice(string userInput)
{
    return userInput == "1" || userInput == "2" || userInput == "3";
}


static void Route(string userInput, ref int gamesWon, ref int gamesLost)
{
    if (userInput == "1")
    {
        SnowMan(ref gamesWon, ref gamesLost); // Calls the game function
    }
    else if (userInput == "2")
    {
        ScoreBoard(gamesWon, gamesLost); 
    }
}

static void SnowMan(ref int gamesWon, ref int gamesLost)
{
    Console.Clear();
    string word = GetRandomWord();
    char[] displayWord = SetDisplayWord(word);
    int missed = 0;
    string guessed = "";

    while (KeepGoing(displayWord, missed))
    {
        ShowBoard(displayWord, missed, guessed);
        Console.WriteLine();
        try
        {
            char pickedLetter = Console.ReadLine().ToUpper()[0];
            CheckChoice(displayWord, word, ref missed, ref guessed, pickedLetter);
        }
        catch
        {
            Console.WriteLine("Invalid input, please choose at least one character");
            Pause();
        }
    }

    if (missed == 7)
    {
        Console.WriteLine("Sorry you lost");
        gamesLost++;
    }
    else
    {
        Console.WriteLine("You Won!");
        gamesWon++;
    }
    Console.WriteLine("Press any key to continue.....");
    Console.ReadKey();
}

static void CheckChoice(char[] displayWord, string word, ref int missed, ref string guessed, char pickedLetter)
{
    if (LetterInWord(pickedLetter, guessed)){
     Console.WriteLine("You have already guessed that letter!");
        Pause();
        return;
    }
        // Check to see if letter is in word
        if (LetterInWord(pickedLetter, word))
        {
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == pickedLetter)
            {
                displayWord[i] = pickedLetter;
            }
        }
        Console.Clear();
    }
    else
    {
        guessed += pickedLetter;
        missed++;
    }

}

static bool LetterInWord(char letter, string word)
{
    return word.Contains(letter);
}

static bool KeepGoing(char[] displayWord, int missed)
{
     return missed < 7 && displayWord.Contains('_');

}

static void ShowBoard(char[] displayWord, int missed, string guessed)
{
    Console.WriteLine("Word to guess: ");
    for (int i = 0; i < displayWord.Length; i++)
    {
        Console.Write(displayWord[i]);
    }

    Console.WriteLine();
    Console.WriteLine("Letters Guessed => " + guessed);

    Console.WriteLine("Currently missed " + missed);

}

static char[] SetDisplayWord(string word)
{
    char[] displayWord = new char[word.Length];
    for (int i = 0; i < word.Length; i++)
    {
        displayWord[i] = '_';
    }
    return displayWord;
}

static string GetRandomWord()
{
   string[] words = GetWordList();
    Random rnd = new Random();
    int index = rnd.Next(words.Length);
    return words[index];
}

static string[] GetWordList()
{
    string[] wordsFromFile = File.ReadAllLines("words.txt");
    
    if (wordsFromFile == null || wordsFromFile.Length == 0)
    {
        Console.WriteLine("Invalid word list. No words were found in words.txt.");
        Environment.Exit(1);  // Exits the program.
    }

    const int MAX_WORDS = 7;
    string[] words;
    
    if (wordsFromFile.Length > MAX_WORDS)
    {
        words = new string[MAX_WORDS];
        Array.Copy(wordsFromFile, words, MAX_WORDS);
    }
    else
    {
        words = wordsFromFile;
    }
    
    return words;

}

static void ScoreBoard(int gamesWon, int gamesLost)
{
    Console.Clear();
    Console.WriteLine("You have won " + gamesWon + " games");
    Console.WriteLine("You have lost " + gamesLost + " games");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

static void Goodbye(int gamesWon, int gamesLost)
{
    Console.Clear();
    Console.WriteLine("Thank you for playing... \n" +
        "Press any key for one final look at the scoreboard" +
        " before you go");
    Console.ReadKey();
    ScoreBoard(gamesWon, gamesLost);
}

static void Pause()
{
    System.Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}