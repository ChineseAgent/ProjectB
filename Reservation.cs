public class Reservation
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }

    public int Hoeveel_Personen { get; set; }

    public string Email { get; set; }
    public string Gekozen_Tijd { get; set; }
    public string Gekozen_Dag { get; set; }
    public string Telefoonnummer { get; set; }
    public string ReserveringsNummer { get; set; }

    public Reservation()
    {
    }

    public Reservation(int customerId, string voornaam, string tussenvoegsel, string achternaam, string telefoonnummer, string email, string gekozen_Dag, string gekozen_Tijd, int hoeveel_Personen, string reserveringsNummer)
    {
        CustomerId = customerId;
        CustomerName = voornaam + " " + tussenvoegsel + " " + achternaam;
        Telefoonnummer = telefoonnummer;
        Email = email;
        Gekozen_Dag = gekozen_Dag;
        Gekozen_Tijd = gekozen_Tijd;
        Hoeveel_Personen = hoeveel_Personen;
        ReserveringsNummer = reserveringsNummer;
    }
}
