class inlog
{
    public string username {get; set; }
    public string password {get; set; }
    public string email {get; set; }
    public int phone_number {get; set; }


    public void registeren() // registeren van de inloggevens
    {
        Console.WriteLine("Gebruikersnaam: ");
        string new_user = Console.ReadLine();
        new_user = username;

        Console.WriteLine("Wachtwoord: ");
        string new_pass = Console.ReadLine();
        new_pass = password;

        Console.WriteLine("E-mail: ");
        string new_email = Console.ReadLine();
        new_email = email;

        Console.WriteLine("Telefoonnummer: ");
        int new_phone = int.Parse(Console.ReadLine());
        new_phone = phone_number;
    }   

    public void inloggen()
    {

        Console.WriteLine("Gebruikersnaam: ");
        string username = Console.ReadLine();
        

        Console.WriteLine("Wachtwoord: ");
        string password = Console.ReadLine();
    } 
}