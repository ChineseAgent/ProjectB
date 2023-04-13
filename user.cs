public class User
{
    public string? Email { get; set; }
    public string? Wachtwoord { get; set; }
    public string? Voornaam { get; set; }
    public string? TussenVoegsel { get; set; }
    public string? Achternaam { get; set; }

    public string? Telefoonnummer { get; set; }

    public string? Geboortedatum { get; set; }

    public string? Adres { get; set; }
    public string? Plaatsnaam { get; set; }
    public string? Postcode { get; set; }

    public int CustomerId { get; set; }
    public bool Admin { get; set; }


    public User(string? email, string? wachtwoord, string? voornaam, string? tussenvoegel, string? achternaam, string? telefoonnummer, string? geboortedatum, string? adres, string? plaatsnaam, string? postcode, int customerid, bool admin)
    {
        Email = email;
        Wachtwoord = wachtwoord;
        Voornaam = voornaam;
        TussenVoegsel = tussenvoegel;
        Achternaam = achternaam;
        Telefoonnummer = telefoonnummer;
        Geboortedatum = geboortedatum;
        Adres = adres;
        Plaatsnaam = plaatsnaam;
        Postcode = postcode;
        CustomerId = customerid;
        Admin = admin;
        CustomerId++;
    }

    public User()
    {

    }
}