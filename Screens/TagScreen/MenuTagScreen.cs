namespace dev_blog_dotnet.Screens.TagScreen;

public static class MenuTagScreen
{
    public static void Display()
    {
        Console.WriteLine("Tags: ");
        Console.WriteLine(" 1. List tags");
        Console.WriteLine(" 2. New tag");
        Console.WriteLine(" 3. Update user");
        Console.WriteLine(" 4. Remove tag");
        
        Console.Write("Your choice: ");
        var operation = float.Parse(Console.ReadLine() ?? string.Empty);
    }
}