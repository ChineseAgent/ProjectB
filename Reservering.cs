public class Reservering
{
    public int CustomerId { get; set; }
    public string Email { get; set; }
    public string Achternaam { get; set; }
    public int Hoeveelheid { get; set; }
    public string Gekozentijd { get; set; }
    public string Telefoonnummer { get; set; }
    public string ReserveringsNummer { get; set; }

    public Reservering(int customerId, string email, string achternaam, string telefoonnummer, int hoeveelheid, string gekozentijd, string reserveringsNummer)
    {
        CustomerId = customerId;
        Email = email;
        Achternaam = achternaam;
        Hoeveelheid = hoeveelheid;
        Gekozentijd = gekozentijd;
        Telefoonnummer = telefoonnummer;
        ReserveringsNummer = reserveringsNummer;
    }
}
