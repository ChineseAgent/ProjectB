public static class TableView
{
    public static bool gevonden = false;
    public static string Tafel0 = "";
    public static bool Beschikbaar;
    public static int TafelNummer;
    public static int HoeveelPlek;
    public static List<Table> tables = new List<Table>();


    // make all the tables and then put them in a list, eight 2-person tables, five 4-person tables and Jake has two tables for groups of 6 people
    public static List<Table> CreateTables()
    {
        for (int i = 1; i <= 8; i++)
        {
            tables.Add(new Table(i, 2));
        }
        for (int i = 9; i <= 13; i++)
        {
            tables.Add(new Table(i, 4));
        }
        for (int i = 14; i <= 15; i++)
        {
            tables.Add(new Table(i, 6));
        }
        return tables;
    }

    public static void ReserveerTafel(int HoeveelPlek)
    {
        gevonden = false;
        foreach (Table table in tables)
        {
            if (table.HoeveelPlek == HoeveelPlek && table.Beschikbaar == true)
            {
                table.Beschikbaar = false;
                gevonden = true;
                Console.WriteLine($"Uw reserving is gemaakt voor tafel {table.TafelNummer}");
                break;
            }

        }
        if (gevonden == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Er zijn geen tafels meer voor uw groepsgrootte die beschikbaar zijn.");
            Console.ResetColor();

        }

    }

    public static void Tafelindeling()
    {
        Console.Clear();
        Inlogscherm.Logo();
        Console.Write("Hoofdmenu>");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("Plattegrond>");
        Console.WriteLine("");
        Console.ResetColor();
        string filePath = "Tafelindeling.txt";
        string text = System.IO.File.ReadAllText(filePath);
        Console.Write(text);
        Console.WriteLine("");
        Console.WriteLine("\nDruk een toets in om terug te gaan naar het hoofdmenu.");
        Console.ReadKey();
        Inlogscherm.Keuzemenu();
    }

}