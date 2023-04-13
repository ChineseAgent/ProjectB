using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
public static class KiesReserveringsTijd
{
    public static int KiesTijd()
    {
        string[] options = new string[] { "10:00 - 12:00", "12:30 - 14:30", "15:00 - 17:00", "17:30 - 19:30", "20:00 - 22:00", "22:30 - 00:30", "\nGa terug" };
        int selectedOptionIndex = 0;

        while (true)
        {
            Console.Clear();
            Inlogscherm.Logo();
            Console.Write("\nHoofdmenu>");
            Console.Write("Reserveren>");
            Console.Write("Kies een datum>");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("Kies een tijdslot>");
            Console.ResetColor();
            Console.Write("Aanmelden");
            Console.WriteLine("");
            Console.WriteLine("\nGebruik de puiltjes toetsen om een keuze te maken:\n");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOptionIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && selectedOptionIndex > 0)
            {
                selectedOptionIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedOptionIndex < options.Length - 1)
            {
                selectedOptionIndex++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (selectedOptionIndex == 6)
                {
                    Res.start_reservation();
                }
                else
                {
                    Console.Clear();
                    Inlogscherm.Logo();
                    Console.Write("\nHoofdmenu>");
                    Console.Write("Reserveren>");
                    Console.Write("Kies een datum>");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("Kies een tijdslot>");
                    Console.ResetColor();
                    Console.Write("Aanmelden\n");
                    Console.WriteLine("");
                    Console.WriteLine($"\nU heeft gekozen voor: {options[selectedOptionIndex]}\n");
                    Console.WriteLine("Druk een toets in om verder te gaan...");
                    Console.ReadKey();
                    return selectedOptionIndex;

                }
                return selectedOptionIndex;

            }
        }
    }

    public static bool CheckReserveringsTijd(int dag, int index, int aantalpersonen)
    {
        dag--;
        string jsonString = File.ReadAllText("BeschikbareTafels.json");
        List<Day> days = JsonConvert.DeserializeObject<List<Day>>(jsonString);

        if (aantalpersonen < 3)
        {
            if (days[dag].timeslots[index].table_for_2 > 0)
            {
                days[dag].timeslots[index].table_for_2--;
                UpdateJson(days);
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (aantalpersonen < 5)
        {
            if (days[dag].timeslots[index].table_for_4 > 0)
            {
                days[dag].timeslots[index].table_for_4--;
                UpdateJson(days);
                return true;
            }
            else if (days[dag].timeslots[index].table_for_2 > 1)
            {

                days[dag].timeslots[index].table_for_2 -= 2;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (aantalpersonen < 7)
        {
            if (days[dag].timeslots[index].table_for_6 > 0)
            {
                days[dag].timeslots[index].table_for_6--;
                UpdateJson(days);
                return true;
            }
            else if (days[dag].timeslots[index].table_for_4 > 0 && days[dag].timeslots[index].table_for_2 > 0)
            {
                days[dag].timeslots[index].table_for_4--;
                days[dag].timeslots[index].table_for_2--;
                return true;
            }
            else if (days[dag].timeslots[index].table_for_2 > 2)
            {
                days[dag].timeslots[index].table_for_2 -= 3;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (aantalpersonen < 11)
        {
            if (aantalpersonen == 8)
            {
                if (days[dag].timeslots[index].table_for_4 > 1)
                {
                    days[dag].timeslots[index].table_for_4 -= 2;
                    UpdateJson(days);
                    return true;
                }
                else if (days[dag].timeslots[index].table_for_4 == 1 && days[dag].timeslots[index].table_for_2 > 1)
                {
                    days[dag].timeslots[index].table_for_4 -= 1;
                    days[dag].timeslots[index].table_for_2 -= 2;
                    UpdateJson(days);
                    return true;
                }
                else if (days[dag].timeslots[index].table_for_6 > 0 && days[dag].timeslots[index].table_for_2 > 0)
                {
                    days[dag].timeslots[index].table_for_6 -= 1;
                    days[dag].timeslots[index].table_for_2 -= 1;
                    UpdateJson(days);
                    return true;
                }
                else if (days[dag].timeslots[index].table_for_4 == 0 && days[dag].timeslots[index].table_for_6 == 0 && days[dag].timeslots[index].table_for_2 > 3)
                {
                    days[dag].timeslots[index].table_for_2 -= 4;
                    UpdateJson(days);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // check if there are enough tables available to accommodate the reservation
            int table_for_6 = days[dag].timeslots[index].table_for_6;
            int table_for_4 = days[dag].timeslots[index].table_for_4;
            int table_for_2 = days[dag].timeslots[index].table_for_2;

            if (table_for_6 >= (aantalpersonen - 4))
            {
                // reserve a table for 6 and a table for 2
                if (table_for_2 > 0)
                {
                    days[dag].timeslots[index].table_for_6--;
                    days[dag].timeslots[index].table_for_2--;
                    UpdateJson(days);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (table_for_4 >= (aantalpersonen - 2))
            {
                // reserve two tables for 4
                if (table_for_4 >= 2)
                {
                    days[dag].timeslots[index].table_for_4 -= 2;
                    UpdateJson(days);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (table_for_6 > 0 && table_for_4 > 0)
            {
                // reserve a table for 6 and a table for 4
                days[dag].timeslots[index].table_for_6--;
                days[dag].timeslots[index].table_for_4--;
                UpdateJson(days);
                return true;
            }
            else if (table_for_2 >= (aantalpersonen - 6))
            {
                // reserve three tables for 2
                if (table_for_2 >= 3)
                {
                    days[dag].timeslots[index].table_for_2 -= 3;
                    UpdateJson(days);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (table_for_6 > 1)
            {
                // reserve two tables for 6
                if (table_for_6 >= 2)
                {
                    days[dag].timeslots[index].table_for_6 -= 2;
                    UpdateJson(days);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // not enough tables available to accommodate the reservation
                return false;
            }
        }
        return false;
    }




    private static void UpdateJson(List<Day> days)
    {
        string jsonString = JsonConvert.SerializeObject(days);
        File.WriteAllText("BeschikbareTafels.json", jsonString);
    }

    public class TimeSlot
    {
        public string time { get; set; }
        public int table_for_2 { get; set; }
        public int table_for_4 { get; set; }
        public int table_for_6 { get; set; }
        public bool table_free { get; set; }
    }

    public class Day
    {
        public int day { get; set; }
        public List<TimeSlot> timeslots { get; set; }
    }
}
