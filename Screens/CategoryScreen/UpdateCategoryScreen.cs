using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.CategoryScreen;

public static class UpdateCategoryScreen
{
    private static readonly Repository<Category> CategoryRepository = new Repository<Category>(Database.Connection!);

    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        
        var id = ConsoleUtils.Input("Category ID");
        if (!Int32.TryParse(id, out var categoryId))
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            ConsoleUtils.ErrorMessage("Category ID is required.");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        else
        {
            var category = CategoryRepository.GetById(categoryId);
            ConsoleUtils.ClearConsole();
            Console.WriteLine($"Id: {category!.Id}, Name: {category.Name}");
            ConsoleUtils.InfoMessage("Specify the fields you'd like to update and leave the others blank to retain their current values.\n");
        
            var name = ConsoleUtils.Input("Name");
            if (!name.IsNullOrEmpty()) category.Name = name!;
            
            Update(category);
        }
    }

    private static void Update(Category category)
    {
        var tagIsUpdated = CategoryRepository.Update(category);
        if (tagIsUpdated)
        {
            ConsoleUtils.SuccessMessage("Category updated!");
            ConsoleUtils.HandleQuestion("Update new category?", Display, Program.Main);
        }
        else
        {
            ConsoleUtils.ErrorMessage("Category could not be updated! Please try again.");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
    }
}