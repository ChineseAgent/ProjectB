public class User
{
    public string Email { get; set; }
    public string Wachtwoord { get; set; }
    public string Naam { get; set; }

    public string Telefoonnummer { get; set; }

    public string Adres { get; set; }
    public string Plaatsnaam { get; set; }
    public int CustomerId { get; set; }


    public User(string email, string wachtwoord, string naam, string telefoonnummer, string adres, string plaatsnaam, int customerid)
    {
        Email = email;
        Wachtwoord = wachtwoord;
        Naam = naam;
        Telefoonnummer = telefoonnummer;
        Adres = adres;
        Plaatsnaam = plaatsnaam;
        CustomerId = customerid;
    }

    public User()
    {

    }
}