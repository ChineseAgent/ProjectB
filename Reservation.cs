public class Reservation { 
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
   
    public int Hoeveelheid { get; set; }
    public bool Alc { get; set; }
    public string Email { get; set; }
    public string Tijd { get; set; }
    public string Dag { get; set; }
    public int Time { get; set; }
    public string Telefoonnummer { get; set; }
    public string ReserveringsNummer { get; set; }
    
    public Reservation(int customerId,string customerName,bool alc,string tijd,string dag, int time, string email, string telefoonnummer, int hoeveelheid, string reserveringsNummer)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        Alc = alc;
        Dag = dag;
        Email = email;


        Time = time;
        Telefoonnummer = telefoonnummer;
        ReserveringsNummer = reserveringsNummer;
    }
}
