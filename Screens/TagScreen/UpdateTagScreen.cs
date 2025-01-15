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
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
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
            ConsoleUtils.HandleQuestion("Update new tag?", Display, Program.Main);
        }
        else
        {
            ConsoleUtils.ErrorMessage("Tag could not be updated! Please try again.");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
    }
}