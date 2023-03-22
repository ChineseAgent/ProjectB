public class Table
{
    public bool Beschikbaar;
    public int TafelNummer;
    public int HoeveelPlek;
    public Table(int tafelNummer, int HoeveelPlek)
    {
        this.TafelNummer = tafelNummer;
        this.Beschikbaar = true;
        this.HoeveelPlek = HoeveelPlek;
    }
}
// make all the tables and then put them in a list, eight 2-person tables, five 4-person tables and Jake has two tables for groups of 6 people
