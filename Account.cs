using System.Text.Json;
using System.Text.RegularExpressions;
using System;


public static class Account
{
    public static User? CurrentUser = new User();
    public static List<User>? userList = new List<User>();
    public static void Registreer()
    {
        string email;
        int Telefoonnummer;
        string filePath = "Accounts.JSON";


        // Json file uitlezen naar een string
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)

        {
            string? jsonFromFile = File.ReadAllText(filePath);
            userList = JsonSerializer.Deserialize<List<User>>(jsonFromFile);
        }
        else
        {
            // list creëren van user objecst
            Console.WriteLine("");
            List<User>? userList = new List<User>();
        }

        // Email en ww vragen
        Inlogscherm.Logo();
        Console.Write("Hoofdmenu>");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("Registreer>");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine(@"                        * = Verplicht                          ");
        Console.WriteLine(@"     Voer 'q' in om op elk moment terug te keren naar het hoofdmenu");

        while (true)
        {
            Console.Write("\n*Voer uw email in: ");
            email = Console.ReadLine();
            if (email == "q")
            {
                Inlogscherm.Keuzemenu();
            }
            else
            {
                // Check if the email is valid using a regular expression
                string? pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (email != null)
                {
                    if (!Regex.IsMatch(email, pattern))
                    {
                        Console.WriteLine("Ongeldig email adres.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }


        Console.Write("\n*Voer uw wachtwoord in: ");
        string? password = Console.ReadLine();

        if (password == "q")
        {
            Inlogscherm.Keuzemenu();
        }

        Console.Write("\n*Voer uw voornaam in: ");
        string? voornaam = Console.ReadLine();

        if (voornaam == "q")
        {
            Inlogscherm.Keuzemenu();
        }


        voornaam = voornaam.ToLower();
        voornaam = char.ToUpper(voornaam[0]) + voornaam.Substring(1);
        Console.Write("\nVoer uw tussenvoegsel in: ");

        string? tussenvoegsel = Console.ReadLine();

        if (tussenvoegsel == "q")
        {
            Inlogscherm.Keuzemenu();
        }

        Console.Write("\n*Voer uw achternaam in: ");
        string? achternaam = Console.ReadLine();
        if (tussenvoegsel == "q")
        {
            Inlogscherm.Keuzemenu();
        }
        achternaam = achternaam.ToLower();
        achternaam = char.ToUpper(achternaam[0]) + achternaam.Substring(1);
        string? telefoonnummer;
        //Checken of telefoonnummer valid is

        while (true)
        {

            Console.Write("\n*Voer uw telefoonnummer in: ");
            //check if phone number is valid
            telefoonnummer = Console.ReadLine();
            if (telefoonnummer == "q")
            {
                Inlogscherm.Keuzemenu();
            }
            else
            {
                if (string.IsNullOrEmpty(telefoonnummer) || telefoonnummer.Length != 10)
                {
                    Console.WriteLine("Ongeldig telefoonnummer, probeer opnieuw.");
                    continue;
                }
                else
                {
                    break;
                }
            }


        }



        Console.Write("\nVoer uw adres in: (straatnaam & huisnummer) ");
        string? Adres = Console.ReadLine();

        if (Adres == "q")
        {
            Inlogscherm.Keuzemenu();
        }

        Console.Write("\nVoer uw plaatsnaam in: ");
        string? Plaatsnaam = Console.ReadLine();

        if (Plaatsnaam == "q")
        {
            Inlogscherm.Keuzemenu();
        }

        int CustomerId = userList.Count + 1;

        // Create a new User object with the entered email and password
        User newUser = new User(email, password, voornaam, tussenvoegsel, achternaam, telefoonnummer, Adres, Plaatsnaam, CustomerId, false);
        if (userList != null)
        {
            userList.Add(newUser);
        }
        else
        {

        }

        string? jsonString = JsonSerializer.Serialize(userList);

        // Write the JSON string to the JSON file
        File.WriteAllText("Accounts.JSON", jsonString);

        Console.WriteLine("Account succesvol aangemaakt!");
        Console.WriteLine("");
        Console.WriteLine("Druk een toets in om terug te gaan naar het hoofdmenu...");
        Console.ReadKey();
        Console.Clear();
        Inlogscherm.Keuzemenu();
    }


    public static void Login()
    {
        List<User>? userlist1 = new List<User>();
        string? filePath = "Accounts.JSON";
        // Read the contents of the JSON file into a string
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)

        {
            string? jsonFromFile = File.ReadAllText(filePath);
            userlist1 = JsonSerializer.Deserialize<List<User>>(jsonFromFile);
            // Ask the user for an email and password
        }
        else
        {
            // Create a new list of User objects
            userlist1 = new List<User>();
        }

        while (true)
        {
            Inlogscherm.Logo();
            Console.Write("Hoofdmenu>");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Login>");
            Console.ResetColor();
            string? password;
            Console.Write("\nVoer uw email/telefoonnummer in: ");
            string? EmailOfNummer = Console.ReadLine();

            Console.Write("\nVoer uw wachtwoord in: ");
            password = Console.ReadLine();
            if (userlist1 != null)
            {
                foreach (User user in userlist1)
                {
                    // turn user.Telefoonnummer to string
                    string? Telefoonnummer = Convert.ToString(user.Telefoonnummer);
                    if ((user.Email == EmailOfNummer || Telefoonnummer == EmailOfNummer) && user.Wachtwoord == password)
                    {
                        Console.Clear();
                        Inlogscherm.Logo();
                        Console.Write("Hoofdmenu>");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Login>");
                        Console.WriteLine("");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Login successvol!");
                        CurrentUser = new User(user.Email, user.Wachtwoord, user.Voornaam, user.TussenVoegsel, user.Achternaam, user.Telefoonnummer, user.Adres, user.Plaatsnaam, user.CustomerId, user.Admin);
                        if (CurrentUser.Voornaam != null)
                        {
                            Console.WriteLine($"Welkom terug {Char.ToUpper(CurrentUser.Voornaam[0])}. {CurrentUser.TussenVoegsel} {CurrentUser.Achternaam} !");
                        }
                        else
                        {
                            Console.WriteLine($"Welkom terug {CurrentUser.Achternaam} !");
                        }
                        Console.WriteLine("Druk een toets in om terug te gaan naar het hoofdmenu...");
                        Console.ReadKey();
                        Inlogscherm.Keuzemenu();

                        break;


                    }
                }
            }

            if (CheckOfIngelogd())
            {

                break;
            }
            else
            {
                ProbeerOpnieuwInTeLoggen();

                if (CurrentUser.Email != null)
                {
                    break;
                }
                else
                {
                    Account.ProbeerOpnieuwInTeLoggen();
                }

            }


        }

    }


    public static bool CheckOfIngelogd()
    {
        Console.WriteLine(Account.CurrentUser.Email);
        if (Account.CurrentUser.Email != null)
        {
            return true;
        }
        else if (Account.CurrentUser.Email == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static void ProbeerOpnieuwInTeLoggen()
    {
        Console.Clear();
        Console.WriteLine("Uw wachtwoord is onjuist.");
        // Gebruik de pijltjes om te kiezen tussen terug naar het menu of opnieuw inloggen
        Console.WriteLine("Kies een optie:");

        {
            string[] keuzes = { "Probeer opnieuw", "Ga terug naar Hoofdmenu" };

            // Set the default selection

            int selectedMenuItem1 = 0;

            while (true)
            {
                Console.Clear();
                Inlogscherm.Logo();
                Console.Write("Hoofdmenu>");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Login>");
                Console.WriteLine("");
                Console.ResetColor();
                for (int i = 0; i < keuzes.Length; i++)
                {
                    if (i == selectedMenuItem1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(keuzes[i]);
                    Console.ResetColor();
                }

                // Read the user's input
                ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

                // Respond to the input
                switch (keyInfo1.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedMenuItem1 > 0)
                        {
                            selectedMenuItem1--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedMenuItem1 < keuzes.Length - 1)
                        {
                            selectedMenuItem1++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        // The user has selected an option

                        //Login met bestaand account
                        if (selectedMenuItem1 == 0)
                        {
                            Console.Clear();
                            Account.Login();
                        }


                        //Ga terug
                        else if (selectedMenuItem1 == 1)
                        {

                            Console.Clear();
                            Inlogscherm.Keuzemenu();
                        }

                        break;
                }
            }
        }
    }

    public static void MijnGegevens(User user)
    {
        // laat alle gegevens in een netjes formaat zien

        string[] menuItems1 = { "Wijzig gegevens", "Mijn reserveringen", "Ga terug" };

        // Set the default selection

        int selectedMenuItem1 = 0;

        while (true)
        {
            Console.Clear();
            Inlogscherm.Logo();
            Console.Write("Hoofdmenu>");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("Mijn gegevens>");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("Uw gegevens:");
            Console.WriteLine("Naam: " + user.Voornaam + " " + user.TussenVoegsel + " " + user.Achternaam);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Telefoonnummer: " + user.Telefoonnummer);
            Console.WriteLine("Adres: " + user.Adres);
            Console.WriteLine("Plaatsnaam: " + user.Plaatsnaam);

            for (int i = 0; i < menuItems1.Length; i++)
            {
                if (i == selectedMenuItem1)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(menuItems1[i]);
                Console.ResetColor();
            }

            // Read the user's input
            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

            // Respond to the input
            switch (keyInfo1.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedMenuItem1 > 0)
                    {
                        selectedMenuItem1--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedMenuItem1 < menuItems1.Length - 1)
                    {
                        selectedMenuItem1++;
                    }
                    break;


                case ConsoleKey.Enter:
                    // De gebruiker selecteert een optie

                    //Wijzig gegevens
                    if (selectedMenuItem1 == 0)
                    {

                        Console.Clear();
                        Account.Login();
                        return;
                    }

                    //Zie reserveringen
                    else if (selectedMenuItem1 == 1)
                    {
                        ZieReserveringen();
                    }


                    //Ga terug
                    else if (selectedMenuItem1 == 2)
                    {
                        Inlogscherm.Keuzemenu();
                        return;

                    }
                    break;
            }
        }
    }
    public static List<Reservering> ReserveringsLijst = new List<Reservering>();
    public static void ZieReserveringen()
    {
        int reserveringen = 0;
        Console.Clear();
        Inlogscherm.Logo();
        Console.WriteLine("");
        Console.Write("Hoofdmenu>");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write("Mijn reserveringen>");
        Console.ResetColor();
        Console.WriteLine("");


        if (Account.CurrentUser.Email != null)
        {


            string? filePath = "Reserveringen.JSON";
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                string? jsonFromFile = File.ReadAllText(filePath);
                ReserveringsLijst = JsonSerializer.Deserialize<List<Reservering>>(jsonFromFile);
            }
            foreach (Reservering Res in ReserveringsLijst)
            {
                if (Res.CustomerId == Account.CurrentUser.CustomerId)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"U heeft een reservering voor {Res.Hoeveelheid} personen in het tijdslot van {Res.Gekozentijd}.\nUw reserveringsnummer is {Res.ReserveringsNummer}");
                    reserveringen++;
                }
            }
            if (reserveringen == 0)
            {
                Console.WriteLine("U heeft nog geen reserveringen gemaakt");
            }
            Console.WriteLine("");
            Console.WriteLine("Druk een toets in om terug te gaan naar Mijn gegevens...");
            Console.ReadKey();
        }
        else
        {
            string filePath = "Reserveringen.json";
            Console.WriteLine("");
            Console.Write("Uw reserveringsnummer: ");
            string? reserveringsnummergast = Console.ReadLine();
            {
                string? jsonFromFile = File.ReadAllText(filePath);
                ReserveringsLijst = JsonSerializer.Deserialize<List<Reservering>>(jsonFromFile);
            }
            foreach (Reservering Res in ReserveringsLijst)
            {
                if (Res.ReserveringsNummer == reserveringsnummergast)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"U heeft een reservering voor {Res.Hoeveelheid} personen in het tijdslot van {Res.Gekozentijd}.\nUw reserveringsnummer is {Res.ReserveringsNummer}");
                    reserveringen++;
                }
            }
            if (reserveringen == 0)
            {
                {
                    string[] keuzes = { "Probeer opnieuw", "Ga terug naar Hoofdmenu" };

                    // Set the default selection

                    int selectedMenuItem1 = 0;

                    while (true)
                    {
                        Console.Clear();
                        Inlogscherm.Logo();
                        Console.Write("Hoofdmenu>");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Mijn reserveringen>");
                        Console.WriteLine("");
                        Console.ResetColor();
                        Console.WriteLine("Er zijn geen reserveringen gevonden met dit reserveringsnummer.");
                        Console.WriteLine("");
                        for (int i = 0; i < keuzes.Length; i++)
                        {
                            if (i == selectedMenuItem1)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(keuzes[i]);
                            Console.ResetColor();
                        }

                        // Read the user's input
                        ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

                        // Respond to the input
                        switch (keyInfo1.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (selectedMenuItem1 > 0)
                                {
                                    selectedMenuItem1--;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (selectedMenuItem1 < keuzes.Length - 1)
                                {
                                    selectedMenuItem1++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                // The user has selected an option

                                //Probeer opnieuw in te vullen
                                if (selectedMenuItem1 == 0)
                                {
                                    Console.Clear();
                                    Account.ZieReserveringen();
                                }
                                //Ga terug naar hoofdmenu
                                else if (selectedMenuItem1 == 1)
                                {

                                    Console.Clear();
                                    Inlogscherm.Keuzemenu();
                                }

                                break;
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Druk een toets in om terug te gaan naar het hoofdmenu...");
                Console.ReadKey();
                Inlogscherm.Keuzemenu();
            }

        }
    }

}