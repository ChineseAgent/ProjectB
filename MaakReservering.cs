using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


/*public static class MaakReservering

public static class MaakReservering

{
    private static List<DateTime> tijdSloten = new List<DateTime>();
    private static int selectedIndex = 0;
    private static string jsonFilePath = "Reserveringen.json";

    public static void TijdSloten()
    {
        DateTime currentTime = DateTime.Today.AddHours(8);
        DateTime endTime = DateTime.Today.AddHours(23);

        while (currentTime < endTime)
        {
            tijdSloten.Add(currentTime);
            currentTime = currentTime.AddMinutes(120);
            tijdSloten.Add(currentTime);
            currentTime = currentTime.AddMinutes(30);
        }

        Console.WriteLine("Beschikbare tijdsloten:");

        for (int i = 0; i < tijdSloten.Count; i += 2)
        {
            Console.WriteLine($"{i + 1}. {tijdSloten[i].ToString("HH:mm")} - {tijdSloten[i + 1].ToString("HH:mm")}");
        }
    }

    public static void KiesTijd()
    {
        Console.Clear();
        Console.WriteLine("Met hoeveel personen bent u?");
        int hoeveelheid = int.Parse(Console.ReadLine());
        ConsoleKey key;
        do
        {
            Console.Clear();
            Console.WriteLine("Selecteer een tijdslot:");
            for (int i = 0; i < tijdSloten.Count; i += 2)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                Console.WriteLine($"{i + 1}. {tijdSloten[i].ToString("HH:mm")} - {tijdSloten[i + 1].ToString("HH:mm")}");
            }

            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 2);
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(tijdSloten.Count - 2, selectedIndex + 2);
                    break;
            }
        } while (key != ConsoleKey.Enter);

        DateTime gekozenTijd = tijdSloten[selectedIndex];
        Console.WriteLine($"\nJe hebt gekozen voor {gekozenTijd.ToString("HH:mm")} - {(gekozenTijd.AddMinutes(150)).ToString("HH:mm")}");
        if (Account.CurrentUser.Email == null)
        {
            Console.WriteLine("Voer je gegevens in:");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Voornaam: ");
            string firstName = Console.ReadLine();
            Console.Write("Tussenvoegsel: ");
            string tussenvoegsel = Console.ReadLine();
            Console.Write("Achternaam: ");
            string lastName = Console.ReadLine();
            Console.Write("Telefoonnummer: ");
            string phoneNumber = Console.ReadLine();
            SendEmail.SendReservationConfirmation(email, "Geen idee welke dag nog", gekozenTijd.ToString("HH:mm"));
        }
        else
        {

            Reservering NieuweReservering = new Reservering(Account.CurrentUser.CustomerId, Account.CurrentUser.Email, Account.CurrentUser.Achternaam, Account.CurrentUser.Telefoonnummer, hoeveelheid, gekozenTijd.ToString("HH:mm"), ReserveringsCode());
            StuurNaarJson(NieuweReservering);
            SendEmail.SendReservationConfirmation(Account.CurrentUser.Email, "Geen idee welke dag nog", gekozenTijd.ToString("HH:mm"));


            Console.WriteLine("Het maken van de reservering is gelukt! U wordt nu teruggebracht naar de beginpagina.");
            Thread.Sleep(2000);

        }

    }

    public static void StuurNaarJson(Reservering Reservering)
    {
        List<Reservering> Reserveringen;

        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            Reserveringen = JsonConvert.DeserializeObject<List<Reservering>>(jsonData);
            if (Reserveringen == null)
            {
                Reserveringen = new List<Reservering>();
            }
        }
        else
        {
            Reserveringen = new List<Reservering>();
        }

        Reserveringen.Add(Reservering);

        string updatedData = JsonConvert.SerializeObject(Reserveringen);
        File.WriteAllText(jsonFilePath, updatedData);

        Console.WriteLine("Het maken van de reservering is gelukt! U wordt nu teruggebracht naar de beginpagina.");



        Thread.Sleep(4000);
        Inlogscherm.Keuzemenu();
    }

    public static string ReserveringsCode()
    {
        Random random = new Random();
        int reservationNumber = random.Next(100000, 999999);
        string prefix = "RES-";
        string reservationCode = prefix + reservationNumber.ToString();
        return reservationCode;
    }

}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

using System.Text.Json;
using System.Text.Json.Serialization;

using System.IO;

using System.Collections.Generic;
using System.Text.RegularExpressions;
public static class Res
{
    //Json bewaren
    public static string gekozen_Tijd;
    public static List<Reservation> resList = new List<Reservation>();
    private static string jsonFilePath = "Reserveringen.json";
    //tafels
    public static bool gevonden = false;
    public static string Tafel0 = "";
    public static bool Beschikbaar;
    public static int TafelNummer;
    public static int HoeveelPlek;
    public static List<Table> tables = new List<Table>();


    class Guest
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Achternaam { get; set; }
        public bool Alc { get; set; }
        public int Tijdstip { get; set; }
        public string Mail { get; set; }
        public Guest(int customerId, string customerName, string achternaam, bool alc, int tijdstip, string mail)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Achternaam = achternaam;
            Alc = alc;
            Tijdstip = tijdstip;
            Mail = mail;
        }
    }
    public class Hoelang
    {
        public int Duration { get; set; }

        public Hoelang(int duration)
        {
            Duration = duration;
        }

        //     public static int tijdperiode(string text)
        //     {

        //         string pattern2 = ":";
        //         if (text == " ") { text = "2:30"; }
        //         while (!Regex.IsMatch(text, pattern2))
        //         {
        //             Console.WriteLine("Ongeldig");
        //             Console.WriteLine("Hoelang? ");
        //             text = Console.ReadLine();
        //             if (Regex.IsMatch(text, pattern2))
        //             {

        //                 continue;
        //             }

        //         }
        //         string[] words = text.Split(":");
        //         foreach (var word in words)
        //         {


        //             Console.WriteLine(word);


        //         }
        //         int a = Convert.ToInt32(words[0]);
        //         int b = a * 60;
        //         int c = Convert.ToInt32(words[1]);
        //         int time_limit = c + b;

        //         return time_limit;
        //     }
        // }
        class welke_Dag
        {
            public string dag_Week { get; set; }

            public welke_Dag(string dag_week)
            {
                dag_Week = dag_week;
            }
            static public string MenuDagen()
            {
                //variablen

                List<string> Dagen = new List<string>();
                string? gekozen_Dag = "";
                int num = 0;
                //tijd
                DateTime today = DateTime.Today;
                string now = today.ToString();
                Dagen.Add(now);
                for (int i = 0; i < 6; i++)
                {
                    num++;
                    DateTime tommorow = today.AddDays(num);
                    string next = tommorow.ToString("yyyy-MM-dd");
                    Dagen.Add(next);
                }
                string[] dagItems = Dagen.ToArray();

                // Set the default selection
                int selectedMenuItem = 0;

                // Loop until the user selects an option
                while (true)
                {

                    // Print the menu
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("Maak uw keuze:");
                    for (int i = 0; i < dagItems.Length; i++)
                    {
                        if (i == selectedMenuItem)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(dagItems[i]);
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
                            if (selectedMenuItem < dagItems.Length - 1)
                            {
                                selectedMenuItem++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            // De gebruiker heeft een optie geselecteerd
                            if (selectedMenuItem == 0)
                            {
                                // vandaag
                                Console.Clear();
                                Console.WriteLine(dagItems[0]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[0];
                                return gekozen_Dag;
                            }
                            else if (selectedMenuItem == 1)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(dagItems[1]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[1];
                                return gekozen_Dag;
                            }
                            else if (selectedMenuItem == 2)
                            {
                                // dag+2
                                Console.Clear();
                                Console.WriteLine(dagItems[2]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[2];
                                return gekozen_Dag;
                            }
                            else if (selectedMenuItem == 3)
                            {
                                // dag+3
                                Console.Clear();
                                Console.WriteLine(dagItems[3]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[3];
                                return gekozen_Dag;
                            }
                            else if (selectedMenuItem == 4)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(dagItems[4]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[4];
                                return gekozen_Dag;
                            }
                            else if (selectedMenuItem == 5)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(dagItems[5]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[5];
                                return gekozen_Dag;
                            }
                            else if (selectedMenuItem == 6)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(dagItems[6]);
                                Console.ReadKey(true);
                                gekozen_Dag = dagItems[6];
                                return gekozen_Dag;
                            }


                            else if (selectedMenuItem == 7)
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
                                return gekozen_Dag;
                            }
                            return gekozen_Dag;


                    }
                }
            }
        }
        class Hoelaat
        {
            public int Tijdstip { get; set; }

            public Hoelaat(int tijdstip)
            {
                Tijdstip = tijdstip;
            }
            static public string MenuTijd(string gekozen_Dag)
            {
                //variablen

                List<string> Tijden = new List<string>();
                string? gekozen_Tijd = "";
                int num = 0;
                DateTime now = DateTime.Now;
                int hour = now.Hour;
                //tijd
                DateTime today = DateTime.Today;
                string ochtend = "9:00/12:30";
                string middag = "13:00/17:30";
                string avond = "18:00/24:30";

                /* KAN TIJD LIIMITEREN OP BASIS VAN DAG MAAR MAAKT HET IETS MOEILIJKER VOOR MIJ IK BEN LUI(S)
                if (hour<12) { Tijden.Add(ochtend); }

                if (hour >12 && hour<18){ Tijden.Add(middag); }
                if (hour > 18 && hour < 9) { Tijden.Add(avond); }
                */
                Tijden.Add(ochtend);

                Tijden.Add(middag);
                Tijden.Add(avond);

                string[] tijdItems = Tijden.ToArray();

                // Set the default selection
                int selectedMenuItem = 0;

                // Loop until the user selects an option
                while (true)
                {

                    // Print the menu
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("Maak uw keuze:");
                    for (int i = 0; i < tijdItems.Length; i++)
                    {
                        if (i == selectedMenuItem)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(tijdItems[i]);
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
                            if (selectedMenuItem < tijdItems.Length - 1)
                            {
                                selectedMenuItem++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            // De gebruiker heeft een optie geselecteerd
                            if (selectedMenuItem == 0)
                            {
                                // vandaag
                                Console.Clear();
                                Console.WriteLine(tijdItems[0]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[0];
                                return gekozen_Tijd;
                            }
                            else if (selectedMenuItem == 1)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(tijdItems[1]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[1];
                                return gekozen_Tijd;
                            }
                            else if (selectedMenuItem == 2)
                            {
                                // dag+2
                                Console.Clear();
                                Console.WriteLine(tijdItems[2]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[2];
                                return gekozen_Tijd;
                            }
                            else if (selectedMenuItem == 3)
                            {
                                // dag+3
                                Console.Clear();
                                Console.WriteLine(tijdItems[3]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[3];
                                return gekozen_Tijd;
                            }
                            else if (selectedMenuItem == 4)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(tijdItems[4]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[4];
                                return gekozen_Tijd;
                            }
                            else if (selectedMenuItem == 5)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(tijdItems[5]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[5];
                                return gekozen_Tijd;
                            }
                            else if (selectedMenuItem == 6)
                            {
                                // dag+1
                                Console.Clear();
                                Console.WriteLine(tijdItems[6]);
                                Console.ReadKey(true);
                                gekozen_Tijd = tijdItems[6];
                                return gekozen_Tijd;
                            }


                            else if (selectedMenuItem == 7)
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
                                return gekozen_Tijd;
                            }
                            return gekozen_Tijd;


                    }
                }
            }
        }
        class user_Mail
        {
            public string Customer_mail { get; set; }

            public user_Mail(string customer_mail)
            {
                Customer_mail = customer_mail;
            }

        }

        class Tables
        {
            public string chosen_Table { get; set; }
            public Tables(string chosen_table)
            {
                chosen_table = chosen_Table;
            }
            static public string Tables_people(int amount_People, string chosen_table)
            {
                string[] tables_amount = { "2 persoons tafel", " 4 persoons tafel", " 8 persoons tafel" };
                string[] twee_tables = { "0", "1", "2", " 3", "4", " 5", "6", " 7", "8" };
                string[] four_tables = { "0", "1", "2", " 3", "4", " 5" };
                string[] six_tables = { "0", "1" };
                // Set the default selection
                int selectedMenuItem = 0;

                if (amount_People <= 2)
                {
                    while (true)
                    {
                        // Read the user's input

                        Console.Clear();
                        Console.WriteLine("----- Tafelindeling -----");
                        Console.WriteLine("2-persoons tafels: Hoeveelheid tafels");
                        Console.WriteLine("+------+  +------+  +------+  +------+  +------+  +------+  +------+  +------+");
                        for (int i = 0; i < twee_tables.Length; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (i == selectedMenuItem)
                            {
                                Console.Write($"| Tafel" + twee_tables[i] + "|");

                            }
                            // Console.WriteLine(twee_tables[i]);
                            Console.ResetColor();


                        }
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        switch (keyInfo.Key)
                        {


                            case ConsoleKey.LeftArrow:
                                if (selectedMenuItem > 0)
                                {
                                    selectedMenuItem--;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (selectedMenuItem < twee_tables.Length - 1)
                                {
                                    selectedMenuItem++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                // De gebruiker heeft een optie geselecteerd
                                if (selectedMenuItem == 0)
                                {
                                    // vandaag
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[0]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[0];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 1)
                                {
                                    // dag+1
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[1]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[1];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 2)
                                {
                                    // dag+2
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[2]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[2];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 3)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[3]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[3];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 4)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[4]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[4];
                                    return chosen_table;
                                }

                                else if (selectedMenuItem == 5)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[5]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[5];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 6)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[6]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[6];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 7)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[7]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[7];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 8)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(twee_tables[8]);
                                    Console.ReadKey(true);
                                    chosen_table = twee_tables[8];
                                    return chosen_table;
                                }
                                return chosen_table;
                        }

                    }

                }

                if (amount_People >= 3 && amount_People <= 4)
                {
                    while (true)
                    {
                        // Read the user's input

                        Console.Clear();
                        Console.WriteLine("----- Tafelindeling -----");
                        Console.WriteLine("4-persoons tafels: Hoeveelheid tafels");
                        Console.WriteLine("+------+  +------+  +------+  +------+  +------+ ");
                        for (int i = 0; i < twee_tables.Length; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (i == selectedMenuItem)
                            {
                                Console.Write($"| Tafel" + twee_tables[i] + "|");

                            }
                            // Console.WriteLine(twee_tables[i]);
                            Console.ResetColor();


                        }
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        switch (keyInfo.Key)
                        {


                            case ConsoleKey.LeftArrow:
                                if (selectedMenuItem > 0)
                                {
                                    selectedMenuItem--;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (selectedMenuItem < four_tables.Length - 1)
                                {
                                    selectedMenuItem++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                // De gebruiker heeft een optie geselecteerd
                                if (selectedMenuItem == 0)
                                {
                                    // vandaag
                                    Console.Clear();
                                    Console.WriteLine(four_tables[0]);
                                    Console.ReadKey(true);
                                    chosen_table = four_tables[0];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 1)
                                {
                                    // dag+1
                                    Console.Clear();
                                    Console.WriteLine(four_tables[1]);
                                    Console.ReadKey(true);
                                    chosen_table = four_tables[1];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 2)
                                {
                                    // dag+2
                                    Console.Clear();
                                    Console.WriteLine(four_tables[2]);
                                    Console.ReadKey(true);
                                    chosen_table = four_tables[2];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 3)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(four_tables[3]);
                                    Console.ReadKey(true);
                                    chosen_table = four_tables[3];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 4)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(four_tables[4]);
                                    Console.ReadKey(true);
                                    chosen_table = four_tables[4];
                                    return chosen_table;
                                }

                                else if (selectedMenuItem == 5)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(four_tables[5]);
                                    Console.ReadKey(true);
                                    chosen_table = four_tables[5];
                                    return chosen_table;
                                }
                                return chosen_table;
                        }

                    }

                }
                if (amount_People >= 5 && amount_People <= 6)
                {
                    while (true)
                    {
                        // Read the user's input

                        Console.Clear();
                        Console.WriteLine("----- Tafelindeling -----");
                        Console.WriteLine("6-persoons tafels: Hoeveelheid tafels");
                        Console.WriteLine("+------+  +------+   ");
                        for (int i = 0; i < six_tables.Length; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (i == selectedMenuItem)
                            {
                                Console.Write($"| Tafel" + six_tables[i] + "|");

                            }
                            // Console.WriteLine(twee_tables[i]);
                            Console.ResetColor();


                        }
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        switch (keyInfo.Key)
                        {


                            case ConsoleKey.LeftArrow:
                                if (selectedMenuItem > 0)
                                {
                                    selectedMenuItem--;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (selectedMenuItem < six_tables.Length - 1)
                                {
                                    selectedMenuItem++;
                                }
                                break;
                            case ConsoleKey.Enter:
                                // De gebruiker heeft een optie geselecteerd
                                if (selectedMenuItem == 0)
                                {
                                    // vandaag
                                    Console.Clear();
                                    Console.WriteLine(six_tables[0]);
                                    Console.ReadKey(true);
                                    chosen_table = six_tables[0];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 1)
                                {
                                    // dag+1
                                    Console.Clear();
                                    Console.WriteLine(six_tables[1]);
                                    Console.ReadKey(true);
                                    chosen_table = six_tables[1];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 2)
                                {
                                    // dag+2
                                    Console.Clear();
                                    Console.WriteLine(six_tables[2]);
                                    Console.ReadKey(true);
                                    chosen_table = six_tables[2];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 3)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(six_tables[3]);
                                    Console.ReadKey(true);
                                    chosen_table = six_tables[3];
                                    return chosen_table;
                                }
                                else if (selectedMenuItem == 4)
                                {
                                    // dag+3
                                    Console.Clear();
                                    Console.WriteLine(six_tables[4]);
                                    Console.ReadKey(true);
                                    chosen_table = six_tables[4];
                                    return chosen_table;
                                }

                                return chosen_table;
                        }

                    }

                }
                return chosen_table;
            }


        }
        public static void start_reservation()
        {
            Console.Clear();
            Inlogscherm.Logo();
            Console.Write("\nHoofdmenu>");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Reserveren>");
            Console.ResetColor();
            Console.WriteLine("");
            //variablen
            string? res_naam;
            string? achternaam;
            string? res_alc;
            //check login
            bool login = false;


            //Menu variablen



            //vragen guest
            Console.Clear();
            Inlogscherm.Logo();
            Console.Write("\nHoofdmenu>");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("Reserveren>");
            Console.ResetColor();
            Console.Write("Datum>");
            Console.Write("Tijdslot>");
            Console.Write("Aanmelden");
            Console.WriteLine("");
            // Hoe veel mensen
            Console.Write("\nHoeveel personen?: ");
            int res_personen = Convert.ToInt32(Console.ReadLine());



            int gekozen_Tijd_Int = 0;

            int gekozen_Dag_Int = 0;

            gekozen_Dag_Int = Agenda.DatePicker();
            string gekozen_Dag = $"2023-04-{gekozen_Dag_Int}";

            while (true)
            {
                gekozen_Tijd_Int = KiesReserveringsTijd.KiesTijd();
                if (KiesReserveringsTijd.CheckReserveringsTijd(gekozen_Dag_Int, gekozen_Tijd_Int, res_personen))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Inlogscherm.Logo();
                    Console.Write("\nHoofdmenu>");
                    Console.Write("Reserveren>");
                    Console.WriteLine("Datum>");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Tijdslot>");
                    Console.ResetColor();
                    Console.Write("Aanmelden");
                    Console.WriteLine("");
                    Console.WriteLine("\nDeze tijd is al bezet, kies een andere tijd");
                    Console.WriteLine("Druk op een toets om het opnieuw te proberen");
                    Console.ReadKey(true);


                }
            }
            // Console.WriteLine(gekozen_Tijd);

            switch (gekozen_Tijd_Int)
            {
                case 0:
                    gekozen_Tijd = "10:00 - 12:00";
                    break;
                case 1:
                    gekozen_Tijd = "12:30 - 14:30";
                    break;
                case 2:
                    gekozen_Tijd = "15:00 - 17:00";
                    break;
                case 3:
                    gekozen_Tijd = "17:30 - 19:30";
                    break;
                case 4:
                    gekozen_Tijd = "20:00 - 22:00";
                    break;
                case 5:
                    gekozen_Tijd = "22:30 - 00:30";
                    break;
            }

            string new_Id = Res_Id();


            // string chosen_Table = "";
            // Tables.Tables_people(res_personen, chosen_Table);
            string ReserveringsID = "";
            ReserveringsID = Res_Id();


            if (Account.CurrentUser.Email == null)
            {
                //vraag of door wilt gaan als gast of wilt inloggen

                // maak keuzemenu dat bestuurbaar is met pijltjes toetsen
                string[] menuItems = { "Inloggen", "Registreren", "Doorgaan als gast" };
                int selectedMenuItem = 0;
                while (true)
                {
                    Console.Clear();
                    Inlogscherm.Logo();
                    Console.Write("\nHoofdmenu>");
                    Console.Write("Reserveren>");
                    Console.Write("Datum>");
                    Console.Write("Tijdslot>");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Aanmelden");

                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("\nU bent niet ingelogd, wilt u doorgaan als gast of inloggen?");
                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        if (i == selectedMenuItem)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(menuItems[i]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(menuItems[i]);
                        }
                    }
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (selectedMenuItem > 0)
                        {
                            selectedMenuItem--;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (selectedMenuItem < menuItems.Length - 1)
                        {
                            selectedMenuItem++;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (selectedMenuItem == 0)
                        {
                            // inloggen
                            Console.Clear();
                            Account.Login();
                            Reservation res = new Reservation(Account.CurrentUser.CustomerId, Account.CurrentUser.Voornaam, Account.CurrentUser.TussenVoegsel, Account.CurrentUser.Achternaam, Account.CurrentUser.Telefoonnummer, Account.CurrentUser.Email, gekozen_Dag, gekozen_Tijd, res_personen, ReserveringsID);
                            Save(res);
                            Console.ReadKey();
                            Inlogscherm.Keuzemenu();
                            break;
                        }
                        else if (selectedMenuItem == 1)
                        {
                            // Registreren
                            Console.Clear();
                            Account.Registreer();
                            Reservation res = new Reservation(Account.CurrentUser.CustomerId, Account.CurrentUser.Voornaam, Account.CurrentUser.TussenVoegsel, Account.CurrentUser.Achternaam, Account.CurrentUser.Telefoonnummer, Account.CurrentUser.Email, gekozen_Dag, gekozen_Tijd, res_personen, ReserveringsID);
                            Save(res);
                            Console.ReadKey();
                            Inlogscherm.Keuzemenu();
                            break;
                        }
                        else if (selectedMenuItem == 2)
                        {
                            // Doorgaan als gast
                            Console.Clear();
                            Console.Clear();
                            Inlogscherm.Logo();
                            Console.Write("\nHoofdmenu>");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Reserveren>");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("\nVoer uw gegevens in , * is verplicht");
                            Console.Write("*Voornaam: ");
                            string? Voornaam = Console.ReadLine();
                            Console.Write("Tussenvoegsel: ");
                            string? Tussenvoegsel = Console.ReadLine();
                            Console.Write("*Achternaam: ");
                            string? Achternaam = Console.ReadLine();
                            Console.Write("*Telefoonnummer: ");
                            string? Telefoonnummer = Console.ReadLine();
                            Console.Write("*Email: ");
                            string? Email = Console.ReadLine();
                            Reservation res = new Reservation(1000, Voornaam, Tussenvoegsel, Achternaam, Telefoonnummer, Email, gekozen_Dag, gekozen_Tijd, res_personen, ReserveringsID);
                            Save(res);
                            Console.ReadKey();
                            Inlogscherm.Keuzemenu();
                            break;
                        }
                        break;
                    }
                }

            }
            else
            {
                Reservation res = new Reservation(Account.CurrentUser.CustomerId, Account.CurrentUser.Voornaam, Account.CurrentUser.TussenVoegsel, Account.CurrentUser.Achternaam, Account.CurrentUser.Telefoonnummer, Account.CurrentUser.Email, gekozen_Dag, gekozen_Tijd, res_personen, ReserveringsID);
                Save(res);
                Console.ReadKey();
                Inlogscherm.Keuzemenu();
            }










        }
        public static void Save(Reservation Reservering)
        {
            if (Reservering == null)
            {
                Console.WriteLine("Error: Reservering is null.");
                return;
            }

            List<Reservation> Reserveringen;

            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                //check if file is empty
                if (jsonData == "")
                {
                    Reserveringen = new List<Reservation>();
                }
                else
                {
                    Reserveringen = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
                }

            }
            else
            {
                Reserveringen = new List<Reservation>();
            }

            Reserveringen.Add(Reservering);

            string updatedData = JsonConvert.SerializeObject(Reserveringen);
            File.WriteAllText(jsonFilePath, updatedData);
            Console.WriteLine($"Het maken van de reservering is gelukt! Uw reserveringscode is: {Reservering.ReserveringsNummer}\n");
            Console.WriteLine("Druk een toets in om terug te gaan naar het hoofdmenu...");
            Console.ReadKey();
            Inlogscherm.Keuzemenu();
        }

        public static string Res_Id()
        {
            Random random = new Random();
            int reservationNumber = random.Next(100000, 999999);
            string prefix = "RES-";
            string reservationCode = prefix + reservationNumber.ToString();
            return reservationCode;
        }

        static void Check_full()
        {
            int open_tafels = 10;
            if (open_tafels >= 1)
            {
                open_tafels = open_tafels - 1;

            }
            else if (open_tafels == 0)
            {
                Console.WriteLine("Het restaurant is vol");
            }




        }

    }






}


