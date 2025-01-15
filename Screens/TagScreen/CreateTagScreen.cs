using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.TagScreen;

public static class CreateTagScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var name = ConsoleUtils.Input("Name");

        IList<string> errors = new List<string>();
        if (name.IsNullOrEmpty())
            errors.Add("Name is required");

        if (errors.Any())
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            foreach (var err in errors)
            {
                ConsoleUtils.ErrorMessage(err);
            }

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
        else
        {
            Add(name!);
        }
    }

    private static void Add(string name)
    {
        var repository = new Repository<Tag>(Database.Connection!);
        var tag = new Tag()
        {
            Name = name,
            Slug = name.Replace(" ", "-").Trim().ToLower()
        };
        repository.Add(tag);
        ConsoleUtils.SuccessMessage("New tag created!");
        Console.Write("Add new tag? (y/n): ");
        var optionToAddNewTag = Console.ReadLine() ?? string.Empty;
            
        switch (optionToAddNewTag)
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