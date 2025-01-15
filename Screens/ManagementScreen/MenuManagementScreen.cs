using dev_blog_dotnet.Screens.TagScreen;
using dev_blog_dotnet.Screens.UserScreen;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.ManagementScreen;

public static class MenuManagementScreen
{
    public static void Display()
    {
        Console.WriteLine(ConsoleUtils.BoldText("OPTIONS"));
        Console.WriteLine("1. Users");
        Console.WriteLine("2. Tags");
        Console.WriteLine("3. Posts");
        Console.WriteLine("4. Roles");
        ConsoleUtils.ErrorMessage("5. Exit");
        
        Console.Write("Your choice: ");
        var operation = float.Parse(Console.ReadLine() ?? string.Empty);
        
        switch (operation)
        {
            case 1:
                ConsoleUtils.ClearConsole();
                MenuUserScreen.Display();
                break;
            case 2:
                ConsoleUtils.ClearConsole();
                MenuTagScreen.Display();
                break;
            case 5:
                ConsoleUtils.ClearConsole();
                System.Environment.Exit(0);
                break;
        }
    }
}