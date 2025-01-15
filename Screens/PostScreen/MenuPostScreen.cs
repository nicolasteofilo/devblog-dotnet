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
    }
}