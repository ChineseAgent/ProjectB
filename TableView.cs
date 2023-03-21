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
        Console.WriteLine("----- Tafelindeling -----");
        Console.WriteLine("2-persoons tafels:");
        Console.WriteLine("+------+  +------+  +------+  +------+  +------+  +------+  +------+  +------+");

        for (int i = 0; i < 8; i++)
        {
            if (tables[i].Beschikbaar)
            {
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n+------+  +------+  +------+  +------+  +------+  +------+  +------+  +------+");
        Console.WriteLine();
        Console.WriteLine("4-persoons tafels:");
        Console.WriteLine("+--------+  +--------+  +--------+  +--------+  +--------+");

        for (int i = 8; i < 13; i++)
        {
            if (tables[i].Beschikbaar)
            {
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|   ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n+--------+  +--------+  +--------+  +--------+  +--------+");
        Console.WriteLine();
        Console.WriteLine("6-persoons tafels:");
        Console.WriteLine("+----------+  +----------+");

        for (int i = 13; i < 15; i++)
        {
            if (tables[i].Beschikbaar)
            {
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|    ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| Tafel{i.ToString().PadLeft(2, ' ')}|");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n+----------+  +----------+");
        Console.WriteLine();
        Console.WriteLine("Overige informatie:");
        Console.WriteLine("- Er zijn in totaal 8 2-persoons tafels, 5 4-persoons tafels en 2 6-persoons tafels.");
        Console.WriteLine("- Tafels worden aangeduid met een uniek ID-nummer van 0 t/m 16.");
    }
}