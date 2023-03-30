using Terminal.Gui;

public class Program
{
    public static void Main()
    {
        //         Application.Init();

        //         // Create a window for the menu
        //         var window = new Window("Menu")
        //         {
        //             X = 0,
        //             Y = 0,
        //             Width = Dim.Fill(),
        //             Height = Dim.Fill()
        //         };

        //         // Create the buttons for the menu
        //         var helloButton = new Button("Hello")
        //         {
        //             X = Pos.Center(),
        //             Y = Pos.Center() - 1,
        //             Width = 10
        //         };

        //         var quitButton = new Button("Quit")
        //         {
        //             X = Pos.Center(),
        //             Y = Pos.Center() + 1,
        //             Width = 10
        //         };

        //         // Add the buttons to the window
        //         window.Add(helloButton, quitButton);

        //         // Handle the click event of the Quit button
        //         quitButton.Clicked += () =>
        //         {
        //             var sureWindow = new SureWindow();
        //             Application.Top.Add(sureWindow);

        //         };

        //         // Show the window and start the application
        //         Application.Top.Add(window);
        //         Application.Run();
        //     }
        // }

        // // A window for the "Sure" confirmation
        // public class SureWindow : Window
        // {
        //     public SureWindow() : base("SURE")
        //     {
        //         X = Pos.Center();
        //         Y = Pos.Center();
        //         Width = Dim.Fill() - 1;
        //         Height = Dim.Fill() - 1;

        //         var label = new Label("Are you sure?")
        //         {
        //             X = Pos.Center(),
        //             Y = Pos.Top(this) + 2,
        //             Width = Dim.Fill()
        //         };

        //         var yesButton = new Button("Yes")
        //         {
        //             X = Pos.Center() - 6,
        //             Y = Pos.Top(this) + 4,
        //             Width = 10
        //         };

        //         var noButton = new Button("No")
        //         {
        //             X = Pos.Center() + 6,
        //             Y = Pos.Top(this) + 4,
        //             Width = 10
        //         };

        //         Add(label, yesButton, noButton);
        Inlogscherm.Keuzemenu();
    }
}
