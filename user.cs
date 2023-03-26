public class User
{
    public string Email { get; set; }
    public string Wachtwoord { get; set; }
    public string Voornaam { get; set; }
    public string TussenVoegsel { get; set; }
    public string Achternaam { get; set; }

    public string Telefoonnummer { get; set; }

    public string Adres { get; set; }
    public string Plaatsnaam { get; set; }
    public int CustomerId { get; set; }


    public User(string email, string wachtwoord, string voornaam, string tussenvoegel, string achternaam, string telefoonnummer, string adres, string plaatsnaam, int customerid)
    {
        Email = email;
        Wachtwoord = wachtwoord;
        Voornaam = voornaam;
        TussenVoegsel = tussenvoegel;
        Achternaam = achternaam;
        Telefoonnummer = telefoonnummer;
        Adres = adres;
        Plaatsnaam = plaatsnaam;
        CustomerId = customerid;
    }

    public User()
    {

    }
}