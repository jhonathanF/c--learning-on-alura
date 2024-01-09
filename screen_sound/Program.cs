List<string> bandList = new(["Red Hot Chilli Peppers"]);
Dictionary<string, List<int>> bandDictionary = new();
bandDictionary.Add("Red Hot Chilli Peppers", [10, 9]);
bandDictionary.Add("Fresno", []);

Main();


void Main()
{
    int? selectedOption = null;

    while (selectedOption != 0)
    {
        DisplayMenuOptions();
        string chosedOption = readOption();
        selectedOption = !String.IsNullOrEmpty(chosedOption) ? int.Parse(chosedOption) : -1;
        switch (selectedOption)
        {
            case 1: RegisterBand(); break;
            case 2: showAllBands(); break;
            case 3: ReviewABand(); break;
            case 4: BandReviewAverage(); break;
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
    Console.WriteLine("4 - Band Review Score Average");
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
    bandDictionary.Add(bandName, new List<int> { });

    Console.Write($"Band {bandName} registered!");
    WaitForUserInput();
}

void showAllBands()
{
    DisplayOptionTitle("All Bands List");
    foreach (string bandName in bandDictionary.Keys)
    {
        Console.WriteLine(bandName);
        Console.WriteLine("Band Reviews: " + string.Join<int>(", ", bandDictionary[bandName]) + "\n");
    }

    WaitForUserInput();
}

void ReviewABand()
{
    DisplayOptionTitle("Review a band");

    Console.Write("Enter the band name: ");
    string bandSelected = readOption();

    if (!bandDictionary.ContainsKey(bandSelected))
    {
        HandleNonExistentBand(bandSelected);
        return;
    }

    Console.Write("\nEnter the review note (1 to 10): ");
    int bandReview = int.Parse(readOption());
    bandDictionary[bandSelected].Add(bandReview);

    Console.Write("\nReview Registed Successfully!");

    WaitForUserInput();
}

void BandReviewAverage()
{
    DisplayOptionTitle("Band Review Score Average");

    Console.Write("Enter the band name: ");
    string bandSelected = readOption();
    if (!bandDictionary.ContainsKey(bandSelected))
    {
        HandleNonExistentBand(bandSelected);
        return;
    }

    if (bandDictionary[bandSelected].Count > 0)
    {
        double reviewAverage = bandDictionary[bandSelected].Average();
        Console.Write($"\nReview Average for {bandSelected} Is:  {reviewAverage:0.0###}!");
        WaitForUserInput();
        return;
    }

    Console.WriteLine($"\nBand {bandSelected} does not have any review yet!");
    WaitForUserInput();
}

void HandleNonExistentBand(string bandSelected)
{
    Console.WriteLine($"\nBand {bandSelected} not found :/");
    WaitForUserInput();
    return;
}

void WaitForUserInput()
{
    Console.Write("\n\nPress Any Key to continue...");
    Console.ReadLine();
    return;
}
