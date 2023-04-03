public static class Password
{
    public static string HidePassword()
    {
        var password = "";
        var key = Console.ReadKey(true);
        while (key.Key != ConsoleKey.Enter)
        {
            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            key = Console.ReadKey(true);
        }
        return password;
    }




}

