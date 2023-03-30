public static class Informatie
{
    public static void LaatInformatieZien()
    {
        Console.WriteLine(@"Dit is " + "\u001b[1m" + "vetgedrukte tekst" + "\u001b[0m" + ".");
        Console.ReadKey();

    }
}