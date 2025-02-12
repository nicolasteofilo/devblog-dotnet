﻿using dev_blog_dotnet.Models;
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

        ConsoleUtils.PrintErrors(errors, Display);
        var tag = new Tag()
        {
            Name = name!,
            Slug = name!.Replace(" ", "-").Trim().ToLower()
        };
        Add(tag);
    }

    private static void Add(Tag tag)
    {
        var repository = new Repository<Tag>(Database.Connection!);
        repository.Add(tag);
        ConsoleUtils.SuccessMessage("New tag created!");
        ConsoleUtils.HandleQuestion("Add new tag?", Display, Program.Main);
    }
}