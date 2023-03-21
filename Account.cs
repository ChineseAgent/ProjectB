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


        //Checken of telefoonnummer valid is
        Console.WriteLine("Voer uw telefoonnummer in:");
        while(true)
        {
            Telefoonnummer = Convert.ToInt32(Console.ReadLine());

            if (Telefoonnummer != 10)
            {
                Console.WriteLine("Ongeldig telefoonnummer.");
                continue;
            }
            else
            {
                Console.WriteLine("Telefoonnummer succesvol ingevoerd.");
                break;
            }
        }

        //geboortedatum checken
        Console.WriteLine("Voer uw geboortedatum in:");
        Console.WriteLine("(DD-MM-YYYY)");
        string? datum = "23-08-2005";
        // string? Datum = datum.Split('');


        // int yearint = int(year)
        // int monthint = int(month)
        // int dayint = int(day)

        // #January
        // if monthint == 1 and dayint == 31:
        //         dayint = 1
        //         monthint = 2
        // elif monthint == 1 and dayint > 31:
        //         print("Input Format ERROR, February has only 28 days.")
        //         exit()

        // #February
        // elif monthint == 2 and dayint == 28:
        //         dayint = 1
        //         monthint = 3
        // elif monthint == 2 and dayint > 28:
        //         print("Input Format ERROR, February has only 28 days.")
        //         exit()

        // #March
        // elif monthint == 3 and dayint == 31:
        //         dayint = 1
        //         monthint = 4
        // elif monthint == 3 and dayint > 31:
        //         print("Input Format ERROR, March has only 31 days.")
        //         exit()

        // #April
        // elif monthint == 4 and dayint == 30:
        //         dayint = 1
        //         monthint = 5
        // elif monthint == 4 and dayint > 30:
        //         print("Input Format ERROR, April has only 30 days.")
        //         exit()

        // #May
        // elif monthint == 5 and dayint == 31:
        //         dayint = 1
        //         monthint = 6
        // elif monthint == 5 and dayint > 31:
        //         print("Input Format ERROR, May has only 31 days.")
        //         exit()

        // #June
        // elif monthint == 6 and dayint == 30:
        //         dayint = 1
        //         monthint = 7
        // elif monthint == 6 and dayint > 30:
        //         print("Input Format ERROR, June has only 30 days.")
        //         exit()

        // #July
        // elif monthint == 7 and dayint == 31:
        //         dayint = 1
        //         monthint = 8
        // elif monthint == 7 and dayint > 31:
        //         print("Input Format ERROR, July has only 31 days.")
        //         exit()

        // #August
        // elif monthint == 8 and dayint == 31:
        //         dayint = 1
        //         monthint = 9
        // elif monthint == 8 and dayint > 31:
        //         print("Input Format ERROR, August has only 31 days.")
        //         exit()

        // #September
        // elif monthint == 9 and dayint == 30:
        //         dayint = 1
        //         monthint = 10
        // elif monthint == 9 and dayint > 30:
        //         print("Input Format ERROR, September has only 30 days.")
        //         exit()

        // #October
        // elif monthint == 10 and dayint == 31:
        //         dayint = 1
        //         monthint = 11
        // elif monthint == 10 and dayint > 31:
        //         print("Input Format ERROR, October has only 31 days.")
        //         exit()

        // #November
        // elif monthint == 11 and dayint == 30:
        //         dayint = 1
        //         monthint = 12
        // elif monthint == 11 and dayint > 30:
        //         print("Input Format ERROR, November has only 30 days.")
        //         exit()

        // #December
        // elif monthint == 12 and dayint == 31:
        //         dayint = 1
        //         monthint = 1
        //         yearint += 1
        // elif monthint == 12 and dayint > 31:
        //         print("Input Format ERROR, December has only 31 days.")
        //         exit()
        // else:
        //     dayint += 1



        Console.WriteLine("Voer uw adres in: (optioneel)");
        string Adres = Console.ReadLine();
        Console.WriteLine("Voer uw plaatsnaam in: (optioneel)");
        string Plaatsnaam = Console.ReadLine();

        // Create a new User object with the entered email and password
        User newUser = new User(email, password, naam, Telefoonnummer, Adres, Plaatsnaam);

        // Add the new User object to the list of User objects
        userList.Add(newUser);

        // Serialize the list of User objects into a JSON string
        string jsonString = JsonSerializer.Serialize(userList);

        // Write the JSON string to the JSON file
        File.WriteAllText("Accounts.JSON", jsonString);
    }


    public static bool CheckLogin()
    {
        string filePath = "Accounts.JSON";
        // Read the contents of the JSON file into a string
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)

        {
            string jsonFromFile = File.ReadAllText(filePath);
            List<User> userList = JsonSerializer.Deserialize<List<User>>(jsonFromFile);
            // Ask the user for an email and password
        }
        else
        {
            // Create a new list of User objects
            List<User> listusers = new List<User>();
        }

        while (true)
        {
            Console.WriteLine("Voer uw email in:");
            string email = Console.ReadLine();


            Console.WriteLine("Voer uw wachtwoord in:");
            string password = Console.ReadLine();
            int correct = 0;
            foreach (User user in userList)
            {
                if (user.Email == email && user.Password == password)
                {
                    Console.WriteLine("Login successvol!");
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
                Console.WriteLine("Gebruiker met deze email en wachtwoord bestaat niet, Probeer opnieuw.");
                continue;
            }
        }

    }
}