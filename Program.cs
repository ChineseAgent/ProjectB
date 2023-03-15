using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
Menu A = new Menu();
A.snel();

public class Program
{
    public static void Main()
    {
        TableView.CreateTables();
        while (true)
        {
            Console.Clear();
            // Send.SendReservationConfirmation("tymovanrijn@gmail.com", "23-04-2023", "18:00-20:00").Wait();
            Console.WriteLine("Met hoeveel personenen bent u?");
            int AantalPersonen = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            TableView.ReserveerTafel(AantalPersonen);

            TableView.Tafelindeling();
            Thread.Sleep(5000);
        }

    }
}

