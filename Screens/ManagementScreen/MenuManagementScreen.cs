using dev_blog_dotnet.Screens.CategoryScreen;
using dev_blog_dotnet.Screens.PostScreen;
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
        Console.WriteLine("3. Categories");
        Console.WriteLine("4. Posts");
        Console.WriteLine("5. Roles");
        ConsoleUtils.ErrorMessage("6. Exit");
        
        Console.Write("Your choice: ");
        var operation = Console.ReadLine()  ?? string.Empty;
        
        switch (operation)
        {
            case "1":
                ConsoleUtils.ClearConsole();
                MenuUserScreen.Display();
                break;
            case "2":
                ConsoleUtils.ClearConsole();
                MenuTagScreen.Display();
                break;
            case "3":
                ConsoleUtils.ClearConsole();
                MenuCategoryScreen.Display();
                break;
            case "4":
                ConsoleUtils.ClearConsole();
                MenuPostScreen.Display();
                break;
            case "6":
                ConsoleUtils.ClearConsole();
                System.Environment.Exit(0);
                break;
            default:
                Program.Main();
                break;
        }
    }
}