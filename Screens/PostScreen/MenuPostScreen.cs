using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.PostScreen;

public static class MenuPostScreen
{
    public static void Display()
    {
        Console.WriteLine(ConsoleUtils.BoldText("Posts: "));
        Console.WriteLine(" 1. List posts");
        Console.WriteLine(" 2. View post");
        Console.WriteLine(" 3. New post");
        Console.WriteLine(" 3. Update post");
        Console.WriteLine(" 4. Remove post");
        
        Console.Write("Your choice: ");
        var operation = Console.ReadLine()  ?? string.Empty;
        
        switch (operation)
        {
            case "1":
                ConsoleUtils.ClearConsole();
                ListPostsScreen.Display();
                break;
            case "2":
                ConsoleUtils.ClearConsole();
                ViewPostScreen.Display();
                break;
            case "3":
                ConsoleUtils.ClearConsole();
                CreatePostScreen.Display();
                break;
            case "4":
                ConsoleUtils.ClearConsole();
                break;
            case "6":
                ConsoleUtils.ClearConsole();
                break;
            default:
                Program.Main();
                break;
        }
    }
}