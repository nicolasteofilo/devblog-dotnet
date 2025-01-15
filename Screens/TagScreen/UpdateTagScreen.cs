using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.TagScreen;

public static class UpdateTagScreen
{
    private static readonly Repository<Tag> TagRepository = new Repository<Tag>(Database.Connection!);

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
        else
        {
            var tag = TagRepository.GetById(tagId);
            ConsoleUtils.ClearConsole();
            Console.WriteLine($"Id: {tag!.Id}, Name: {tag.Name}");
            ConsoleUtils.InfoMessage("Specify the fields you'd like to update and leave the others blank to retain their current values.\n");
        
            var name = ConsoleUtils.Input("Name");
            if (!name.IsNullOrEmpty()) tag.Name = name!;
            
            Update(tag);
        }
    }

    private static void Update(Tag tag)
    {
        var tagIsUpdated = TagRepository.Update(tag);
        if (tagIsUpdated)
        {
            ConsoleUtils.SuccessMessage("Tag updated!");
            Console.Write("Update new tag? (y/n): ");
            var optionToUpdateNewUser = Console.ReadLine() ?? string.Empty;
            switch (optionToUpdateNewUser)
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
        else
        {
            ConsoleUtils.ErrorMessage("Tag could not be updated! Please try again.");
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
    }
}