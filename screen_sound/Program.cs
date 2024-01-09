List<string> bandList = new List<string>(["Red Hot Chilli Peppers"]);
Dictionary<string, List<int>> bandDictionary = new();
bandDictionary.Add("Red Hot Chilli Peppers", new List<int> { 10 });
bandDictionary.Add("Fresno", new List<int>{});

Main();


void Main()
{
    int? selectedOption = null;

    while (selectedOption != 0)
    {
        DisplayMenuOptions();
        selectedOption = int.Parse(readOption());
        switch (selectedOption)
        {
            case 1: RegisterBand(); break;
            case 2: showAllBands(); break;
            case 3: ReviewABand(); break;
            case 4: Console.WriteLine("You Choose 4!!"); break;
            case 0: Console.WriteLine("Bye o/"); break;
            default: Console.WriteLine("Invalid option :/"); break;
        }
    }
}

void DisplayWelcomeMessage()
{
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄   █▀█ █▀█ █▀█ ░░█ █▀▀ █▀▀ ▀█▀
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀   █▀▀ █▀▄ █▄█ █▄█ ██▄ █▄▄ ░█░
    ");
}

void DisplayOptionTitle(string title)
{
    int titleLength = title.Length;
    string border = string.Empty.PadLeft(titleLength, '*');

    Console.Clear();
    Console.WriteLine(border);
    Console.WriteLine(title);
    Console.WriteLine(border);
    Console.WriteLine();
}

void DisplayMenuOptions()
{
    Console.Clear();
    DisplayWelcomeMessage();
    Console.WriteLine("\n1 - Register a new Band");
    Console.WriteLine("2 - Show All Bands");
    Console.WriteLine("3 - Review a Band");
    Console.WriteLine("4 - Show Review Score Average");
    Console.WriteLine("0 - Exit\n");

    Console.Write("Select Option: ");
}

string readOption()
{
    return Console.ReadLine()!;
}

void RegisterBand()
{
    DisplayOptionTitle("Band Register");
    Console.Write("Band Name: ");

    string bandName = Console.ReadLine()!;
    bandDictionary.Add(bandName, new List<int>{});

    Console.Write($"Band {bandName} registered!");
    Thread.Sleep(2000);
}

void showAllBands()
{
    DisplayOptionTitle("All Bands List");
    foreach (string bandName in bandDictionary.Keys)
    {
        Console.WriteLine(bandName);
        Console.WriteLine("Band Reviews: " + string.Join<int>(", ", bandDictionary[bandName]) + "\n");
    }

    Console.ReadLine();
}

void ReviewABand()
{
    DisplayOptionTitle("Review a band");

    Console.Write("Enter the band name: ");
    string bandSelected = readOption();

    if (!bandDictionary.ContainsKey(bandSelected))
    {
        Console.WriteLine($"\nBand {bandSelected} not found :/");
        Console.ReadLine();
        return;
    }

    Console.Write("\nEnter the review note (1 to 10): ");
    int bandReview = int.Parse(readOption());
    bandDictionary[bandSelected].Add(bandReview);

    Console.Write("\nReview Registed Successfully!");

    Thread.Sleep(1500);
}