public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }

    public int Telefoonnummer { get; set; }

    public string Adres { get; set; }
    public string Plaatsnaam { get; set; }


    public User(string email, string password, string name, int telefoonnummer, string adres, string plaatsnaam)
    {
        Email = email;
        Password = password;
        Name = name;
        Telefoonnummer = telefoonnummer;
        Adres = adres;
        Plaatsnaam = plaatsnaam;
    }
}