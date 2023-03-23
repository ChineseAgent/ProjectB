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

        // Define the menu items
        string[] menuItems = { "Informatie", "De kaart", "Reserveer", "Afsluiten" };

        // Set the default selection
        int selectedMenuItem = 0;

        // Loop until the user selects an option
        while (true)
        {

            // Print the menu
            Console.Clear();
            Inlogscherm.Logo();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welkom bij project B restaurant!.");
            Console.ResetColor();
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
                        Console.WriteLine("Informatie");
                        Console.ReadKey(true);
                        return;
                    }
                    else if (selectedMenuItem == 1)
                    {
                        // De kaart
                        Console.Clear();
                        Console.WriteLine("De kaart");
                        Console.ReadKey(true);
                        return;
                    }







                    // Reserveer
                    else if (selectedMenuItem == 2)
                    {
                        Inlogscherm.ReserveerLogin();
                    }












                    else if (selectedMenuItem == 3)
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

    public static void ReserveerLogin()
    {
        string[] menuItems1 = { "Log in met bestaand account", "Registreer een account", "Ga door als gast", "Ga terug" };

        // Set the default selection

        int selectedMenuItem1 = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Reserveer");
            Console.ResetColor();
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
                    // The user has selected an option

                    //Login met bestaand account
                    if (selectedMenuItem1 == 0)
                    {

                        Console.Clear();
                        Account.Login();
                        Console.ReadKey(true);
                        return;
                    }


                    //Registreer een account
                    else if (selectedMenuItem1 == 1)
                    {

                        Console.Clear();
                        Account.Registreer();
                        Console.ReadKey(true);
                        return;
                    }



                    //Ga door als gast                  
                    else if (selectedMenuItem1 == 2)
                    {
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

}
