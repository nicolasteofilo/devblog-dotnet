using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.CategoryScreen;

public static class DeleteCategoryScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var id = ConsoleUtils.Input("Tag ID");
        
        if (!Int32.TryParse(id, out var tagId))
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            ConsoleUtils.ErrorMessage("Category ID is required.");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        
        Delete(tagId);
    }

    private static void Delete(int categoryId)
    {
        var repository = new Repository<Category>(Database.Connection!);
        var category = repository.GetById(categoryId);
        if (category == null)
        {
            ConsoleUtils.ErrorMessage("Category not found");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        
        repository.Delete(categoryId);
        ConsoleUtils.SuccessMessage("Category deleted!");
        ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
    }
}