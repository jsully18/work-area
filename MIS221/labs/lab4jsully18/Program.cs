// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        while (true) // Loop until the user chooses to exit
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Display a random shape");
            Console.WriteLine("2 - Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                GetRandomShape(); // Display a random shape
            }
            else if (input == "2")
            {
                Console.WriteLine("Exiting program. Goodbye!");
                break; // Exit the loop
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }
    }

    static void GetRandomShape()
    {
        Random rand = new Random();
        int shapeChoice = rand.Next(4); // 0 to 3 (four shapes)

        switch (shapeChoice)
        {
            case 0:
                DisplaySquare();
                break;
            case 1:
                DisplayTriangle();
                break;
            case 2:
                DisplayStar();
                break;
            case 3:
                DisplayUmbrella();
                break;
        }
    }

    static void DisplaySquare()
    {
        Random rand = new Random();
        int size = rand.Next(5, 9); // Random size between 5-8

        Console.WriteLine($"\nDisplaying a Square ({size} x {size}):\n");

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }

    static void DisplayTriangle()
    {
        Random rand = new Random();
        int rows = rand.Next(5, 9); // Random rows between 5-8

        Console.WriteLine($"\nDisplaying a Triangle with {rows} rows:\n");

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }

    static void DisplayStar(){
    System.Console.WriteLine(@"
        .
       ,O,
      ,OOO,
'oooooOOOOOooooo'
  `OOOOOOOOOOO`
    `OOOOOOO`
    OOOO'OOOO
   OOO'   'OOO
  O'         'O");
}

  
    static void DisplayUmbrella(){
    System.Console.WriteLine("Umbrella");
    System.Console.WriteLine(@"
          .
         _|_
      .-'   '-.
     /         \
     ^^^^^|^^^^^
          |
          \_/");
           }
}