using System.IO;
using System.Text.Json;

class ReadJsonFile
{
    static void Main()
    {
        string text = File.ReadAllText(@"./inlog.json");
        var person = JsonSerializer.Deserialize<inlog>(text);

        Console.WriteLine($"First name: {inlog.Gebruikersnaam}");
        Console.WriteLine($"Last name: {inlog.password}");
        Console.WriteLine($"Job title: {inlog.email}");
        Console.WriteLine($"Job title: {inlog.phone_number}");

    }
}