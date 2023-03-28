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
        string? password;
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
        Console.WriteLine("Voer uw email in:");
        while (true)
        {
            email = Console.ReadLine();

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

        Console.WriteLine("Voer uw wachtwoord in:");
        // while(true)
        // {
            password = Console.ReadLine();

        //     string? pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+\![^@\s]+\#[^@\s]+\$[^@\s]+\%[^@\s]+\^[^@\s]+\&[^@\s]+\*[^@\s]+\([^@\s]+\)[^@\s]+$";
        //     // int intpassword = Convert.ToInt32(password);

        //     if (password != null)
        //     {
        //         if (!Regex.IsMatch(password, pattern))
        //         {
        //             Console.WriteLine("Ongeldig wachtwoord.");
        //             continue;
        //         }
        //         // else if(intpassword < 6)
        //         // {
        //         //     Console.WriteLine("Ongeldig wachtwoord.");
        //         //     continue;
        //         // }
        //         else
        //         {
        //             break;
        //         }
        //     }
        // }

        Console.WriteLine("Voer uw voornaam in:");
        string? voornaam = Console.ReadLine();
        Console.WriteLine("Voer uw tussenvoegsel in: (optioneel)");
        string? tussenvoegsel = Console.ReadLine();
        Console.WriteLine("Voer uw achternaam in:");
        string? achternaam = Console.ReadLine();

        string? telefoonnummer;
        //Checken of telefoonnummer valid is
        Console.WriteLine("Voer uw telefoonnummer in:");
        while (true)
        {
            //check if phone number is valid
            telefoonnummer = Console.ReadLine();
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




        Console.WriteLine("*Voer uw adres in: (straatnaam + huisnummer)");
        string Adres = Console.ReadLine();
        Console.WriteLine("*Voer uw plaatsnaam in: ");
        string Plaatsnaam = Console.ReadLine();
        int CustomerId = userList.Count + 1;
        Console.WriteLine("*Voer uw adres in: ");
        Console.WriteLine("*Voer uw postcode in: ");
        string Postcode = Console.ReadLine();

        // Create a new User object with the entered email and password
        User newUser = new User(email, password, voornaam, tussenvoegsel, achternaam, telefoonnummer, Adres, Plaatsnaam, Postcode, CustomerId, false);
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

        Console.WriteLine("Account aangemaakt!");
        Console.WriteLine("");
        Console.WriteLine("We leiden u nu terug naar het hoofdmenu.");
        Thread.Sleep(5000);
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Login");
            Console.ResetColor();
            string? password;
            Console.WriteLine("Voer uw email/telefoonnummer in:");
            string? EmailOfNummer = Console.ReadLine();
            Console.WriteLine("Voer uw wachtwoord in:");
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
                        Console.WriteLine("Login successvol!");
                        CurrentUser = new User(user.Email, user.Wachtwoord, user.Voornaam, user.TussenVoegsel, user.Achternaam, user.Telefoonnummer, user.Adres, user.Plaatsnaam, user.Postcode, user.CustomerId, user.Admin);
                        if (CurrentUser.Voornaam != null)
                        {
                            Console.WriteLine($"Welkom terug {Char.ToUpper(CurrentUser.Voornaam[0])}. {CurrentUser.TussenVoegsel} {CurrentUser.Achternaam} !");
                        }
                        else
                        {
                            Console.WriteLine($"Welkom terug {CurrentUser.Achternaam} !");
                        }
                        Thread.Sleep(3000);
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
            string[] keuzes = { "Probeer opnieuw", "Ga terug" };

            // Set the default selection

            int selectedMenuItem1 = 0;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Login fout");
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

        string[] menuItems1 = { "Wijzig gegevens", "Bekijk reserveringen", "Ga terug" };

        // Set the default selection

        int selectedMenuItem1 = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            Console.WriteLine("Mijn gegevens");
            Console.WriteLine("");
            Console.WriteLine("Uw gegevens:");
            Console.WriteLine("Naam: " + user.Voornaam + " " + user.TussenVoegsel + " " + user.Achternaam);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Telefoonnummer: " + user.Telefoonnummer);
            Console.WriteLine("Adres: " + user.Adres);
            Console.WriteLine("Plaatsnaam: " + user.Plaatsnaam);
            Console.WriteLine("Postcode: " + user.Postcode);


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
        Console.Clear();
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
                Console.WriteLine($"U heeft een reservering voor {Res.Hoeveelheid} personen in het tijdslot van {Res.Gekozentijd}.\nUw reserveringsnummer is {Res.ReserveringsNummer}");
            }
        }
        Thread.Sleep(10000);
    }



}