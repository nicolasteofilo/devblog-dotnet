using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.CategoryScreen;

public static class ListCategoriesScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        List();
    }

    private static void List()
    {
        var repository = new Repository<Category>(Database.Connection!);
        var categories = repository.GetAll().ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"Id: {category.Id}, Name: {category.Name}");
        }

        if (categories.Count < 1)
        {
            Console.WriteLine("No categories found.");
        }

        ConsoleUtils.BackToMenuQuestion();
    }
}