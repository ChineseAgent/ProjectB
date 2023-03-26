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

    public void load_data()
    {
        StreamReader reader = new("Data.json");
        string File2Json = reader.ReadToEnd();
        listOfObjects = JsonConvert.DeserializeObject<List<Menu>>(File2Json)!;
        reader.Close();
    }

    public void save_data()
    {
        StreamWriter writer = new("Data.json");
        string List2Json = JsonConvert.SerializeObject(listOfObjects);
        writer.Write(List2Json);
        writer.Close();
    }

    public string WriteMessage(Item i)
    {
        return $"{i.Name}    €{i.Price}" +
                $"\n{i.Omschrijving}\n";
    }

    public void print_menu()
    {
        load_data();

        Console.WriteLine(DeKaart);
        foreach (Menu item in listOfObjects)
        {
            Console.WriteLine("\nVoorgerechten:\n");
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
            Console.WriteLine("\nKoffie & Thee:\n");
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
                    listOfObjects[0].Voorgerecht.RemoveAll(x => x.Name == naam);
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
                    listOfObjects[0].Hoofdgerecht.RemoveAll(x => x.Name == naam);
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
                    listOfObjects[0].Nagerecht.RemoveAll(x => x.Name == naam);
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
                    listOfObjects[0].Koffie_Thee.RemoveAll(x => x.Name == naam);
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
                    listOfObjects[0].Fris_Sappen.RemoveAll(x => x.Name == naam);
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
                    listOfObjects[0].BierVanDeTap.RemoveAll(x => x.Name == naam);
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
                    listOfObjects[0].Wijn.RemoveAll(x => x.Name == naam);
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

    public void snel()
    {
        while (true)
        {
            Console.WriteLine("\nWelke catagorie wil je veranderen" +
                            "\n1. Voorgerecht" +
                            "\n2. Hoofdgerecht" +
                            "\n3. Nagerecht" +
                            "\n4. Koffie & Thee" +
                            "\n5. Fris & Sappen" +
                            "\n6. Bier op tap" +
                            "\n7. Wijn" +
                            "\n8. Menu laten zien" +
                            "\n9. Stoppen");
            int Awnser = Convert.ToInt32(Console.ReadLine());
            if ((Awnser < 1) && (Awnser > 9))
            {
                Console.WriteLine("Verkeerde input. verwacht (1 tot 9)");
                snel();
            }
            else if (Awnser == 8)
            {
                print_menu();
                Thread.Sleep(5000);
                snel();
            }
            else if (Awnser == 9)
            {
                return;
            }
            Console.WriteLine("\nWat wil je veranderen in deze catagorie." +
                            "\n1. Item toevoegen" +
                            "\n2. Item verwijderen" +
                            "\n3. Terug");
            int Awnser1 = Convert.ToInt32(Console.ReadLine());
            if ((Awnser1 < 1) && (Awnser1 > 3))
            {
                Console.WriteLine("Verkeerde input. verwacht (1 tot 3)");
                snel();
            }
            else if (Awnser1 == 3)
            {
                snel();
            }
            else if (Awnser1 == 1)
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
                add_item(_new, Awnser);
            }
            else if (Awnser1 == 2)
            {
                Console.WriteLine("\nHoe heet dit item:");
                string? naam = Console.ReadLine();
                remove_item(naam, Awnser);
            }
        }
    }



    // ASCI TEKSTEN

    string DeKaart = @"  _____         _  __                _   
 |  __ \       | |/ /               | |  
 | |  | | ___  | ' / __ _  __ _ _ __| |_ 
 | |  | |/ _ \ |  < / _` |/ _` | '__| __|
 | |__| |  __/ | . \ (_| | (_| | |  | |_ 
 |_____/ \___| |_|\_\__,_|\__,_|_|   \__|
                                         
                                         ";


}