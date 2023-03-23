public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Naam { get; set; }

    public string Telefoonnummer { get; set; }

    public string Adres { get; set; }
    public string Plaatsnaam { get; set; }


    public User(string email, string Wachtwoord, string naam, string telefoonnummer, string adres, string plaatsnaam)
    {
        Email = email;
        Wachtwoord = Wachtwoord;
        Naam = naam;
        Telefoonnummer = telefoonnummer;
        Adres = adres;
        Plaatsnaam = plaatsnaam;
    }
    public User()
    {

    }
}