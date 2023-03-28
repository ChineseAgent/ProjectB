using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
        }
        else
        {

            Reservering NieuweReservering = new Reservering(Account.CurrentUser.CustomerId, Account.CurrentUser.Email, Account.CurrentUser.Achternaam, Account.CurrentUser.Telefoonnummer, hoeveelheid, gekozenTijd.ToString("HH:mm"), ReserveringsCode());
            StuurNaarJson(NieuweReservering);
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
}
