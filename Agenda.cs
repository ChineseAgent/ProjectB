public static class Agenda
{
    public static List<int> dates = new List<int>() { };

    public static void AddDates()
    {
        for (int i = 1; i < 31; i++)
        {
            dates.Add(i);
        }
    }
    public static int CheckIfUsed = 0;
    public static int SelectedDate = 1;
    public static void probeersel()
    {
        if (CheckIfUsed == 0)
        {
            AddDates();
            CheckIfUsed++;
        }
        Console.Clear();
        Inlogscherm.Logo();
        Console.Write("\nHoofdmenu>");
        Console.Write("Reserveren>");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write("Datum>");
        Console.ResetColor();
        Console.Write("Tijdslot>");
        Console.Write("Aanmelden>\n");
        Console.WriteLine("");
        Console.WriteLine("    APRIL 2023\n");
        Console.WriteLine("ZA ZO MA DI WO DO VR");
        int count = 0;

        foreach (int nummer in dates)
        {
            if (count == 7)
            {

                Console.Write("\n");
                count = 0;
            }
            count++;
            if (SelectedDate == nummer)
            {
                if (nummer < 10)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{nummer}  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{nummer} ");
                    Console.ResetColor();
                }
            }
            else
            {
                if (nummer < 10)
                {
                    Console.Write($"{nummer}  ");
                }
                else
                {

                    Console.Write($"{nummer} ");
                }
            }
        }
    }

    public static int DatePicker()
    {

        probeersel();
        while (true)

        {
            switch (Console.ReadKey(true).Key)

            {
                case ConsoleKey.LeftArrow:
                    if (SelectedDate > 1)
                    {

                        SelectedDate--;

                        probeersel();

                    }
                    else
                    {

                        probeersel();
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (SelectedDate < 30)
                    {
                        SelectedDate++;
                        probeersel();


                    }
                    else
                    {

                        probeersel();
                    }
                    break;

                case ConsoleKey.Enter:
                    return SelectedDate;





            }


        }
    }


}
