using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.TagScreen;

public static class ListTagsScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        List();
    }

    private static void List()
    {
        var repository = new Repository<Tag>(Database.Connection!);
        var tags = repository.GetAll();
        
        foreach (var tag in tags)
        {
            Console.WriteLine($"Id: {tag.Id}, Name: {tag.Name}");
        }
        
        ConsoleUtils.BackToMenuQuestion();
    }
}