using System.Text.Json;
using System.Text.RegularExpressions;
using System;

public static class Account
{
    public static User CurrentUser = new User();
    public static List<User> userList = new List<User>();
    public static void Registreer()
    {
        string email;
        int Telefoonnummer;
        string filePath = "Accounts.JSON";
        // Json file uitlezen naar een string
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)

        {
            string jsonFromFile = File.ReadAllText(filePath);
            userList = JsonSerializer.Deserialize<List<User>>(jsonFromFile);
        }
        else
        {
            // list creëren van user objecst
            Console.WriteLine("");
            List<User> userList = new List<User>();
        }

        // Email en ww vragen
        Console.WriteLine("Voer uw email in:");
        while (true)
        {
            email = Console.ReadLine();

            // Check if the email is valid using a regular expression
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
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

        Console.WriteLine("Voer uw wachtwoord in:");
        string password = Console.ReadLine();

        Console.WriteLine("Voer uw voor- en achternaam in:");
        string naam = Console.ReadLine();
        Console.WriteLine("Voor- en achternaam succesvol ingevoerd:");

        string telefoonnummer;
        //Checken of telefoonnummer valid is
        Console.WriteLine("Voer uw telefoonnummer in:");
        while (true)
        {
            //check if phone number is valid
            telefoonnummer = Console.ReadLine();
            if (telefoonnummer.Length != 10)
            {
                Console.WriteLine("Ongeldig telefoonnummer, probeer opnieuw.");
                continue;
            }
            else
            {
                break;
            }
        }




        Console.WriteLine("Voer uw adres in: (optioneel)");
        string Adres = Console.ReadLine();
        Console.WriteLine("Voer uw plaatsnaam in: (optioneel)");
        string Plaatsnaam = Console.ReadLine();
        int CustomerId = userList.Count + 1;

        // Create a new User object with the entered email and password
        User newUser = new User(email, password, naam, telefoonnummer, Adres, Plaatsnaam, CustomerId);

        // Add the new User object to the list of User objects
        userList.Add(newUser);

        // Serialize the list of User objects into a JSON string
        string jsonString = JsonSerializer.Serialize(userList);

        // Write the JSON string to the JSON file
        File.WriteAllText("Accounts.JSON", jsonString);

        Console.WriteLine("Account aangemaakt!");
        Console.WriteLine("We leiden u nu terug naar de login pagina.");
        Thread.Sleep(5000);
        Console.Clear();
        Inlogscherm.Loginscherm();
    }


    public static void Login()
    {
        List<User> userlist1 = new List<User>();
        string filePath = "Accounts.JSON";
        // Read the contents of the JSON file into a string
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)

        {
            string jsonFromFile = File.ReadAllText(filePath);
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
            string password;
            Console.WriteLine("Voer uw email/telefoonnummer in:");
            string EmailOfNummer = Console.ReadLine();


            Console.WriteLine("Voer uw wachtwoord in:");
            password = Console.ReadLine();
            int correct = 0;
            foreach (User user in userlist1)
            {
                // turn user.Telefoonnummer to string
                string Telefoonnummer = Convert.ToString(user.Telefoonnummer);
                if ((user.Email == EmailOfNummer || Telefoonnummer == EmailOfNummer) && user.Wachtwoord == password)
                {
                    Console.Clear();
                    Console.WriteLine("Login successvol!");
                    CurrentUser = new User(user.Email, user.Wachtwoord, user.Naam, user.Telefoonnummer, user.Adres, user.Plaatsnaam, user.CustomerId);
                    Console.WriteLine("Welkom terug " + CurrentUser.Naam + "!");
                    Thread.Sleep(3000);
                    break;

                }
                else
                {
                    continue;
                }





            }
            if (CurrentUser.Email == null)
            {
                Account.ProbeerOpnieuwInTeLoggen();
            }
            else
            {
                break;
            }

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


                        //Registreer een account
                        else if (selectedMenuItem1 == 1)
                        {

                            Console.Clear();
                            Inlogscherm.Loginscherm();
                        }

                        break;
                }
            }
        }
    }

    public static void MijnGegevens(User user)
    {
        // laat alle gegevens in een netjes formaat zien

        string[] menuItems1 = { "Wijzig gegevens", "Ga terug" };

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
            Console.WriteLine("Naam: " + user.Naam);
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


                    //Ga terug
                    else if (selectedMenuItem1 == 1)
                    {
                        Inlogscherm.Keuzemenu();
                        return;

                    }
                    break;
            }
        }
    }

}
