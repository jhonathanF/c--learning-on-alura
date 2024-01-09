List<string> bandList = new List<string>(["Red Hot Chilli Peppers"]);
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
            case 3: Console.WriteLine("You Choose 3!!"); break;
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
    bandList.Add(bandName);

    Console.Write($"Band {bandName} registered!");
    Thread.Sleep(2000);
}

void showAllBands()
{
     DisplayOptionTitle("All Bands List");
    foreach (string bandName in bandList)
    {
        Console.WriteLine(bandName);
    }

    Console.ReadLine();
}