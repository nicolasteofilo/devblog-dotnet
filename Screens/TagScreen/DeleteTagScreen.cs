using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.TagScreen;

public static class DeleteTagScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var id = ConsoleUtils.Input("Tag ID");
        
        if (!Int32.TryParse(id, out var tagId))
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            ConsoleUtils.ErrorMessage("Tag ID is required.");
            Console.Write("Try again? (y/n): ");
            var input = Console.ReadLine();
            switch (input?.ToLower())
            {
                case "y":
                    Display();
                    break;
                case "n":
                    Program.Main();
                    break;
            }
        }
        
        Delete(tagId);
    }

    private static void Delete(int tagId)
    {
        var repository = new Repository<Tag>(Database.Connection!);
        var user = repository.GetById(tagId);
        if (user == null)
        {
            ConsoleUtils.ErrorMessage("Tag not found");
            Console.Write("Try again? (y/n): ");
            var input = Console.ReadLine();
            switch (input?.ToLower())
            {
                case "y":
                    Display();
                    break;
                case "n":
                    Program.Main();
                    break;
            }
        }
        
        repository.Delete(tagId);
        ConsoleUtils.SuccessMessage("Tag deleted!");
        Console.Write("Delete new tag? (y/n): ");
        var optionToDeleteNewTag = Console.ReadLine() ?? string.Empty;
        switch (optionToDeleteNewTag)
        {
            case "y":
                ConsoleUtils.ClearConsole();
                Display();
                break;
            case "n":
                Program.Main();
                break;
        }
    }
}