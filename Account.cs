using System.Text.Json;
using System.Text.RegularExpressions;
using System;

public static class Account
{

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

        // Create a new User object with the entered email and password
        User newUser = new User(email, password, naam, telefoonnummer, Adres, Plaatsnaam);

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
        Inlogscherm.ReserveerLogin();
    }


    public static bool CheckLogin()
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
            string password;
            Console.WriteLine("Voer uw email/telefoonnummer in:");
            string EmailOfNummer = Console.ReadLine();


            Console.WriteLine("Voer uw wachtwoord in:");
            password = Console.ReadLine();
            int correct = 0;
            foreach (User user in userlist1)
            {
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                // turn user.Telefoonnummer to string
                string Telefoonnummer = Convert.ToString(user.Telefoonnummer);
                if ((user.Email == EmailOfNummer) || Telefoonnummer == EmailOfNummer && user.Password == password)
                {
                    Console.WriteLine("Login successvol!");
                    Thread.Sleep(5000);
                    correct = 1;

                }
                else
                {
                    continue;
                }



            }
            if (correct == 1)
            {
                return true;
            }
            else
            {
                Account.ProbeerOpnieuwInTeLoggen();
                continue;
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
                Console.WriteLine("Reserveer");
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
                            Account.CheckLogin();
                        }


                        //Registreer een account
                        else if (selectedMenuItem1 == 1)
                        {

                            Console.Clear();
                            Inlogscherm.ReserveerLogin();
                        }

                        break;
                }
            }
        }
    }
}