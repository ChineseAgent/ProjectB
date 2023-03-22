using Newtonsoft.Json;
using System;
using System.Threading;
public class Menu
{
    public List<Menu> listOfObjects = new List<Menu>();
    public List<Item> Voorgerecht;
    public List<Item> Hoofdgerecht;
    public List<Item> Nagerecht;
    public List<Item> Koffie_Thee;
    public List<Item> Fris_Sappen;
    public List<Item> BierVanDeTap;
    public List<Item> Wijn;


    public Menu()
    {
        Voorgerecht = new List<Item>();
        Hoofdgerecht = new List<Item>();
        Nagerecht = new List<Item>();
        Koffie_Thee = new List<Item>();
        Fris_Sappen = new List<Item>();
        BierVanDeTap = new List<Item>();
        Wijn = new List<Item>();
    }

    // Laad de data van de kaart in een lijst
    public void load_data()
    {
        StreamReader reader = new("Data.json");
        string File2Json = reader.ReadToEnd();
        listOfObjects = JsonConvert.DeserializeObject<List<Menu>>(File2Json)!;
        reader.Close();
    }

    // Slaat de data van de kaart op in Data.json
    public void save_data()
    {
        StreamWriter writer = new("Data.json");
        string List2Json = JsonConvert.SerializeObject(listOfObjects);
        writer.Write(List2Json);
        writer.Close();
    }

    // De format voor elke item in het menu
    public string WriteMessage(Item i)
    {
        return $"{i.Name}    ${i.Price}" +
                $"\n{i.Omschrijving}\n";
    }

    // Functie om het menu te printen moet je aanpassen voor andere volgorde
    public void print_menu()
    {
        load_data();
        foreach (Menu item in listOfObjects)
        {
            Console.WriteLine("\nEten:");
            Console.WriteLine("Voorgerechten:\n");
            foreach (Item i in item.Voorgerecht)
            {
                Console.WriteLine(WriteMessage(i));
            }
            Console.WriteLine("\nHoofdgerechten:\n");
            foreach (Item i in item.Hoofdgerecht)
            {
                Console.WriteLine(WriteMessage(i));
            }
            Console.WriteLine("\nNagerechten:\n");
            foreach (Item i in item.Nagerecht)
            {
                Console.WriteLine(WriteMessage(i));
            }
            Console.WriteLine("\nDrinken:");
            Console.WriteLine("Koffie & Thee:\n");
            foreach (Item i in item.Koffie_Thee)
            {
                Console.WriteLine(WriteMessage(i));
            }
            Console.WriteLine("\nFris & Sappen:\n");
            foreach (Item i in item.Fris_Sappen)
            {
                Console.WriteLine(WriteMessage(i));
            }
            Console.WriteLine("\nBier van de tap:\n");
            foreach (Item i in item.BierVanDeTap)
            {
                Console.WriteLine(WriteMessage(i));
            }
            Console.WriteLine("\nWijn:\n");
            foreach (Item i in item.Wijn)
            {
                Console.WriteLine(WriteMessage(i));
            }
        }
    }

