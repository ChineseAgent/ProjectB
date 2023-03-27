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


        static public void Main()
        {

            Console.WriteLine("Maak hier uw reservering, uw naam? ");

            // Onder wiens naam
            string? res_naam;
            string? res_alc;



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


            Console.WriteLine("Hoelang? ");
            string pattern2 = ":";
            duration = Console.ReadLine();
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


            Res_start(res_naam, res_personen, res_alcohol, tijd_stip, dagWeek, myDate, time_limit);

        }

        static void Res_start(string name, int people, bool drinking, string time, string dag, DateTime myDate, int time_limit)
        {
            int res_number = 1;








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


