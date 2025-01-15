using dev_blog_dotnet.Screens.UserScreen;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.ManagementScreen;

public static class MenuManagementScreen
{
    public static void Display()
    {
        Console.WriteLine(ConsoleUtils.BoldText("OPTIONS"));
        Console.WriteLine("1. Users");
        Console.WriteLine("2. Roles");
        Console.WriteLine("3. Tags");
        Console.WriteLine("4. Posts");
        
        Console.Write("Your choice: ");
        var operation = float.Parse(Console.ReadLine() ?? string.Empty);
        
        switch (operation)
        {
            case 1:
                ConsoleUtils.ClearConsole();
                MenuUserScreen.Display();
                break;
        }
    }
}