    // Functie om item toe te voegen aan het menu
    public void add_item(Item item, int locatie)
    {
        load_data();
        switch (locatie)
        {
            case 1:
                listOfObjects[0].Voorgerecht.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case 2:
                listOfObjects[0].Hoofdgerecht.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case 3:
                listOfObjects[0].Nagerecht.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case 4:
                listOfObjects[0].Koffie_Thee.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case 5:
                listOfObjects[0].Fris_Sappen.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case 6:
                listOfObjects[0].BierVanDeTap.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            case 7:
                listOfObjects[0].Wijn.Add(item);
                Console.WriteLine("Item toegevoegd");
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
        save_data();
    }

    // Functie om item te verwijderen uit het menu
    public void remove_item(string naam, int locatie)
    {
        load_data();
        bool Completed = false;
        switch (locatie)
        {
            case 1:
                foreach (Item i in listOfObjects[0].Voorgerecht)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].Voorgerecht.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case 2:
                foreach (Item i in listOfObjects[0].Hoofdgerecht)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].Hoofdgerecht.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case 3:
                foreach (Item i in listOfObjects[0].Nagerecht)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].Nagerecht.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case 4:
                foreach (Item i in listOfObjects[0].Koffie_Thee)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].Koffie_Thee.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case 5:
                foreach (Item i in listOfObjects[0].Fris_Sappen)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].Fris_Sappen.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case 6:
                foreach (Item i in listOfObjects[0].BierVanDeTap)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].BierVanDeTap.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            case 7:
                foreach (Item i in listOfObjects[0].Wijn)
                {
                    if (i.Name == naam)
                    {
                        Completed = true;
                    }
                }
                if (Completed)
                {
                    listOfObjects[0].Wijn.RemoveAll(x =>x.Name == naam);
                    save_data();
                    Console.WriteLine("Item is verwijderd");
                }
                else
                {
                    Console.WriteLine("Item zit niet in dit menu");
                }
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }

    //De functie om makkelijk dingen aan te assen en desnoods voor de gebruiker/admin
    public void Menu_Kaart()
    {
        bool admin = true;

        // Define the menu items
        string[] menuItems = { "1. De kaart weergeven","2. De kaart bewerken (Admin Only)","3. Terug" };

        // Set the default selection
        int selectedMenuItem = 0;

        bool done = false;

        // Loop until the user selects an option
        while (!done)
        {
            // Print the menu
            Console.Clear();
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
                    done = true;
                    switch (selectedMenuItem)
                    {
                        case 0:
                            {
                                print_menu();
                                Thread.Sleep(2000);
                                Menu_Kaart();
                                break;
                            }
                        case 1:
                            {
                                Kaart_Bewerken();
                                break;
                            }
                        case 2:
                            {
                                System.Environment.Exit(0);
                                break;
                            }
                    }
                    Console.ReadKey(true);
                    return;
            }
        }
    }

    //Verder specificate voor Menu_Kaart()
    public void Kaart_Bewerken()
    {
        // Define the menu items
        string[] menuItems = { "Voorgerecht","Hoofdgerecht","Nagerecht","Koffie & Thee", "Fris & Sappen", "Bier van de tap", "Wijn","Terug"};

        // Set the default selection
        int selectedMenuItem = 0;

        bool done = false;

        // Loop until the user selects an option
        while (!done)
        {
            // Print the menu
            Console.Clear();
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
                    done = true;
                    switch (selectedMenuItem)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            {
                                Item_Bewerken(selectedMenuItem++, menuItems);
                                break;
                            }
                        case 7:
                            {
                                Menu_Kaart();
                                break;

                            }
                    }
                    Console.ReadKey(true);
                    return;
            }
        }
    }


    //Verder specificatie voor Kaart_Bewerken()
    public void Item_Bewerken(int catagorie, string[] menu)
    {
        int bewaren = catagorie + 1;

        // Define the menu items
        string[] menuItems = { "Item toevoegen","Item verwijderen","Terug" };

        // Set the default selection
        int selectedMenuItem = 0;

        bool done = false;

        // Loop until the user selects an option
        while (!done)
        {
            // Print the menu
            Console.Clear();
            Console.WriteLine("Wat wil je veranderen in " + menu[catagorie]);
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
                    done = true;
                    switch (selectedMenuItem)
                    {
                        case 0:
                            {
                                Console.WriteLine("\nHoe heet dit item:");
                                string? naam = Console.ReadLine();
                                Console.WriteLine("\nWat is de prijs in 0,00.");
                                double prijs = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("\nWat is de Omschrijving van dit Product?");
                                string? omschrijving = Console.ReadLine();
                                Console.WriteLine("\nIndien nodig schrijf allergieen anders type x.");
                                string? allergieen = Console.ReadLine();
                                Item _new = new Item(naam, prijs, omschrijving, allergieen);
                                add_item(_new, bewaren);
                                Item_Bewerken(catagorie, menu);
                                break;
                            }
                        case 1:
                            {
                                Console.WriteLine("\nHoe heet dit item:");
                                string? naam = Console.ReadLine();
                                remove_item(naam, bewaren);
                                Item_Bewerken(catagorie, menu);
                                break;
                            }
                        case 2:
                            {
                                Kaart_Bewerken();
                                break;
                            }
                    }
                    Console.ReadKey(true);
                    return;
            }
        }
    }
    
}

