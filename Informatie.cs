public static class Informatie
{
    public static void LaatInformatieZien()
    {
        Console.Clear();
        Inlogscherm.Logo();
        Console.WriteLine("");
        Console.WriteLine("\x1b[1mLocatie\x1b[0m");
        Console.WriteLine("Wijnhaven 107, 3011 WN Rotterdam");
        Console.WriteLine("");
        Console.WriteLine("\x1b[1mOpeningstijden\x1b[0m");
        Console.WriteLine("Maandag t/m vrijdag: 09:00 - 17:00");
        Console.WriteLine("Zaterdag: 09:00 - 16:00");
        Console.WriteLine("Zondag: Gesloten");
        Console.WriteLine("");
        Console.WriteLine("\x1b[1mParkeermogelijkheid\x1b[0m");
        Console.WriteLine("Betaald parkeren");
        Console.WriteLine("");
        Console.WriteLine("\x1b[1mContact\x1b[0m");
        Console.WriteLine("Telefoon: 010-1234567");
        Console.WriteLine("E-mail: projectbrestaurant@gmail.com");
        Console.WriteLine("");
        Console.WriteLine("Druk een toets in om terug te gaan naar het hoofdmenu...");
        Console.ReadKey();

    }
}