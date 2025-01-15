using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.UserScreen;

public static class UpdateUserScreen
{
    private static readonly UserRepository UserRepository = new UserRepository(Database.Connection!);
    
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        
        var id = ConsoleUtils.Input("User ID");
        if (!Int32.TryParse(id, out var userId))
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            ConsoleUtils.ErrorMessage("User ID is required.");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        
        var user = UserRepository.GetByIdWithRoles(userId);
        var roles = user!.Roles.Any() ? string.Join(", ", user.Roles.Select(role => role.Name)) : string.Empty;
        ConsoleUtils.ClearConsole();
        Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email} Bio: {user.Bio} ({roles})");
        ConsoleUtils.InfoMessage("Specify the fields you'd like to update and leave the others blank to retain their current values.\n");
        
        var name = ConsoleUtils.Input("Full name");
        var email = ConsoleUtils.Input("Email");
        var password = ConsoleUtils.Input("Password");
        var bio = ConsoleUtils.Input("Bio");

        if (!name.IsNullOrEmpty()) user.Name = name!;
        if (!email.IsNullOrEmpty()) user.Email = email!;
        if (!password.IsNullOrEmpty()) user.PasswordHash = password!;
        if (!bio.IsNullOrEmpty()) user.Bio = bio!;

        Update(user);
    }

    private static void Update(User user)
    {
        var userIsUpdated =UserRepository.Update(user);
        if (userIsUpdated)
        {
            ConsoleUtils.SuccessMessage("User updated!");
            ConsoleUtils.HandleQuestion("Update new user?", Display, Program.Main);
        }
        else
        {
            ConsoleUtils.ErrorMessage("User could not be updated! Please try again.");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
    }
}