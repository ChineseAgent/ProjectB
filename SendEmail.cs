using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;



/*Hoe te gebruiken?
Send.SendReservationConfirmation("tymovanrijn@gmail.com", "23-04-2023", "18:00-20:00").Wait();
Het moet precies deze line zijn, de parameters moeten natuurlijk wel anders
maar de wait moet er achter staan, anders werkt het niet.*/


public static class Send
{
    public static async Task SendReservationConfirmation(string receiverEmail, string reservationDate, string reservationTime)
    {
        // replace with your own API key
        string apiKey = "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";

        // create a new SendGrid client
        var client = new SendGridClient(apiKey);

        // create a new email message
        var message = new SendGridMessage
        {
            From = new EmailAddress("projectbrestaurant@gmail.com", "Project B Restaurant"),
            Subject = "Bevestiging van uw reservering",
            HtmlContent = "<html>" +
                      "<head>" +
                      "<style>" +
                      "body { font-family: Arial, sans-serif; }" +
                      "h1 { font-size: 36px; font-family: 'Helvetica Neue', sans-serif; }" +
                      "h2 { font-size: 24px; font-family: 'Helvetica Neue', sans-serif; }" +
                      "p { font-size: 18px; font-family: Arial, sans-serif; }" +
                      "ul { font-size: 18px; font-family: Arial, sans-serif; margin-left: 20px; }" +
                      "</style>" +
                      "</head>" +
                      "<body>" +
                      "<h1>Bevestiging van uw reservering</h1>" +
                      "<p>Beste gewaardeerde klant,</p>" +
                      "<p>Hartelijk dank voor uw reservering bij Project B Restaurant. Wij zijn verheugd om uw reservering te bevestigen voor:</p>" +
                      "<ul>" +
                      reservationDate +
                      "<li>Tijdstip reservering: " + reservationTime + "</li>" +
                      "</ul>" +
                      "<p>Wij kijken ernaar uit om u binnenkort te verwelkomen!</p>" +
                      "<p>Met vriendelijke groeten,</p>" +
                      "<h2>Het team van Project B Restaurant.</h2>" +
                      "<img src='https://cdn.shopify.com/s/files/1/0066/4050/0834/files/PROJECT_B.png?height=628&pad_color=ffffff&v=1614134855&width=1200' alt='Picture of restaurant' style='max-width: 100%;'>" +
                      "</body>" +
                      "</html>"
        };

        message.AddTo(new EmailAddress(receiverEmail));

        // send the message
        var response = await client.SendEmailAsync(message);

        // check the response status code
        if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
        {
            Console.WriteLine("Reservation confirmation email sent successfully!");
        }
        else
        {
            Console.WriteLine("Reservation confirmation email failed to send. Error message: " + response.Body);
        }
    }
}







