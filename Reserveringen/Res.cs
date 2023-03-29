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
    internal class Res
    {

        public static List<Reservation> resList = new List<Reservation>();


        class Guest
        {
            public int Id { get; set; }
            public string Naam { get; set; }
            public string Achternaam { get; set; }
            public int Tijdstip { get; set; }
            public Guest(int id, string naam, string achternaam, int tijdstip)
            {
                Id = id;
                Naam = naam;
                Achternaam = achternaam;
                Tijdstip = tijdstip;

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
        static void Main(string[] args)
        {
            //variablen
            string? res_naam;
            string? achternaam;
            string? res_alc;



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
            Console.WriteLine("Hoelang? Als  er niks wordt ingetypt De standaard is 2 uur en 30 minuten");
            int time_limit = Hoelang.tijdperiode(duration);



            string gekozen_Dag = welke_Dag.MenuDagen();

            string gekozen_Tijd = Hoelaat.MenuTijd(gekozen_Dag);






            Guest x = new Guest(1, res_naam, achternaam, time_limit);

        }


        /*   static public void Main()
           {

               Console.WriteLine("Maak hier uw reservering, uw naam? ");

               // Onder wiens naam
               string? res_naam;
               string? res_alc;
               string[] menuItems = { "Informatie", "De kaart", "Reserveer", "Login", "Afsluiten" };


               //Console.Write("Onders wiens naam?:");
               res_naam = Console.ReadLine();


               // Hoe veel mensen
               Console.WriteLine("Hoeveel personen? ");
               int res_personen = Convert.ToInt32(Console.ReadLine());

               Console.Write("Alcohol mag? Ja/Nee");
               res_alc = Console.ReadLine();
               bool res_alcohol = false;


               if (res_alc == "Ja")
               {
                   res_alcohol = true;
               }
               else if (res_alc == "")
               { res_alcohol = false; }

               DateTime myDate = new DateTime(2015, 12, 25, 10, 00, 45);
               string dagWeek = "";


               int minute = myDate.Minute;
               string? duration = "";




               Console.WriteLine("Hoelaat? ");
               string? hour = Console.ReadLine();

               string pattern = ":";
               while (!Regex.IsMatch(hour, pattern))
               {
                   Console.WriteLine("Ongeldig tijdstip.");
                   Console.WriteLine("Hoelaat? ");
                   hour = Console.ReadLine();
                   if (Regex.IsMatch(hour, pattern))
                   {

                       continue;
                   }

               }


               string[] ww = hour.Split(":");

               string tijd_stip = ww[0] + ww[1];


               Console.WriteLine("Hoelang? Als er niks wordt ingetypt De standaard is 2 uur en 30 minuten");
               string pattern2 = ":";
               duration = Console.ReadLine();
               if (duration ==" ") { duration = "2:30"; }
               while (!Regex.IsMatch(duration, pattern))
               {
                   Console.WriteLine("Ongeldig");
                   Console.WriteLine("Hoelang? ");
                   duration = Console.ReadLine();
                   if (Regex.IsMatch(duration, pattern))
                   {

                       continue;
                   }

               }

               string[] words = duration.Split(":");
               foreach (var word in words)
               {


                   Console.WriteLine(word);


               }
               int a = Convert.ToInt32(words[0]);
               int b = a * 60;
               int c = Convert.ToInt32(words[1]);
               int time_limit = c + b;


               Res_start(res_naam, res_personen, res_alcohol, tijd_stip, dagWeek,myDate,time_limit);

           }

   static void Res_start(string name, int people, bool drinking, string time, string dag, DateTime myDate,int time_limit)
{
    int res_number = 1;

    //Menu tijdsloten
    string[] menuItems = { "Informatie", "De kaart", "Reserveer", "Login", "Afsluiten" };





    int weekDay = (int)myDate.DayOfWeek;
    string z = "";
    if (weekDay == 1)
    { z = "Maandag"; }
    else if (weekDay == 2)
    { z = "Dinsdag"; }
    else if (weekDay == 3)
    { z = "Woensdag"; }
    else if (weekDay == 4)
    { z = "Donderdag"; }
    else if (weekDay == 5)
    { z = "Vrijdag"; }
    else if (weekDay == 6)
    { z = "Zaterdag"; }
    else if (weekDay == 7)
    { z = "Zondag"; }

    dag = z;

    Check_full();
    // Console.WriteLine(name);
    //Print_receipt( res_number,name, people, drinking, time, minuut, dag,time_limit);
    Res_save(res_number, name, people, drinking, time, dag, time_limit);

}
*/
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

        static void Print_receipt(int g, string a, int b, bool c, string d, int e, string f, int h)
        {
            Console.Write("reservering nummer " + g + " ");
            Console.Write("naam " + a + " ");
            Console.Write("Hoeveelheid mensen " + b + " ");
            Console.Write("Alcohol mag? " + c + " ");
            Console.Write("Tijd afspraak: " + d + ":" + e + " " + f + " ");
            Console.Write("Gereserveerde tijd: " + h + " ");


        }



        static void Res_save(int g, string a, int b, bool c, string d, string f, int h)
        {


            string reservation_string = g + " " + a + " " + b + " " + " Alcohol mag " + c + " " + d + " " + " " + f + " " + h + " minuten";
            Console.Write(reservation_string);
            // String reservation
            Reservation newReservation = new Reservation(g, a, b, c, d, f, h);

            // Read the contents of the JSON file into a string
            resList.Add(new Reservation(g, a, b, c, d, f, h)
            {
                Id = g,
                Name = a,
                Hoeveelheid = b,
                Alc = c,
                Tijd = d,

                Dag = f,
            });

            // Add the new User object to the list of res objects
            //resList.Add(newReservation);

            // Serialize the list of User objects into a JSON string
            string jsonString = JsonSerializer.Serialize(resList);

            // Write the JSON string to the JSON file
            File.WriteAllText("C:\\Users\\Mosqu\\Desktop\\Reservingen.JSON", jsonString);


        }
    }
}

