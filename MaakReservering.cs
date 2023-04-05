using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
namespace Reservering
{
    public static class Res
    {
         public class Item{

     string Name = "check";
            double PricePerUnit = 0;
    int Quantity = 0;

    public Item(string name,double pricePerUnit,int quantity)
    {
       Name = name;
       PricePerUnit = pricePerUnit;
       Quantity = quantity;

    }

    public double GetTotalPrice(double totalPrice)
    {

      totalPrice = PricePerUnit*Quantity;
      return totalPrice;
    }
    public string getInfo(string info)
    {
                double totalPrice = GetTotalPrice(0);
       info = Name+""+"total price:"+""+totalPrice;
      
       return info;
    }

}

        //Json bewaren
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
            public string Mail { get; set;}
            public Guest(int customerId, string customerName, string achternaam,bool alc, int tijdstip,string mail)
            {
                CustomerId = customerId;
                CustomerName = customerName;
                Achternaam = achternaam;
                Alc = alc;
                Tijdstip = tijdstip;
                Mail = mail;
            }
        }
        class Hoelang
        {
            public int Duration { get; set; }

            public Hoelang(int duration)
            {
                Duration = duration;
            }

            public static int tijdperiode(string text)
            {

                string pattern2 = ":";
                if (text == " ") { text = "2:30"; }
                while (!Regex.IsMatch(text, pattern2))
                {
                    Console.WriteLine("Ongeldig");
                    Console.WriteLine("Hoelang? ");
                    text = Console.ReadLine();
                    if (Regex.IsMatch(text, pattern2))
                    {

                        continue;
                    }

                }
                string[] words = text.Split(":");
                foreach (var word in words)
                {


                    Console.WriteLine(word);


                }
                int a = Convert.ToInt32(words[0]);
                int b = a * 60;
                int c = Convert.ToInt32(words[1]);
                int time_limit = c + b;

                return time_limit;
            }
        }
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
                    string next = tommorow.ToString();
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
            public static string get_Mail(string email)
            {
                while (true)
                {


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
                return email;
            }
        }
        class Tables
        {
           public string chosen_Table {get;set;}
            public Tables(string chosen_table)
            {
                chosen_table = chosen_Table;
            }
            static public string Tables_people(int amount_People,string chosen_table)
            {
                string[] tables_amount = { "2 persoons tafel"," 4 persoons tafel", " 8 persoons tafel"};
                string[] twee_tables = { "0","1", "2", " 3", "4", " 5", "6", " 7", "8" };
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
                                Console.Write($"| Tafel"+ twee_tables[i]+"|");

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
               
                if (amount_People >=3 && amount_People <= 4)
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
            //variablen
            string? res_naam;
            string? achternaam;
            string? res_alc;
            //check login
            bool login = false;


            //Menu variablen

            string[] tijdItems = { "Octhend", "Middag", "Avond" };



            //vragen guest
            Console.Write("Onders wiens naam?:");
            string[] achternaam_split = { "" };

            res_naam = Console.ReadLine();
            string patroon = " ";
            if (Regex.IsMatch(res_naam, patroon))
            {
                achternaam_split = res_naam.Split(" ");


            }
            achternaam = achternaam_split[1];
            // Hoe veel mensen
            Console.WriteLine("Hoeveel personen? ");
            int res_personen = Convert.ToInt32(Console.ReadLine());


            string? duration = "";
            Console.WriteLine("Hoelang? Max is 2:30");
            int time_limit = Hoelang.tijdperiode(duration);

            string? test_mail = "";
            if (login == false)
            {
                
                Console.WriteLine("Wat is uw email");
                test_mail = Console.ReadLine();
            }
           
            string gekozen_Dag = welke_Dag.MenuDagen();

            string gekozen_Tijd = Hoelaat.MenuTijd(gekozen_Dag);
            string user_mail = user_Mail.get_Mail(test_mail);

            int new_Id = Res_Id();
            bool test = false;
            string tel = "0616863729";

            string chosen_Table = "";
            Tables.Tables_people(res_personen,chosen_Table);


            Guest x = new Guest(new_Id, res_naam, achternaam, test, time_limit, user_mail);
            Console.WriteLine(x.CustomerId + "");
            Console.WriteLine(x.CustomerName + "");
            Console.WriteLine(x.Achternaam + "");
            Console.WriteLine(x.Tijdstip + ""+" minuten"+"");
            Console.WriteLine(x.Mail + "");


            string prefix = "RES-";
            string reservationCode = prefix + new_Id.ToString();

            Reservation tt = new Reservation(new_Id, res_naam, test, gekozen_Tijd, gekozen_Dag, time_limit, test_mail, tel,res_personen,reservationCode);
            if(login == false)
            { 
            //geen user is ongelogt
            }
            else
            {
                Save(tt);
            }
            



        }
        public static void Save(Reservation Reservering)
        {
            List<Reservation> Reserveringen;

            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                Reserveringen = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
                if (Reserveringen == null)
                {
                    Reserveringen = new List<Reservation>();
                }
            }
            else
            {
                Reserveringen = new List<Reservation>();
            }

            Reserveringen.Add(Reservering);

            string updatedData = JsonConvert.SerializeObject(Reserveringen);
            File.WriteAllText(jsonFilePath, updatedData);
            Console.WriteLine("Het maken van de reservering is gelukt! U wordt nu teruggebracht naar de beginpagina.");

            Thread.Sleep(4000);
            Inlogscherm.Keuzemenu();
        }
        public static int Res_Id()
    {
        Random random = new Random();
        int reservationNumber = random.Next(100000, 999999);
        //string prefix = "RES-";
       // string reservationCode = prefix + reservationNumber.ToString();
        return reservationNumber;
    }

        

    }



    }


