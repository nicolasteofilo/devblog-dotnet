using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.CategoryScreen;

public static class CreateCategoryScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var name = ConsoleUtils.Input("Name");

        IList<string> errors = new List<string>();
        if (name.IsNullOrEmpty())
            errors.Add("Name is required");

        ConsoleUtils.PrintErrors(errors, Display);
        var category = new Category()
        {
            Name = name!,
            Slug = name!.Replace(" ", "-").Trim().ToLower()
        };

        Add(category);
    }

    private static void Add(Category category)
    {
        var repository = new Repository<Category>(Database.Connection!);
        repository.Add(category);
        ConsoleUtils.SuccessMessage("New category created!");
        ConsoleUtils.HandleQuestion("Add new category?", Display, Program.Main);
    }
}