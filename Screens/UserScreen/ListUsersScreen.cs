using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.UserScreen;

public static class ListUsersScreen
{
    public static void Display()
    {
        var users = List();
        if (users.Count < 1)
            ConsoleUtils.ErrorMessage("There are no users. Please add at least one user!");
        
        foreach (var user in users)
        {
            var roles = user.Roles.Any() ? string.Join(", ", user.Roles.Select(role => role.Name)) : string.Empty;
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email} ({roles})");
        }
        ConsoleUtils.InfoMessage("Back to menu? (y/n): ");
        var option = Console.ReadLine() ?? string.Empty;
            
        switch (option)
        {
            case "y":
                ConsoleUtils.ClearConsole();
                Program.Main();
                break;
            case "n":
                ConsoleUtils.ClearConsole();
                System.Environment.Exit(0);
                break;
        }
    }

    private static IList<User> List()
    {
        var repository = new UserRepository(Database.Connection!);
        var users = repository.GetWithRoles();
        return users;
    }
}