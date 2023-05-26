void welcome(){
    //verbatim literal
    Console.WriteLine(@"
█▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄█ █▄█ █░▀█ █▄▀");
};

//List<string> bandsList = new List<string>();
Dictionary<string,List<int>> bandsRating = new Dictionary<string, List<int>>();
void ShowMenu()
{
    welcome();
    Console.WriteLine("Enter 1 to register a band");
    Console.WriteLine("Enter 2 to display all bands");
    Console.WriteLine("Enter 3 to rate a band");
    Console.WriteLine("Enter 4 to display the average rating of a band");
    Console.WriteLine("Enter -1 to exit");
    Console.WriteLine("\nEnter your option: ");
    string option = Console.ReadLine()!;
    int numericalOption = int.Parse(option);
    switch(numericalOption)
    {
        case 1: register();
        break;
        case 2: displayBands();
        break;
        case 3: rate();
        break;
        case 4: bandAverageRate();
        break;
        case 5: exit();
        break;
        default: Console.WriteLine("Invalid input, try again");
        break;
    }
    
}

void register()
{
    Console.Clear();
    Console.WriteLine("Band registration");
    Console.Write("Enter the name of the band you want to register: ");
    string bandName = Console.ReadLine()!;
    //bandsList.Add(bandName);
    bandsRating.Add(bandName, new List<int>());
    Console.WriteLine($"The band {bandName} has been successfully registered!");
    Thread.Sleep(2000);
    Console.Clear();
    ShowMenu();
}

void displayBands()
{
    Console.Clear();
    Console.WriteLine("The current registered bands are:");
    foreach(string group in bandsRating.Keys)
        Console.WriteLine($"Band:{group}");
    Console.WriteLine("Press any key to go back to the menu");
    Console.ReadLine();
    Console.Clear();
    ShowMenu();
}

void rate()
{
    Console.Clear();
    Console.Write("Select the band you want to rate:");
    string bandName = Console.ReadLine()!;
    if(bandsRating.ContainsKey(bandName))
    {
        Console.WriteLine($"Input your rating for the band {bandName}");
        Console.WriteLine($"The rating must be an integer from 0 to 10:");
        try
        {
            int rating = int.Parse(Console.ReadLine()!);
            if(rating<= 10 && rating >= 0)
            {
                bandsRating[bandName].Add(rating);
                Console.WriteLine($"You rated the band {bandName} with a {rating}");
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadLine();
                Console.Clear();
                ShowMenu();
            }
            else
            {
                Console.WriteLine("Invalid input, try again");
                Thread.Sleep(2000);
                rate();
            }
        }
        catch
        {
            Console.WriteLine("Input must be an integer, try again");
            Thread.Sleep(2000);
            rate();
        }
    }
    else
    {
        Console.WriteLine($"The {bandName} is not registered");
        Console.WriteLine($"Do you want to register it? Press [y] Yes or [n] No ");
        string select = Console.ReadLine()!;
        switch(select)
        {
            case "y": register();
            break;
            case "n":
            {
                Console.WriteLine($"You will be redirected to the main menu!");
                Thread.Sleep(3000);
                Console.Clear();
                ShowMenu();
                break;
            }
        }
    }
}

void bandAverageRate()
{
    Console.Clear();
    Console.WriteLine("Select the band you want to see the average rating:");
    string bandName = Console.ReadLine()!;
    if(bandsRating.ContainsKey(bandName))
    {
        try
        {
            double average = bandsRating[bandName].Average();
            Console.WriteLine($"The average rating of the band {bandName} is {average}");
            Console.WriteLine("Press any key to go back to the menu");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }
        catch
        {
            Console.WriteLine($"The {bandName} hasn't been rated!");
            Console.WriteLine("Press 1 to rate the band");
            Console.WriteLine("Press 2 to try another band");
            Console.WriteLine("Press 3 to go to the main menu");
            string select = Console.ReadLine()!;
            switch(select)
            {
                case "1": rate();
                break;
                case "2":bandAverageRate();
                break;
                case "3":ShowMenu();
                break;
            }
        }
        
    }
    else
    {
        Console.WriteLine("The choosen band is not registered!");
        Console.WriteLine("Press 1 to register the band");
        Console.WriteLine("Press 2 to try another band's name");
        Console.WriteLine("Press 3 to go to the main menu");
        string select = Console.ReadLine()!;
        switch(select)
        {
            case "1": register();
            break;
            case "2":bandAverageRate();
            break;
            case "3":ShowMenu();
            break;
        }
    }
}

void exit()
{
    Environment.Exit(0);
}
ShowMenu();