public class Item
{
    public string Name;
    public double Price;
    public string Omschrijving;
    public string Allergieen;
    public Item(string name, double price, string omschrijving, string allergieen)
    {
        this.Name = name;
        this.Price = price;
        this.Omschrijving = omschrijving;
        this.Allergieen = allergieen;
    }
}