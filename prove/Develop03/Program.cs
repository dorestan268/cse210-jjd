using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A library of scriptures
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("Isaiah", 41, 10), "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness."),
            new Scripture(new Reference("Matthew", 11, 28, 30), "Come unto me, all ye that labour and are heavy laden, and I will give you rest.\nTake my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls.\nFor my yoke is easy, and my burden is light."),
            new Scripture(new Reference("2 Timothy", 1, 7), "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind."),
            new Scripture(new Reference("Joshua", 1, 9), "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."),
            new Scripture(new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
            new Scripture(new Reference("Psalm", 46, 1, 3), "God is our refuge and strength, a very present help in trouble.\nTherefore will not we fear, though the earth be removed, and though the mountains be carried into the midst of the sea;\nThough the waters thereof roar and be troubled, though the mountains shake with the swelling thereof."),
            new Scripture(new Reference("Proverbs", 16, 3), "Commit thy works unto the Lord, and thy thoughts shall be established."),
            new Scripture(new Reference("John", 14, 27), "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. Let not your heart be troubled, neither let it be afraid.")
        };

        // Select a random scripture from the library
        var random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        Console.Clear();
        Console.WriteLine("Greetings! Welcome to the Scripture Memory Challenge!");
        Console.WriteLine("Focus on the scripture below. Type 'repeat' to repeat the scripture or 'quit' to leave the program.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Press Enter to hide words.");
            Console.WriteLine("2. Type 'repeat' to repeat the scripture.");
            Console.WriteLine("3. Type 'quit' to exit.");
            Console.Write("\nYour choice: ");

            string input = Console.ReadLine()?.ToLower();

            if (input == "quit" || selectedScripture.IsCompletelyHidden())
            {
                break;
            }
            else if (input == "repeat")
            {
                ShowRepeatChallenge(selectedScripture); // Trigger repeat challenge
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                selectedScripture.HideRandomWords(4); // Hide 4 random words
            }
        }

        Console.WriteLine("\nThank you for using the Scripture Memorization Program!\nGoodbye!");
    }

    // Displays the scripture for the Repeat Challenge
    static void ShowRepeatChallenge(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine("Repeat this scripture out loud and press Enter when you're ready:");
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress Enter when you're done...");
        Console.ReadLine();
    }
}
