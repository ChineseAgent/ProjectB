public class Reservation
{


    public int Id { get; set; }
    public string Name { get; set; }
    public int Hoeveelheid { get; set; }
    public bool Alc { get; set; }
    public string Tijd { get; set; }

    public string Dag { get; set; }
    public int Time { get; set; }
    public Reservation(int id, string name, int hoevheelheid, bool alc, string tijd, string dag, int time)
    {

        Id = id;
        Name = name;
        Hoeveelheid = hoevheelheid;
        Alc = alc;
        Tijd = tijd;

        Dag = dag;
        Time = time;
    }
}