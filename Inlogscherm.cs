public static class Inlogscherm
{

    public static void Logo()
    {
        // Write the Logo.txt file
        string[] lines = System.IO.File.ReadAllLines("Logo.txt");
        //now write the lines
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
    public static void Keuzemenu()
    {
        if (Account.CurrentUser != null && Account.CurrentUser.Email == null)
        {


            // Define the menu items
            string[] menuItems = { "Informatie", "De kaart", "Reserveer", "Login", "Registreren", "Afsluiten" };

            // Set the default selection
            int selectedMenuItem = 0;

            // Loop until the user selects an option
            while (true)
            {

                // Print the menu
                Console.Clear();
                Inlogscherm.Logo();
                Console.WriteLine("Welkom bij restaurant de Rot! Hier kunt u genieten van de Rotterdamse keuken");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("Hoofdmenu>");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Maak uw keuze:");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedMenuItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                // Read the user's input
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Respond to the input
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedMenuItem > 0)
                        {
                            selectedMenuItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedMenuItem < menuItems.Length - 1)
                        {
                            selectedMenuItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        // The user has selected an option
                        if (selectedMenuItem == 0)
                        {
                            // Informatie
                            Console.Clear();
                            Informatie.LaatInformatieZien();
                            return;
                        }
                        else if (selectedMenuItem == 1)
                        {
                            // De kaart
                            Console.Clear();
                            Menu kaart = new Menu();
                            if (Account.CurrentUser.Admin)
                            {
                                kaart.Menu_Kaart();
                            }
                            else
                            {
                                kaart.print_menu();
                                Inlogscherm.Keuzemenu();
                            }



                            return;
                        }

                        //Reserveer
                        else if (selectedMenuItem == 2)
                        {
                            MaakReservering.TijdSloten();
                            MaakReservering.KiesTijd();
                            Inlogscherm.Keuzemenu();
                        }


                        // Login
                        else if (selectedMenuItem == 3)
                        {
                            Inlogscherm.Loginscherm();
                            Inlogscherm.Keuzemenu();
                        }
                        else if (selectedMenuItem == 4)
                        {
                            Console.Clear();
                            Account.Registreer();
                        }

                        else if (selectedMenuItem == 5)
                        {
                            // Afsluiten
                            Console.Clear();
                            for (int b = 0; b < 1; b++)
                            {
                                Console.WriteLine("Aflsuiten.");
                                Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("Aflsuiten..");
                                Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("Aflsuiten...");
                                Thread.Sleep(500);
                                Console.Clear();
                            }
                            Environment.Exit(0);
                            return;
                        }
                        return;
                }
            }
        }
        else
        {
            // Get the size of the console window
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;



            // Define the menu items
            string[] menuItems = { "Informatie", "De kaart", "Reserveer", "Log uit", "Mijn gegevens", "Afsluiten" };

            // Set the default selection
            int selectedMenuItem = 0;

            // Loop until the user selects an option
            while (true)
            {

                // Print the menu

                Console.Clear();
                Inlogscherm.Logo();
                Console.WriteLine("");
                Console.WriteLine("Maak uw keuze:");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedMenuItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                // Read the user's input
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Respond to the input
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedMenuItem > 0)
                        {
                            selectedMenuItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedMenuItem < menuItems.Length - 1)
                        {
                            selectedMenuItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        // De gebruiker heeft een optie geselecteerd
                        if (selectedMenuItem == 0)
                        {
                            // Informatie
                            Console.Clear();
                            Informatie.LaatInformatieZien();
                            return;
                        }
                        else if (selectedMenuItem == 1)
                        {
                            // De kaart
                            Console.Clear();
                            Menu kaart = new Menu();
                            if (Account.CurrentUser.Admin)
                            {
                                kaart.Menu_Kaart();
                            }
                            else
                            {
                                kaart.print_menu();
                                Inlogscherm.Keuzemenu();
                            }
                            return;
                        }

                        // Reserveer
                        else if (selectedMenuItem == 2)
                        {
                            MaakReservering.TijdSloten();
                            MaakReservering.KiesTijd();
                            Inlogscherm.Keuzemenu();
                        }



                        //Log uit
                        else if (selectedMenuItem == 3)
                        {
                            Account.CurrentUser = new User();
                            Console.Clear();
                            Console.WriteLine("U bent uitgelogd.");
                            Thread.Sleep(3000);
                            Inlogscherm.Keuzemenu();
                            return;
                        }


                        else if (selectedMenuItem == 4)
                        {
                            if (Account.CurrentUser != null)
                            {
                                Account.MijnGegevens(Account.CurrentUser);
                            }

                        }
                        else if (selectedMenuItem == 5)
                        {
                            // Afsluiten
                            Console.Clear();
                            Console.Clear();
                            for (int b = 0; b < 1; b++)
                            {
                                Console.WriteLine("Aflsuiten.");
                                Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("Aflsuiten..");
                                Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("Aflsuiten...");
                                Thread.Sleep(500);
                                Console.Clear();
                            }
                            Environment.Exit(0);
                            return;
                        }
                        return;
                }
            }
        }

    }

    public static void Loginscherm()
    {
        string[] menuItems1 = { "Registreer een account", "Ga door als gast", "Ga terug" };

        // Set the default selection

        int selectedMenuItem1 = 0;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Login");
        Console.ResetColor();
        Console.Clear();
        Account.Login();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(" ");
        Console.WriteLine(menuItems1);
        Console.ResetColor();


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


            // case ConsoleKey.Enter:
            // The user has selected an option

            //Login met bestaand account
            // if (selectedMenuItem1 == 0)
            // {

            //     Console.Clear();
            //     Account.Login();
            //     return;
            // }

            case ConsoleKey.Enter:
                //Registreer een account
                if (selectedMenuItem1 == 1)
                {

                    Console.Clear();
                    Account.Registreer();
                    return;
                }



                //Ga door als gast                  
                else if (selectedMenuItem1 == 2)
                {
                    Inlogscherm.Keuzemenu();
                    return;
                }


                //Ga terug
                else if (selectedMenuItem1 == 3)
                {
                    Inlogscherm.Keuzemenu();
                    return;

                }
                break;
        }
    }
}
