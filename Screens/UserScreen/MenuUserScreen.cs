using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.UserScreen;

public static class MenuUserScreen
{
    public static void Display()
    {
        Console.WriteLine("Users: ");
        Console.WriteLine(" 1. List users");
        Console.WriteLine(" 2. New user");
        Console.WriteLine(" 3. Update user");
        Console.WriteLine(" 4. Remove user");
        
        Console.Write("Your choice: ");
        var operation = float.Parse(Console.ReadLine() ?? string.Empty);
        
        switch (operation)
        {
            case 1:
                ConsoleUtils.ClearConsole();
                ListUsersScreen.Display();
                break;
            case 2:
                CreateUserScreen.Display();
                break;
            case 3:
                UpdateUserScreen.Display();
                break;
            case 4:
                DeleteUserScreen.Display();
                break;
        }
    }
}