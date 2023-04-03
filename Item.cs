public class Item
{
    public string Name;
    public double Price;

    public string Omschrijving;
    public string Vegan;
    public Item(string name, double price, string omschrijving, string vegan)
    {
        this.Name = name;
        this.Price = price;
        this.Omschrijving = omschrijving;
        this.Vegan = vegan;
    }
}