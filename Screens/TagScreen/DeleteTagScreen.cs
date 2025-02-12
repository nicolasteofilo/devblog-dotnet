﻿using dev_blog_dotnet.Models;
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
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        
        Delete(tagId);
    }

    private static void Delete(int tagId)
    {
        var repository = new Repository<Tag>(Database.Connection!);
        var tag = repository.GetById(tagId);
        if (tag == null)
        {
            ConsoleUtils.ErrorMessage("Tag not found");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        
        repository.Delete(tagId);
        ConsoleUtils.SuccessMessage("Tag deleted!");
        ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
    }
}