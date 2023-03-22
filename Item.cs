public class Item
{
    public string Name;
    public double Price;
<<<<<<< HEAD
    public Item(string name, double price)
    {
        this.Name = name;
        this.Price = price;
=======
    public string Omschrijving;
    public string Allergieen;
    public Item(string name, double price, string omschrijving, string allergieen)
    {
        this.Name = name;
        this.Price = price;
        this.Omschrijving = omschrijving;
        this.Allergieen = allergieen;
>>>>>>> c4c811994b5074fbf78f923e753bfd15c63155e5
    }
}